using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerDocs.Classes;
using SwaggerDocs.Tests;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SwaggerDocs.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Teste
        /// </summary>
        /// <remarks>
        /// Validação de campos:
        /// 
        ///     {
        ///        "name": {
        ///          type: string,
        ///          required: true,
        ///          summary: nome de alguma coisa
        ///        },
        ///        "identifier": string + obrigatorio,
        ///        "birthdate": datetime + opcional
        ///     }
        /// </remarks>
        /// <param name="test.Name">Payload test</param>
        /// <required name="test.Name">Requerido</required>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public List<string> Post([FromBody] Test test)
        {
            return new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="test2"></param>
        /// <returns></returns>
        [HttpPost("test2")]
        public List<string> AnotherPost([FromBody] Test2 test2)
        {
            return new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            };
        }

        [HttpPost("test3")]
        public List<string> AnotherAnotherPost([FromBody] Test2 test3)
        {
            return new List<string>()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            };
        }
    }
}
