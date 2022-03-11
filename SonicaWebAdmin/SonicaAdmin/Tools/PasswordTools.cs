using System.Security.Cryptography;
using System.Text;

namespace SonicaWebAdmin.SonicaAdmin.Tools
{
    public static class PasswordTools
    {
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (var i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }

        public static byte[] CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            var rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return buff;
        }

        public static bool CheckPassword(string password, byte[] hash, byte[] salt)
        {
            return CompareByteArrays(hash, GenerateSaltedHash(password ?? string.Empty, salt));
        }
       
        public static byte[] GenerateSaltedHash(string value, byte[] salt)
        {
            return GenerateSaltedHash(Encoding.UTF8.GetBytes(value??string.Empty), salt);
        }

        public static byte[] GenerateSaltedHash(byte[] value, byte[] salt)
        {
            var saltedValue = new byte[value.Length + salt.Length];
            value.CopyTo(saltedValue, 0);
            salt.CopyTo(saltedValue, value.Length);

            return new SHA256Managed().ComputeHash(saltedValue);
        }
        
    }
}
