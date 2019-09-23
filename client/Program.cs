using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stream().Wait();
            StreamWithHttpClient().Wait();
        }

        static async Task StreamWithHttpClient()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:5000/api/messaging"));
                request.Headers.TransferEncodingChunked = true;
                request.Content = new PostStreamContent(GenerateNumbersNoManualChunking);
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    // Send the request
                    var sr = new StreamReader(stream);

                    // Consume the headers and response body
                    await ConsumeResponseLineAndHeadersAsync(sr);

                    var receiveTask = Receive(stream);

                    await receiveTask;
                }
            }
        }

       
        private static async Task ConsumeResponseLineAndHeadersAsync(StreamReader sr)
        {
            var responseLine = await sr.ReadLineAsync();
            while (true)
            {
                var header = await sr.ReadLineAsync();
                if (string.IsNullOrEmpty(header))
                {
                    break;
                }
            }
        }

        static async Task Receive(Stream stream)
        {
            var sr = new StreamReader(stream);

            while (!sr.EndOfStream)
            {
                Console.WriteLine("received: " + await sr.ReadLineAsync());
            }
        }


        static async Task GenerateNumbersNoManualChunking(Stream stream)
        {
            var sw = new StreamWriter(stream);

            
                Console.WriteLine($"sending Hello");
                await sw.WriteLineAsync("Hello");
                await sw.FlushAsync();
                await Task.Delay(500);
            
        }
    }
}