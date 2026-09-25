using CandyOrg.Auth.Tokens;

namespace CandyOrg.Auth.Common.Interfaces;

public interface ITokenValidator
{
    public void Validate(TokenPayload payload);
}