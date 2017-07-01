using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace apox.owing.webapi.selfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://owinproductscrud.azurewebsites.net/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

         
                Console.WriteLine("Listening: "+ baseAddress);

                Console.WriteLine("Swagger is up at: " + baseAddress + "swagger");



                Console.ReadLine();
            }

        }
    }
}
