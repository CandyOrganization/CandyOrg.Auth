namespace CandyOrg.Auth.Exceptions;

public class TokenInvalidException(string message) : Exception
{
    public override string Message { get; } = message;
}