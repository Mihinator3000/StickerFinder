using System.Runtime.Serialization;

namespace StickerFinder.Domain.Exceptions;

public class InvalidLinkException : Exception
{
    public InvalidLinkException()
    {
    }

    public InvalidLinkException(string? message)
        : base(message)
    {
    }

    public InvalidLinkException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }


    public InvalidLinkException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}