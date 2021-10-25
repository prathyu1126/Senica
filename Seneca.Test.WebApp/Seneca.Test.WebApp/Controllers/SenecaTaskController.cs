using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SenecaTest.BL;
using SenecaTest.BL.Contracts;
using SenecaTest.BL.InputModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Seneca.Test.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SenecaTaskController : ControllerBase
    {
        private readonly ISenecaTaskService _serviceUtility;
        private readonly ILogger<SenecaTaskController> _logger;
        public SenecaTaskController(ISenecaTaskService serviceUtility, ILogger<SenecaTaskController> logger)
        {
            _serviceUtility = serviceUtility;
            _logger = logger;
        }

        [HttpGet("/getResults")]
        public async Task<ActionResult<string>> GetResults(string IPAddress)
        {
            try
            {
                    var response = await _serviceUtility.GetTaskResults(IPAddress);
                    if (response != null)
                        return Ok(response);
                    else
                        return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NoContent();
            }
        }
    }
}
