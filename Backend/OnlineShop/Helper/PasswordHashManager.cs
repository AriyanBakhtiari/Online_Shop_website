using System.Security.Cryptography;
using System.Text;

namespace OnlineShop;

public static class PasswordHashManager
{
    public static string ComputeHash(string plainText,
        string hashAlgorithm,
        byte[] saltBytes = null)
    {
        if (saltBytes == null)
        {
            const int minSaltSize = 4;
            const int maxSaltSize = 8;

            var random = new Random();
            var saltSize = random.Next(minSaltSize, maxSaltSize);

            saltBytes = new byte[saltSize];

            RNGCryptoServiceProvider rng = new();

            rng.GetNonZeroBytes(saltBytes);
        }

        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        var plainTextWithSaltBytes =
            new byte[plainTextBytes.Length + saltBytes.Length];

        for (var i = 0; i < plainTextBytes.Length; i++)
            plainTextWithSaltBytes[i] = plainTextBytes[i];

        for (var i = 0; i < saltBytes.Length; i++)
            plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

        hashAlgorithm ??= "";

        HashAlgorithm hash = hashAlgorithm.ToUpper() switch
        {
            "SHA1" => new SHA1Managed(),
            "SHA256" => new SHA256Managed(),
            "SHA384" => new SHA384Managed(),
            "SHA512" => new SHA512Managed(),
            _ => new MD5CryptoServiceProvider()
        };

        var hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

        var hashWithSaltBytes = new byte[hashBytes.Length +
                                         saltBytes.Length];

        for (var i = 0; i < hashBytes.Length; i++)
            hashWithSaltBytes[i] = hashBytes[i];

        for (var i = 0; i < saltBytes.Length; i++)
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

        var hashValue = Convert.ToBase64String(hashWithSaltBytes);

        return hashValue;
    }

    public static bool VerifyHash(string plainText,
        string hashAlgorithm,
        string hashValue)
    {
        var hashWithSaltBytes = Convert.FromBase64String(hashValue);

        hashAlgorithm ??= "";

        var hashSizeInBits = hashAlgorithm.ToUpper() switch
        {
            "SHA1" => 160,
            "SHA256" => 256,
            "SHA384" => 384,
            "SHA512" => 512,
            _ => 128
        };

        var hashSizeInBytes = hashSizeInBits / 8;

        if (hashWithSaltBytes.Length < hashSizeInBytes)
            return false;

        var saltBytes = new byte[hashWithSaltBytes.Length -
                                 hashSizeInBytes];

        for (var i = 0; i < saltBytes.Length; i++)
            saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

        var expectedHashString =
            ComputeHash(plainText, hashAlgorithm, saltBytes);

        return hashValue == expectedHashString;
    }
}