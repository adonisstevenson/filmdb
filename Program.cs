using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using filmdb.Models;

namespace filmdb
{
    public class Program
    {   
        public class Test{
        public static void sth(){
            Console.WriteLine("Hello");
        }
    }
        public static void Main(string[] args)
        {


            CreateHostBuilder(args).Build().Run();

    
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    



}
