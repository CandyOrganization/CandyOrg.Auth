using System.Text;
using System.Text.Json;
using Core.Auth.Exceptions;

namespace Core.Auth.Tokens;

public static class TokenParser
{
    public static TokenPayload GetClaims(string token)
    {
        var payload = Parse(token);
        var json = JsonSerializer.Serialize(payload);
        TokenPayload? tokenClaims; 
        try
        {
            tokenClaims = JsonSerializer.Deserialize<TokenPayload>(json);
        }
        catch (JsonException)
        {
            throw new TokenInvalidException("Не удалось получить payload токена");
        }

        if (tokenClaims is null)
        {
            throw new TokenInvalidException("Не удалось получить payload токена");
        }

        return tokenClaims;
    }

    /// <summary>
    /// Парсит JWT-токен и возвращает полезные данные (payload) в виде словаря.
    /// </summary>
    /// <param name="token">JWT-токен в формате header.payload.signature</param>
    /// <returns>Словарь с данными из payload</returns>
    private static Dictionary<string, object> Parse(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("Токен не может быть пустым", nameof(token));   
        }

        var parts = token.Split('.');
        if (parts.Length != 3)
        {
            throw new FormatException("Неверный формат JWT");
        }

        var payloadJson = Base64UrlDecode(parts[1]);
        var payload = JsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson);

        return payload ?? new Dictionary<string, object>();
    }

    private static string Base64UrlDecode(string input)
    {
        string padded = input.Replace('-', '+').Replace('_', '/');

        switch (padded.Length % 4)
        {
            case 2: padded += "=="; break;
            case 3: padded += "="; break;
        }

        var bytes = Convert.FromBase64String(padded);
        return Encoding.UTF8.GetString(bytes);
    }
}