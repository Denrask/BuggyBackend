
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TestAutomation.Services
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class TestResult
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public DateTime TestDate { get; set; }
        public string Result { get; set; }
    }

    public interface IDeviceService
    {
        List<Device> GetAllDevices();
    }

    public class DeviceService : IDeviceService
    {
        private readonly string _connectionString;

        public DeviceService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Device> GetAllDevices()
        {
            var devices = new List<Device>();
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT d.Id, d.Name, d.Type, t.Result FROM Devices d JOIN Tests t ON d.Id = t.DeviceID", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        devices.Add(new Device
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Type = reader["Type"].ToString()
                            // The Result property from Tests is not used here, leading to an incorrect JOIN usage.
                        });
                    }
                }
            }

            return devices;
        }
    }
}
