using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerDocs.Classes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SwaggerDocs.Tests
{
    public class RequestPostTwoFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;
            if (type == typeof(Test2))
            {
                schema.Required.Add(nameof(Test2.AnotherProperty));

                schema.Properties[nameof(Test2.AnotherProperty)].Description = "Outra propriedade teste 2";

                schema.Properties[nameof(Test2.ThisIsTheBestProperty)].Description = "melhor propriedade teste 2";

                schema.Properties[nameof(Test2.Batman)].Description = "batman?";

                //var teste = OpenApiAnyFactory.CreateFor(schema, new List<teste>() { Classes.teste.Arvore, Classes.teste.Batman });

                schema.Properties[nameof(Test2.MyEnum)].Description = "a";

            }

            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(n => schema.Enum.Add(new OpenApiString(n)));
                //.ForEach(n => schema.Enum.Add(new OpenApiObject(new { Key: n })));
            }
        }
    }
}

public class RequestPostTwoDocument : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        //throw new System.NotImplementedException();
    }
}
