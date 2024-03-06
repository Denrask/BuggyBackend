
using NUnit.Framework;
using System.Linq;
using TestAutomation.Services;

namespace TestAutomation.UnitTests
{
    [TestFixture]
    public class DeviceServiceTests
    {
        private DeviceService _deviceService;

        [SetUp]
        public void Setup()
        {
            // This should point to the actual SQLite database file path
            _deviceService = new DeviceService("Data Source= TestAutomation.db;Version=3;");
        }

        [Test]
        public void GetAllDevices_ReturnsAllDevices()
        {
            var devices = _deviceService.GetAllDevices();
            // Expecting 3 devices, but due to the incorrect JOIN, the result may vary
            Assert.AreEqual(3, devices.Count);
        }
    }
}
