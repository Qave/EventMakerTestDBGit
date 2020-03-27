using EventMakerTestDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventMakerTestDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost:44346";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Events").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Guestlist = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        foreach (var guest in Guestlist)
                            Console.WriteLine(guest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
            Console.ReadKey();

        }
    }
}
