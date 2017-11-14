using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;
namespace JARVIS6
{
    public class JARVISCryptography
    {
        private string CryptographyOutputPath = @"D:\JARVIS6\Cryptography";
        private string CryptographyRainbowTableScriptsPath = @"D:\JARVIS6\Cryptography\RainbowTableScripts";
        private string CryptographyRainbowTableBatchScriptPath = @"D:\JARVIS6\Cryptography\RainbowTableBatchScripts";
        private Dictionary<string, string> SqlServerHashTypes = new Dictionary<string, string>()
        {
            {"MD5", "32"},
            {"SHA", "40"},
            {"SHA1", "40"},
            {"SHA2_256", "64"},
            {"SHA2_512", "128"}
        };
        private string ASCIICharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890~`!@#$%^&*()_+-={}[]:\"|;'\\<>?,./ ";
        public JARVISCryptography()
        {
            try
            {
                Directory.CreateDirectory(CryptographyOutputPath);
                Directory.CreateDirectory(CryptographyRainbowTableScriptsPath);
                Directory.CreateDirectory(CryptographyRainbowTableBatchScriptPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public StatusObject GenerateBatchScripts (string WordLength)
        {
            StatusObject SO = new StatusObject();

            return SO;
        }
        public StatusObject GenerateInsertScripts(string FirstCharacter, string WordLength)
        {
            StatusObject SO = new StatusObject();
            try
            {
                char[] Target = ASCIICharacters.ToCharArray();
                char NewFirstCharacter = FirstCharacter == "space" ? ' ' : FirstCharacter.ToCharArray()[0];
                char OldFirstCharacter = Target[0];
                int Temp = Array.IndexOf(Target, NewFirstCharacter);
                Target[0] = NewFirstCharacter;
                Target[Temp] = OldFirstCharacter;
                var Permutations = Target.Select(x => x.ToString());
                int Length = Convert.ToInt32(WordLength);
                for (int i = 0; i < Length - 1; i++)
                {
                    Permutations = Permutations.SelectMany(x => Target, (x, y) => x + y);
                }
                // TODO Replace Files before Writing to Them
                int PermutationCount = 0;
                DateTime StartTime = DateTime.Now;
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Start Script Generation. Start: {0}", StartTime);
                Console.WriteLine("----------------------------------------------------------------");
                foreach (var Permutation in Permutations)
                {
                    if (Permutation.ToCharArray()[0] == NewFirstCharacter)
                    {
                        int PermutationRange = (PermutationCount / 10000) + 1;
                        // Name tables based on permutations
                        string TableName = String.Format("RAINBOW_{0}_{1}", (int)NewFirstCharacter, WordLength);
                        string StorageDirectory = String.Format(@"{0}\RAINBOW_{1}", CryptographyRainbowTableScriptsPath, (int)NewFirstCharacter);
                        Directory.CreateDirectory(StorageDirectory);
                        StreamWriter OutputFile = new StreamWriter(
                            String.Format(
                                @"{0}\{1}_{2}.sql",
                                StorageDirectory,
                                TableName,
                                PermutationRange), append: true);
                        MD5 MD5Calculator = MD5.Create();
                        SHA1 SHA1Calculator = SHA1.Create();
                        SHA256 SHA256Calculator = SHA256.Create();
                        SHA512 SHA512Calculator = SHA512.Create();
                        byte[] PermutationBytes = System.Text.Encoding.ASCII.GetBytes(Permutation);
                        byte[] PermutationMD5HashBytes = MD5Calculator.ComputeHash(PermutationBytes);
                        byte[] PermutationSHA1HashBytes = SHA1Calculator.ComputeHash(PermutationBytes);
                        byte[] PermutationSHA256HashBytes = SHA256Calculator.ComputeHash(PermutationBytes);
                        byte[] PermutationSHA512HashBytes = SHA512Calculator.ComputeHash(PermutationBytes);
                        string PermutationMD5Hash = String.Concat(PermutationMD5HashBytes.Select(x => x.ToString("X2")));
                        string PermutationSHA1Hash = String.Concat(PermutationSHA1HashBytes.Select(x => x.ToString("X2")));
                        string PermutationSHA256Hash = String.Concat(PermutationSHA256HashBytes.Select(x => x.ToString("X2")));
                        string PermutationSHA512Hash = String.Concat(PermutationSHA512HashBytes.Select(x => x.ToString("X2")));
                        string Query =
                            String.Format(
                                @"insert into {7} (Word,FirstLetter,WordLength,MD5,SHA1,SHA256,SHA512) values ('{0}','{1}',{2},'{3}','{4}','{5}','{6}')",
                                Permutation.Replace("'", "''"),
                                Permutation.ToCharArray()[0],
                                Permutation.Length,
                                PermutationMD5Hash,
                                PermutationSHA1Hash,
                                PermutationSHA256Hash,
                                PermutationSHA512Hash,
                                TableName
                                );
                        OutputFile.WriteLine(Query);
                        OutputFile.Close();
                        PermutationCount++;
                        Console.WriteLine(Query);
                    }
                    else
                    {
                        break;
                    }
                }
                DateTime EndTime = DateTime.Now;
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("End Script Generation. Start: {0}, End: {1}", StartTime, EndTime);
                Console.WriteLine("----------------------------------------------------------------");
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "JARVISCRYPTOGRAPHY_CREATERAINBOWTABLEINSERTSTATEMENTS_01");
            }
            return SO;
        }
        public StatusObject PopulateRainbowTable()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject SetDefaultDirectory()
        {
            StatusObject SO = new StatusObject();
            try
            {
                string RootPath;
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Set Up Directory");
                Console.WriteLine("-----------------------------------------------------------------");


                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Set Up Directory");
                Console.WriteLine("-----------------------------------------------------------------");
            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject ClearRainbowTable()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
