using System.Runtime.Serialization;

namespace TaskManagerAPI.Application.Exceptions;

public class AuthenticationErrorException : Exception
{
    public AuthenticationErrorException():base("Kullanıcı adı veya şifre hatalı")
    {
    }

    protected AuthenticationErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AuthenticationErrorException(string? message) : base(message)
    {
    }

    public AuthenticationErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}