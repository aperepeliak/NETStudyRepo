using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadLine();
                Console.WriteLine("Stopping!");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use(async (env, next) =>
            //{
            //    foreach (var pair in env.Environment)
            //    {
            //        Console.WriteLine($"{pair.Key} : {pair.Value}");
            //    }

            //    await next();
            //});

            app.Use(async (env, next) =>
            {
                Console.WriteLine($"Requesting : {env.Request.Path}");
                await next();
                Console.WriteLine($"Response : {env.Response.StatusCode}");
            });

            app.UseHelloWorld();

            // without sugar - app.Use<HelloWorldComponent>();

            //app.UseWelcomePage();
            //app.Run(ctx => 
            //{
            //    return ctx.Response.WriteAsync("Hello world!");
            //});
        }
    }

    // syntactic sugar
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
