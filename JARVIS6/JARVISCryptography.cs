﻿using System;
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
        private string CryptographyOutputPath = @"C:\JARVIS6\Cryptography";
        private string CryptographyRainbowTableScriptsPath = @"C:\JARVIS6\Cryptography\RainbowTableScripts";
        private JARVISDataSource DataSource { get; set; }
        private Dictionary<string, string> SqlServerHashTypes = new Dictionary<string, string>()
        {
            {"MD5", "32"},
            {"SHA", "40"},
            {"SHA1", "40"},
            {"SHA2_256", "64"},
            {"SHA2_512", "128"}
        };
        private string ASCIICharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890~`!@#$%^&*()_+-={}[]:\"|;'\\<>?,./";
        public JARVISCryptography()
        {
            try
            {
                Directory.CreateDirectory(CryptographyOutputPath);
                Directory.CreateDirectory(CryptographyRainbowTableScriptsPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public StatusObject SetDataSource(string Server, string Database, string UserID, string Password)
        {
            StatusObject SO = new StatusObject();
            try
            {
                
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "JARVISCRYPTOGRAPHY_SETDATASOURCE_01");
            }
            return SO;
        }
        public StatusObject CreateRainbowTableInsertStatements(string FirstCharacter, string WordLength)
        {
            StatusObject SO = new StatusObject();
            try
            {
                char[] Target = ASCIICharacters.ToCharArray();
                char NewFirstCharacter = FirstCharacter.ToCharArray()[0];
                char OldFirstCharacter = Target[0];
                int Temp = Array.IndexOf(Target, NewFirstCharacter);
                Target[0] = NewFirstCharacter;
                Target[Temp] = OldFirstCharacter;
                var Permutations = Target.Select(x => x.ToString());
                int Length = Convert.ToInt32(WordLength);
                BigInteger PermutationCount = BigInteger.Pow(Target.Length, Length);
                for (int i = 0; i < Length - 1; i++)
                {
                    Permutations = Permutations.SelectMany(x => Target, (x, y) => x + y);
                }
                string TableName = String.Format("RAINBOW_{0}_{1}", NewFirstCharacter, WordLength);
                // TODO Replace Files before Writing to Them
                foreach (var Permutation in Permutations)
                {
                    if (Permutation.ToCharArray()[0] == NewFirstCharacter)
                    {
                        
                        string PermutationRange = "";

                        StreamWriter OutputFile = new StreamWriter(
                            String.Format(
                                @"{0}\{1}{2}.txt",
                                CryptographyRainbowTableScriptsPath,
                                TableName,
                                PermutationRange), append: true);
                        MD5 MD5Calculator = MD5.Create();
                        SHA1 SHA1Calculator = SHA1.Create();
                        SHA256 SHA256Calculator = SHA256.Create();
                        SHA512 SHA512Calculator = SHA512.Create();
                        byte[] PermutationBytes = System.Text.Encoding.ASCII.GetBytes("MARINES_54");
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
                        Console.WriteLine(Query);
                    }
                }
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
        public StatusObject ClearRainbowTable()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
    }
}
