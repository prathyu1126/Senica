using SenecaTest.BL.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SenecaTest.BL
{
    public class SenecaTaskService : ISenecaTaskService
    {
        public SenecaTaskService()
        {

        }
        public async Task<string[]> GetTaskResults(string IPAddress)
        {
            bool isValidIPAddress = ValidateIpAddress(IPAddress);
            if (!isValidIPAddress)
            {
                throw new Exception("Invalid Ip Address");
            }
            List<Task<string>> tasks = new List<Task<string>>();
            var client = new HttpClient();
            foreach (var service in ServiceHelper.ServicesList)
            {
                async Task<string> func()
                {
                    var response = await client.GetAsync(string.Format(service.Url , IPAddress));
                    return await response.Content.ReadAsStringAsync();
                }
                tasks.Add(func());
            }
            var responses = await Task.WhenAll(tasks);
            return responses;
        }

        private bool ValidateIpAddress(string IPAddress)
        {
            System.Net.IPAddress ipAddress;
            bool isValid = System.Net.IPAddress.TryParse(IPAddress, out ipAddress);
            return isValid;
        }
    }
}
