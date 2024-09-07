using System.Net;
using System.Text.Json;

namespace ConsoleApp8
{
    internal class Program
    {
        public class Quote
        {
            public string q { get; set; }//quote
            public string a { get; set; }//autor
        }
        static async Task Main(string[] args)
        {

            string url = "https://zenquotes.io/api/random";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        Quote[] quotes = JsonSerializer.Deserialize<Quote[]>(await response.Content.ReadAsStringAsync());
                        Console.WriteLine("Цитата:"+quotes[0].q+"\nАвтор: "+quotes[0].a);
                    }
                    else
                    {
                        throw new Exception();
                    }
                       
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
          
           
        }
    }
}
