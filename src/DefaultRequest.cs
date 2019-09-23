using Abstractions.Contracts;
using Abstractions.Impl;
using MediatR;

namespace EchantionChallenge
{
    public class DefaultRequest : RequestMessage,IRequest<ResponseMessage> 
    {
    }
}
