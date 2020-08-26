using SwaggerDocs.Tests;
using Swashbuckle.Swagger.Annotations;

namespace SwaggerDocs.Classes
{
    public enum MyEnumerator
    {
        Arvore = 1,
        Arvorinha = 2,
        Batman = 99
    }

    public class Test2
    {
        public string AnotherProperty { get; set; }
        public string ThisIsTheBestProperty { get; set; }
        public string Batman { get; set; }
        public MyEnumerator MyEnum { get; set; }
    }
}
