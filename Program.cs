using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        
        public async Task<Root> getRes(string contry)
        {
            var uri = string.Format("https://api.openweathermap.org/data/2.5/weather?appid=268d21bae7a1293421ff843fcc1133ec&q={0}&units=metric",contry);
            var client = new HttpClient();
            uri = uri + contry;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
               
            return JsonConvert.DeserializeObject<Root>(body);

        }
    }
}
