using SenecaTest.BL.InputModels;
using SenecaTest.BL.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenecaTest.BL
{
    public static class ServiceHelper
    {

        public static IEnumerable<ServiceDetails> ServicesList =>
            new List<ServiceDetails>
            { new ServiceDetails() { Name = "GeoIP", Url = "https://freegeoip.app/json/{0}" },
              new ServiceDetails() { Name = "RDAP", Url = "https://rdap.arin.net/registry/ip/{0}" },
              new ServiceDetails() { Name = "GeoIP2", Url = "http://ip-api.com/json/{0}" }
            };
     }
}
