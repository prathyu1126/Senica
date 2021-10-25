using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SenecaTest.BL;
using SenecaTest.BL.Contracts;

namespace Seneca.Test.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ISenecaTaskService, SenecaTaskService>();
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            //services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Seneca Task",
                    Description = "Task with pallel programming"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.UseIpRateLimiting();
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seneca Task");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



//using System;
///*
//A pizza delivery business has only one vehicle and one driver.
//The availability of the both of them are given as array of Availability objects.
//Availability object contains startTime of the day in HHMM and duration in minutes that resource is available.
//There will be no overlaps in the Availability blocks with in a resource availability array 
//and availabilities are sorted in the ascending order of startTime.

//You need to implement the method CombinedAvailability which returns an availability array
// with slots when both Driver and Vehicle are available
//*/
//namespace sample
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            /** Modify data for different test cses **/
//            Availability[] DriverAvailability = { new Availability(630, 60), new Availability(815, 30) };
//            Availability[] VehicleAvailability = {new Availability(645, 30), new Availability(745, 120)
//                                               , new Availability(1200, 45)};
//            System.Console.WriteLine("Driver Availability");
//            WriteAvailability(DriverAvailability);
//            System.Console.WriteLine("Vehicle Availability");
//            WriteAvailability(VehicleAvailability);

//            var availability = CombinedAvailability(DriverAvailability, VehicleAvailability);

//            System.Console.WriteLine("Combined Availability");
//            WriteAvailability(availability);
//        }

//        private int CalculateEndTime(int Starttime, Duration)
//        {
//            int minutes = StartTime.Tostring().Substring(StartTime.Tostring().Length - 2, 2);
//            int time = 0;
//            if (Duration < 60)
//            {


//                time = minutes + Duration > 60 ? ((minutes + Duration) / 60) * 100 : minutes + Duration;

//            }
//            else if (Duration > 60)
//            {
//                (minutes + Duration) / 60) *100;
//            }

//            return StartTime + time;

//        }

//        /** Provide implementation **/
//        private static Availability[] CombinedAvailability(Availability[] Driver,
//                                                           Availability[] Vehicle)
//        {
//            Availability[] combine;
//            for (int i = 0; i < Driver.Length; i++)
//            {
//                int DriverStartTime = Driver.StartTime;
//                int DriverEndTime = CalculateEndTime(Driver.StartTime, Driver.Duration)


//                 for (int j = 0; j < Vehicle.Length; using System;
///*
//A pizza delivery business has only one vehicle and one driver.
//The availability of the both of them are given as array of Availability objects.
//Availability object contains startTime of the day in HHMM and duration in minutes that resource is available.
//There will be no overlaps in the Availability blocks with in a resource availability array 
//and availabilities are sorted in the ascending order of startTime.

//You need to implement the method CombinedAvailability which returns an availability array
// with slots when both Driver and Vehicle are available
//*/
//namespace sample
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                /** Modify data for different test cses **/
//                Availability[] DriverAvailability = { new Availability(630, 60), new Availability(815, 30) };
//                Availability[] VehicleAvailability = {new Availability(645, 30), new Availability(745, 120)
//                                               , new Availability(1200, 45)};
//                System.Console.WriteLine("Driver Availability");
//                WriteAvailability(DriverAvailability);
//                System.Console.WriteLine("Vehicle Availability");
//                WriteAvailability(VehicleAvailability);

//                var availability = CombinedAvailability(DriverAvailability, VehicleAvailability);

//                System.Console.WriteLine("Combined Availability");
//                WriteAvailability(availability);
//            }

//            private int CalculateEndTime(int Starttime, Duration)
//            {
//                int minutes = StartTime.Tostring().Substring(StartTime.Tostring().Length - 2, 2);
//                int time = 0;
//                if (Duration < 60)
//                {


//                    time = minutes + Duration > 60 ? ((minutes + Duration) / 60) * 100 : minutes + Duration;

//                }
//                else if (Duration > 60)
//                {
//                    (minutes + Duration) / 60) *100;
//                }

//                return StartTime + time;

//            }

//            /** Provide implementation **/
//            private static Availability[] CombinedAvailability(Availability[] Driver,
//                                                               Availability[] Vehicle)
//            {
//                Availability[] combine;
//                for (int i = 0; i < Driver.Length; i++)
//                {
//                    int DriverStartTime = Driver.StartTime;
//                    int DriverEndTime = CalculateEndTime(Driver.StartTime, Driver.Duration)
   

//                 for (int j = 0; j < Vehicle.Length; j++)
//                    {
//                        int VehicleStartTime = Vehicle.StartTime;
//                        int VehiclerEndTime = CalculateEndTime(Vehicle.StartTime, Vehicle.Duration)

//                 if (Vehicle[J].StartTime <= Driver[i].StartTime && Vehicle[J].EndTime >= Driver[i].EndTime)
//                        {

//                            combine.Insert(new Availability {.StartTime = Driver[i].StartTime.Duration = Driver[i].Duration });
//                        }

//                    }
//                }
//                return combine;
//            }

//            private static void WriteAvailability(Availability[] availbilities)
//            {
//                foreach (var availability in availbilities)
//                {
//                    System.Console.Write(availability + " ");
//                }
//                System.Console.WriteLine();
//            }
//        }

//        class Availability
//        {
//            public int StartTime;
//            public int Duration;

//            public Availability(int startTime, int duration) => (StartTime, Duration) = (startTime, duration);

//            public override string ToString() => "(StartTime: " + StartTime + ", Duration: " + Duration + ")";
//        }
//    }
//++)
//                {
//                    int VehicleStartTime = Vehicle.StartTime;
//                    int VehiclerEndTime = CalculateEndTime(Vehicle.StartTime, Vehicle.Duration)

//                 if (Vehicle[J].StartTime <= Driver[i].StartTime && Vehicle[J].EndTime >= Driver[i].EndTime)
//                    {

//                        combine.Insert(new Availability {.StartTime = Driver[i].StartTime.Duration = Driver[i].Duration });
//                    }

//                }
//            }
//            return combine;
//        }

//        private static void WriteAvailability(Availability[] availbilities)
//        {
//            foreach (var availability in availbilities)
//            {
//                System.Console.Write(availability + " ");
//            }
//            System.Console.WriteLine();
//        }
//    }

//    class Availability
//    {
//        public int StartTime;
//        public int Duration;

//        public Availability(int startTime, int duration) => (StartTime, Duration) = (startTime, duration);

//        public override string ToString() => "(StartTime: " + StartTime + ", Duration: " + Duration + ")";
//    }
//}
