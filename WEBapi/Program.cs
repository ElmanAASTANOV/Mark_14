using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace WEBapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
             (new WebHostBuilder())
           .UseKestrel()
           .UseUrls("http://192.168.1.102:1453")
           .UseContentRoot("C:/Projects/DotNETcore/mark_14/WEBapi")
           .UseStartup<Startup>()
           .Build()
           .Run();
        }
    }
}
