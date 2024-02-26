namespace TaskManagerAPI.Application.Exceptions;

public class PasswordChangeFailedException : Exception
{
    public PasswordChangeFailedException():base("Şifre güncellenirken bir hata oluştur.")
    {
    }

    public PasswordChangeFailedException(string? message) : base(message)
    {
    }

    public PasswordChangeFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}