using System.Security.Cryptography;
using System.Text;

namespace Api.Utils;

public class PasswordHelper
{
    public static string GetHashedVariant(string password)
    {
        var sha512 = SHA512.Create();
        var computedHash = sha512.ComputeHash(Encoding.Default.GetBytes(password));
        return Convert.ToBase64String(computedHash);
    }
}