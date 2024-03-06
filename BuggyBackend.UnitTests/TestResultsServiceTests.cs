using NUnit.Framework;

namespace TestAutomation.UnitTests
{
    [TestFixture]
    public class TestResultsServiceTests
    {
        private TestResultsService _service;

        [SetUp]
        public void Setup()
        {
            // Ensure to adjust the connection string to the actual path of the TestAutomation.db file
            _service = new TestResultsService("Data Source=TestAutomation.db;Version=3;");
        }

        [Test]
        public void GetTestResults_PageSize_ReturnsExactNumberOfResults()
        {
            int pageSize = 10;
            var results = _service.GetTestResults(1, pageSize).ToList();

            Assert.AreEqual(pageSize, results.Count, "The number of test results returned should equal the pageSize.");
        }

        [Test]
        public void GetTestResults_PageSizeAbove30_ThrowsError()
        {
            int pageSize = 31;
            Assert.Throws<ArgumentException>(() => _service.GetTestResults(1, pageSize),
                "The pageSize should not be above 30.");
        }

        [Test]
        public void GetTestResults_PageSize30OrUnder_ReturnsResults()
        {
            int pageSize = 30;
            var results = _service.GetTestResults(1, pageSize).ToList();

            Assert.AreEqual(pageSize, results.Count, "The number of test results returned should equal the pageSize.");
        }
    }
}