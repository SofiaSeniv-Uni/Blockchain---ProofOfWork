using Newtonsoft.Json;

namespace ProofOfWork
{
    internal class BlockStorage
    {
        public static void SaveBlock(Block block, string filePath)
        {
            string json = JsonConvert.SerializeObject(block, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
