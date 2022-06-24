using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMServer server = ATMServer.Instance;

            server.ValidatePin("4029302940283948", 2839);
            Console.ReadKey();
        }
    }
}
