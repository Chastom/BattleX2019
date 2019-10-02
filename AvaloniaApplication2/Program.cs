using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using GameServer.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AvaloniaApplication2
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "api/player/";
        static string mediaType = "application/json";


        static async Task<ICollection<string>> GetAllValuesAsync(string path)
        {
            Console.WriteLine("Atejome pasifetchinti valuesus ir nupiesti grida!");
            ICollection<string> values = null;
            Console.WriteLine("Atejome pasifetchinti valuesus ir nupiesti grida1!");

            HttpResponseMessage response = await client.GetAsync(path + "api/values");
            Console.WriteLine("Atejome pasifetchinti valuesus ir nupiesti grida2!");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Atejome pasifetchinti valuesus ir nupiesti grida!3");
                values = await response.Content.ReadAsAsync<ICollection<string>>();
            }
            Console.WriteLine("Atejome pasifetchinti valuesus ir nupiesti grida!4");

            return values;
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://battlex2019.azurewebsites.net/"); //api /player/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            try
            {
                Console.WriteLine("0)\tGet all player");
                ICollection<string> valueList = await GetAllValuesAsync(client.BaseAddress.PathAndQuery);
                foreach (string p in valueList)
                {
                    Console.WriteLine(p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
            app.Run(new MainWindow());
        }
    }
}
