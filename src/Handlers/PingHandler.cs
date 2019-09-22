using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeSpan = System.TimeSpan;

namespace EchantionChallenge.Handlers
{
    public class PingHandler : IRequestHandler<Ping, ResponseMessage>
    {
        public async Task<ResponseMessage> Handle(Ping request, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            return  new ResponseMessage
            {
                Response = "pong"
            };
        }
    }
}
