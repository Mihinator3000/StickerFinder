using System.Runtime.Serialization;

namespace StickerFinder.Domain.Exceptions;

public class InvalidRequestException : Exception
{
    public InvalidRequestException()
    {
    }

    public InvalidRequestException(string? message)
        : base(message)
    {
    }

    public InvalidRequestException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }


    public InvalidRequestException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}