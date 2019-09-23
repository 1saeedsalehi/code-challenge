using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Contracts;
using Abstractions.Impl;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EchantionChallenge.Controller
{
    [Produces("application/json")]
    [Route("messaging")]
    [AllowAnonymous]
    public class TestController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentException($"The parameter '{nameof(mediator)}' could not be null", nameof(mediator));
        }

        [HttpPost("message")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Test([FromBody] RequestMessage request,CancellationToken cancellationToken)
        {
           
            var result = await _mediator.Send(new DefaultRequest{ Request =  request.Request},cancellationToken);
            
            return Ok(result);
        }


        //public IResponseMessage Post(RequestMessage requestMessage)
        //{
        //    ResponseMessage response = new ResponseMessage();
        //    try
        //    {
        //        if (requestMessage == null)
        //        {
        //            response.Response = "invalid request";
        //            return response;
        //        }

        //        List<string> validRequestMessage = new List<string>()
        //        {
        //            "Hello","Bye","DefaultRequest"
        //        };

        //        if (!validRequestMessage.Contains(requestMessage.Request))
        //        {
        //            response.Response = "invalid request";
        //            return response;
        //        }

        //        if (requestMessage.Request == "Hello")
        //        {
        //            response.Response = "Hi";
        //        }

        //        if (requestMessage.Request == "DefaultRequest")
        //        {
        //            response.Response = "Pong";
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        response.Response = exception.ToString();
        //    }
        //    finally
        //    {
        //        //Log Request and/or Response to db
        //    }

        //    return response;
        //}
    }
}
