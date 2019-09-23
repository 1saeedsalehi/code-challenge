using Abstractions.Impl;
using MediatR;

namespace Server
{
    public class DefaultRequest : RequestMessage,IRequest<ResponseMessage> 
    {
    }
}
