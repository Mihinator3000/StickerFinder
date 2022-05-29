using System.Runtime.Serialization;

namespace StickerFinder.Domain.Exceptions;

public class UnfinishedOperationException : Exception
{
    public UnfinishedOperationException()
    {
    }

    public UnfinishedOperationException(string? message)
        : base(message)
    {
    }

    public UnfinishedOperationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }


    public UnfinishedOperationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}