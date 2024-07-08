using System.Text;

namespace Core.Utilities;

public static class RandomStringsGenerator
{
    private static readonly Random random = new();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static string GetRandomString(int length)
    {
        StringBuilder stringBuilder = new(length);
        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }
        return stringBuilder.ToString();
    }
}
