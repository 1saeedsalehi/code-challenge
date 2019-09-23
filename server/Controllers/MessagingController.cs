using Abstractions.Contracts;
using Abstractions.Impl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace server.Controllers
{
    [Produces("application/json")]
    [Route("api/Messaging")]
    public class MessagingController : Controller
    {
        public IResponseMessage Post(RequestMessage requestMessage)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                if (requestMessage == null)
                {
                    response.Response = "invalid request";
                    return response;
                }

                List<string> validRequestMessage = new List<string>()
                {
                    "Hello","Bye","Ping"
                };

                if (!validRequestMessage.Contains(requestMessage.Request))
                {
                    response.Response = "invalid request";
                    return response;
                }

                if (requestMessage.Request == "Hello")
                {
                    response.Response = "Hi";
                }

                if (requestMessage.Request == "Ping")
                {
                    response.Response = "Pong";
                }
            }
            catch (Exception exception)
            {
                response.Response = exception.ToString();
            }
            finally
            {
                //Log Request and/or Response to db
            }

            return response;
        }
    }
}