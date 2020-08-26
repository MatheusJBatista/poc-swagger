using SwaggerDocs.Tests;
using Swashbuckle.Swagger.Annotations;

namespace SwaggerDocs.Classes
{
    public enum teste
    {
        Arvore,
        Arvorinha,
        Batman
    }

    public class Test2
    {
        public string AnotherProperty { get; set; }
        public string ThisIsTheBestProperty { get; set; }
        public string Batman { get; set; }
        public teste MyEnum { get; set; }
    }
}
