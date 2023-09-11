namespace Xp.Api.Application.Handlers;

public static class ExceptionMessageHandler
{
    public static string ExtractExceptionMessage(Exception exception)
    {
        while (exception.InnerException != null)
        {
            exception = exception.InnerException;
        }
        return exception.Message;
    }
}