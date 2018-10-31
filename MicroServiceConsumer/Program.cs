using Consul;
using Newtonsoft.Json;
using RestTemplateCore;
using System;
using System.Linq;
using System.Net.Http;

namespace MicroServiceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(httpClient);
                var ret1 = rest.GetForEntityAsync<string []>("http://MsgService/api/values/").Result;
                Console.WriteLine(JsonConvert.SerializeObject(ret1));
            }
            Console.ReadKey();
        }
    }
}

