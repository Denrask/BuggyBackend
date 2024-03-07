
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("[controller]")]
[ApiController]
public class TestResultsController : ControllerBase
{
    private readonly TestResultsService _testResultsService;

    public TestResultsController(TestResultsService testResultsService)
    {
        _testResultsService = testResultsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TestResult>> Get(int page = 1, int pageSize = 10)
    {
        if (pageSize > 30)
            return BadRequest("The pageSize should not be above 30.");
        var testResults = _testResultsService.GetTestResults(page, pageSize);
        return Ok(testResults);
    }
}
