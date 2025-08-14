using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace nea_prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            FreqAnalysis freqAnalysis = new FreqAnalysis();
            DataGenerator dataGenerator = new DataGenerator();
            ROT13 rot13 = new ROT13();
            ROT13Cycle rot13Cycle = new ROT13Cycle();

            string plaintext = dataGenerator.Generate("EnglishDictionary.txt", 1000, random);
            string ciphertext = rot13.Encrypt(plaintext, new StrInt(random.Next(26)));

            foreach (string maybePlaintext in rot13Cycle.GetLikelyPlain(rot13, ciphertext))
            {
                Console.WriteLine(maybePlaintext);
                Console.WriteLine(freqAnalysis.Classify(maybePlaintext));
                Console.WriteLine();
            }
            Console.ReadKey();

            Console.Clear();

        }
    }
}
