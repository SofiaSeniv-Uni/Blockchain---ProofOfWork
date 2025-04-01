using System.Security.Cryptography;
using System.Text;

namespace ProofOfWork
{
    internal class ProofOfWorkService
    {
        private static string ComputeSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public static Block MineBlock(string data, int startingZeros)
        {
            string prefix = new string('0', startingZeros / 4);
            int nonce = 0;
            string hash;
            do
            {
                hash = ComputeSHA256(data + nonce);
                nonce++;
            } while (!hash.StartsWith(prefix));

            return new Block { Hash = hash, Data = data, Nonce = (nonce - 1).ToString() };
        }
    }
}
