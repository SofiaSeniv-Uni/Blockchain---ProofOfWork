using ProofOfWork;

string data = "Example transaction data";
int startingZeros = 16;
string filePath = "block.json";

Block newBlock = ProofOfWorkService.MineBlock(data, startingZeros);
BlockStorage.SaveBlock(newBlock, filePath);
Console.WriteLine("Block mined and saved:");
Console.WriteLine(File.ReadAllText(filePath));

Console.WriteLine("Verification result: " + BlockVerifier.VerifyBlock(filePath));