using BuggyBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuggyBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestOperatorController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi", "Ivan", "Judy"
        };

        private readonly ILogger<TestOperatorController> _logger;

        public TestOperatorController(ILogger<TestOperatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TestOperator> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new TestOperator
            {

                LastActivityDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Name = Names[Random.Shared.Next(Names.Length)],
                Age = Random.Shared.Next(0, 55),
            })
            .ToArray();
        }
    }
}
