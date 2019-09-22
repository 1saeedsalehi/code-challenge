using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EchantionChallenge
{
   
    public interface IRequestMessage
    {
         string Request { get; set; }
    }
    public interface IResponseMessage
    {
        string Response { get; set; }
    }
    public class RequestMessage : IRequestMessage
    {
        public string Request { get; set; }
    }
    public class ResponseMessage : IResponseMessage
    {
        public string Response { get; set; }
    }

    
    public interface IClient
    {
        Task<ResponseMessage> SendAsync(IRequestMessage requestMessage);

        Task<ResponseMessage> SendAsync<TResponseMessage>(IRequestMessage requestMessage)
            where TResponseMessage : IResponseMessage;
    }
}
