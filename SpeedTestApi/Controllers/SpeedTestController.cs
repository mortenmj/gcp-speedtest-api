using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeedTestApi.Models;
using SpeedTestApi.Services;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        private readonly ISpeedTestEvents _eventHub;
        
        public SpeedTestController(ISpeedTestEvents eventHub)
        {
            _eventHub = eventHub;
        }

        // GET speedtest/ping
        [Route("ping")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok("PONG");
        }

        // POST speedtest/
        [HttpPost]
        public async Task<ActionResult<string>> UploadSpeedTest([FromBody] TestResult speedTest)
        {
            await _eventHub.PublishSpeedTest(speedTest);

            var speedTestData = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";

            return Ok(speedTestData);
        }
    }
}
