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
            Printable printable = new Printable();

            DataGenerator dataGenerator = new DataGenerator();

            ROT13 rot13 = new ROT13();
            ROT13Cycle rot13Cycle = new ROT13Cycle();

            ROT47 rot47 = new ROT47();
            ROT47Cycle rot47Cycle = new ROT47Cycle();

            XOR xor = new XOR();
            XORCycle xorCycle = new XORCycle();



            foreach ((ICipher cipher, ICrypto crypto, IClassifier classifier, StrInt key) in new (ICipher, ICrypto, IClassifier, StrInt)[] { (rot13, rot13Cycle, freqAnalysis, new StrInt(random.Next(26))), (xor, xorCycle, printable, new StrInt(((char)(random.Next(26) + 'A')).ToString())), (rot47, rot47Cycle, printable, new StrInt(random.Next('~' - '!'))) })
            {
                string plaintext = dataGenerator.Generate("EnglishDictionary.txt", 1000, random);
                string ciphertext = cipher.Encrypt(plaintext, key);

                foreach (string maybePlaintext in crypto.GetLikelyPlain(cipher, ciphertext))
                {
                    Console.WriteLine(maybePlaintext);
                    Console.WriteLine(classifier.Classify(maybePlaintext));
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
