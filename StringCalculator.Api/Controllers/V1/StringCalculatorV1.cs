using Microsoft.AspNetCore.Mvc;
using System;
using StringCalculator.Application.Actions;

namespace StringCalculator.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/StringCalculator")]
    [ApiController]
    [Produces("application/json")]
    public class StringCalculatorV1 : ControllerBase
    {
        private readonly GetStringCalculator stringCalculator;

        public StringCalculatorV1(GetStringCalculator stringCalculator)
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
    }
}
