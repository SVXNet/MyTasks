using System;
using System.Text;
using PCLCrypto;

namespace MyTasks.Core.Services
{
    public class Encryption
    {
        public static string EncryptString(string str, string password, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var key = CreateDerivedKey(password, saltBytes);

            var aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var symetricKey = aes.CreateSymmetricKey(key);

            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(bytes);

        }

        public static string DecryptString(string str, string password, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var key = CreateDerivedKey(password, saltBytes);

            var aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var symetricKey = aes.CreateSymmetricKey(key);

            var encryptedData = Convert.FromBase64String(str);
            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, encryptedData);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        private static byte[] CreateDerivedKey(string password, byte[] salt, int iterations = 1000,
            int keyLengthInBytes = 32)
        {
            var key = NetFxCrypto.DeriveBytes.GetBytes(password, salt, iterations, keyLengthInBytes);
            return key;
        }


    }
}
