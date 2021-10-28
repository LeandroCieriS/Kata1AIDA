using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/StringCalculator")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculator : ControllerBase
    {
        private readonly GetStringCalculator stringCalculator;

        public StringCalculator(GetStringCalculator stringCalculator)
        {
            this.stringCalculator = stringCalculator;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery]string input)
        {
            try
            {
                return Ok(stringCalculator.Execute(ParseInput(input)));
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        private static string ParseInput(string input)
        {
            return input.Replace("\\n", "\n");
        }

        public static void Convention(ApiVersioningOptions options)
        {
            options.Conventions.Controller<StringCalculator>().HasApiVersions(ApiVersioning.Versions(1, 1));
        }
    }
}
