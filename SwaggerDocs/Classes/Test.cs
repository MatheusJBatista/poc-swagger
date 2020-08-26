using System;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDocs.Classes
{
    public class Test
    {
        /// <summary>
        /// Nome de alguma coisa
        /// </summary>
        [Required]
        public string Name { get; set; }
        [Required]
        public string Identifier { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
