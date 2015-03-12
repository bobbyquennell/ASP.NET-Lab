using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    /*so one common trick that you'll see with the AppFunc is that you'll see code
     * use a using statement to essentially alias that type. 
     * So this is saying AppFunc is a func of IDictionary of string and object 
     * that returns a task. And now I can use AppFunc instead of the big long func definition. 
     * This is a lot like a type def in C++. The biggest difference in C# is that you cannot
     * have this using apply across multiple source code files so anywhere that you want to 
     * use the AppFunc, you'll have to define this using.*/
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {

        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping!");
            }

        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Use(async (environment, next) =>
            {   //Write Request.Path
                Console.WriteLine("Requesting : " + environment.Request.Path);
                await next();
                Console.WriteLine("Response : " + environment.Response.StatusCode);
            });
            ConfigureWebApi(app);
            //Respond("Hello!!")
            app.UseHelloWorld();// same as app.Use<HelloWorldComponent>();

        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);

        }

    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }
    public class HelloWorldComponent
    {
        private AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }
        public Task Invoke(IDictionary<string, object> ev)
        {
            var response = ev["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
