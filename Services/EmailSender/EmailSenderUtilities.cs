using System.Security.Cryptography;
using System.Text;

namespace Opuestos_por_el_Vertice.Services.EmailSender
{
    public static class EmailSenderUtilities
    {
        public static string ConvertSHA256(string code)
        {
            string hash = string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));

                foreach (byte b in hashValue)
                    hash += $"{b:X2}";
            }
            return hash;
        }

        public static string CreateToken()
        {
            string token = Guid.NewGuid().ToString("N");
            return token;
        }
    }
}
