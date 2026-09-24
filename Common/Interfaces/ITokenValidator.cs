using Core.Auth.Tokens;

namespace Core.Auth.Common.Interfaces;

public interface ITokenValidator
{
    public void Validate(TokenPayload payload);
}