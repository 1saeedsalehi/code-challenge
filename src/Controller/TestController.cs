using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EchantionChallenge.Controller
{
    [Route("test")]
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
           
            var result = await _mediator.Send(new Ping{Message =  request.Request},cancellationToken);
            
            return Ok(result);
        }
    }
}
