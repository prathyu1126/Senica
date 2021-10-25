using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenecaTest.BL.Contracts
{
    public interface ISenecaTaskService
    {
       Task<string[]> GetTaskResults(string IPAddress);
    }
}
