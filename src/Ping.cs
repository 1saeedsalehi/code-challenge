using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace EchantionChallenge
{
    public class Ping : IRequest<ResponseMessage>
    {
        public string Message { get; set; }
    }
}
