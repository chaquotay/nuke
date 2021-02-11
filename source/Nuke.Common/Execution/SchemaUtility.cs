﻿// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution
{
    public class SchemaUtility
    {
        public static void WriteBuildSchemaFile(NukeBuild build)
        {
            var buildSchemaFile = GetBuildSchemaFile(NukeBuild.RootDirectory);
            var buildSchema = GetBuildSchema(build);
            File.WriteAllText(buildSchemaFile, buildSchema.ToString());
        }

        public static JObject GetBuildSchema(NukeBuild build)
        {
            var parameters = ValueInjectionUtility
                .GetParameterMembers(build.GetType(), includeUnlisted: true)
                // .Where(x => x.DeclaringType != typeof(NukeBuild))
                .OrderBy(x => x.Name)
                .Select(x =>
                    new
                    {
                        DashedName = ParameterService.GetParameterDashedName(x),
                        MemberName = ParameterService.GetParameterMemberName(x),
                        Description = ParameterService.GetParameterDescription(x),
                        MemberType = x.GetMemberType(),
                        ScalarType = x.GetMemberType().GetScalarType(),
                        EnumValues = ParameterService.GetParameterValueSet(x, build)?.Select(x => x.Text),
                        IsRequired = x.HasCustomAttribute<RequiredAttribute>()
                    }).ToList();

            string GetJsonType(Type type)
                => type.IsCollectionLike()
                    ? "array"
                    : type.GetScalarType() == typeof(int)
                        ? "integer"
                        : type.GetScalarType() == typeof(bool)
                            ? "boolean"
                            : "string";

            var schema = JObject.Parse(@"
{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""title"": ""Build Schema"",
  ""definitions"": {
    ""build"": {
      ""type"": ""object"",
      ""properties"": {
      }
    }
  }
}
");

            var properties = schema["definitions"].NotNull()["build"].NotNull()["properties"].NotNull();
            foreach (var parameter in parameters)
            {
                var property = properties[parameter.MemberName] = new JObject();
                property["type"] = GetJsonType(parameter.MemberType);

                if (parameter.Description != null)
                    property["description"] = parameter.Description;

                if (parameter.EnumValues != null && !parameter.MemberType.IsCollectionLike())
                    property["enum"] = new JArray(parameter.EnumValues);

                if (parameter.MemberType.IsCollectionLike())
                {
                    property["items"] = new JObject();
                    property["items"].NotNull()["type"] = GetJsonType(parameter.ScalarType);
                    if (parameter.EnumValues != null)
                        property["items"].NotNull()["enum"] = new JArray(parameter.EnumValues);
                }
            }

            return schema;
        }

        public static void WriteParametersSchemaFile()
        {
            var parametersSchemaFile = GetParametersSchemaFile(NukeBuild.RootDirectory);
            var buildSchemaFile = GetBuildSchemaFile(NukeBuild.RootDirectory);
            var parametersSchema = GetParametersSchema(Path.GetFileName(buildSchemaFile));
            File.WriteAllText(parametersSchemaFile, parametersSchema.ToString());
        }

        public static JObject GetParametersSchema(string buildSchemaFile)
        {
            return JObject.Parse($@"
{{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""title"": ""NUKE Profile Schema"",
  ""$ref"": ""{buildSchemaFile}#/definitions/build"",
  ""properties"": {{
    ""$profiles"": {{
      ""type"": ""object"",
      ""additionalProperties"": {{
        ""$ref"": ""{buildSchemaFile}#/definitions/build""
      }}
    }}
  }}
}}
");
        }


        public static IReadOnlyDictionary<string, string[]> GetCompletionItems(string buildSchemaFile, string localParametersFile)
        {
            var schema = JObject.Parse(File.ReadAllText(buildSchemaFile));
            var parameters = JObject.Parse(File.ReadAllText(localParametersFile));

            var completionItems = new Dictionary<string, string[]>();
            completionItems.AddDictionary(GetCompletionItemsForBuildSchema(schema));
            completionItems[LoadedLocalProfilesParameterName] = GetCompletionItemsForLocalProfiles(parameters).ToArray();
            return completionItems;
        }

        public static IReadOnlyDictionary<string, string[]> GetCompletionItemsForBuildSchema(JObject schema)
        {
            string[] GetEnumValues(JObject property)
                => property["enum"] is { } enumProperty
                    ? enumProperty.Values<string>().ToArray()
                    : property["items"]?["enum"] is { } arrayEnumProperty
                        ? arrayEnumProperty.Values<string>().ToArray()
                        : null;

            var properties = schema["definitions"].NotNull()["build"].NotNull()["properties"].NotNull().Value<JObject>().Properties();
            return properties.ToDictionary(x => x.Name, x => GetEnumValues((JObject) x.Value));
        }

        private static string[] GetCompletionItemsForLocalProfiles(JObject obj)
        {
            return obj["$profiles"]?.Children<JProperty>().Select(x => x.Name).ToArray() ?? new string[0];
        }
    }
}
