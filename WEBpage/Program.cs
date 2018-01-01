using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WEBpage
{
    public class Program
    {
        public static void Main(string[] args)
        {
           new WebHostBuilder()
           .UseKestrel()
           .UseUrls("http://192.168.1.102:1454")
           .UseContentRoot("C:/Projects/DotNETcore/mark_14/WEBpage")
           .UseStartup<Startup>()
           .Build()
           .Run();
        }
    }
}
