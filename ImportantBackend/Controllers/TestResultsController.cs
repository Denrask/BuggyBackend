
using Microsoft.AspNetCore.Mvc;
using TestAutomation.Services;

namespace TestAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestResultsController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public TestResultsController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var devices = _deviceService.GetAllDevices();
            return Ok(devices);
        }
    }
}
