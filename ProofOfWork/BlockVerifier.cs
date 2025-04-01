using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace ProofOfWork
{
    internal class BlockVerifier
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

        public static bool VerifyBlock(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            Block block = JsonConvert.DeserializeObject<Block>(File.ReadAllText(filePath));
            string computedHash = ComputeSHA256(block.Data + block.Nonce);
            return computedHash == block.Hash;
        }
    }
}
