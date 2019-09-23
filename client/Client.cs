using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Contracts;
using Abstractions.Impl;

namespace client
{
    public class Client : IClient
    {
        private readonly  string apiBaseUrl = "http://localhost:5000/api/";
        public Task<TResponseMessage> SendAsync<TResponseMessage>(IRequestMessage requestMessage) where TResponseMessage : IResponseMessage
        {
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var w = client.PostAsync("messaging", requestMessage);
                w.Wait();
                HttpResponseMessage response = w.Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.read<TResponseMessage>();
                    result.Wait();
                    return result;
                }
                return default(Task<TResponseMessage>);
            }
        }

        public Task<ResponseMessage> SendAsync(IRequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> SendAsync<TResponseMessage>(IRequestMessage requestMessage) where TResponseMessage : IResponseMessage
        {
            throw new NotImplementedException();
        }
    }
}
