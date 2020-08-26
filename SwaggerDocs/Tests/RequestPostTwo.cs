using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerDocs.Classes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace SwaggerDocs.Tests
{
    public class RequestPostTwoFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;
            
            if (type == typeof(Test2))
            {
                schema.Required.Add("anotherProperty");

                schema.Properties["anotherProperty"].Description = "Outra propriedade teste 2";

                schema.Properties["thisIsTheBestProperty"].Description = "melhor propriedade teste 2";

                schema.Properties["batman"].Description = "batman?";

                schema.Properties["myEnum"].Description = "a";

            }

            if (type.IsEnum)
                SetEnumExtensionValues(schema, type);
        }

        private static void SetEnumExtensionValues(OpenApiSchema schema, Type type)
        {
            var enumValues = Enum.GetValues(type);
            var enumExtensionValues = new OpenApiArray();
            
            foreach (var enumValue in enumValues)
            {
                var item = new OpenApiObject
                {
                    ["name"] = new OpenApiString(Enum.GetName(type, enumValue)),
                    ["value"] = new OpenApiString(enumValue.GetHashCode().ToString())
                };

                enumExtensionValues.Add(item);
            }

            schema.Extensions.Add("x_ms_enum",
                new OpenApiObject
                {
                    ["values"] = enumExtensionValues
                }
            );
        }
    }
}

//public class RequestPostTwoDocument : IDocumentFilter
//{
//    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
//    {
//        //throw new System.NotImplementedException();
//    }
//}
