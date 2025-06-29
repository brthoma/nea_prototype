using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            ROT47 rot47 = new ROT47();
            //StrInt key = new StrInt(47);
            //StrInt negKey = new StrInt(-47);
            //string encrypted = rot47.Encrypt("~ABCabcXYZxyz123890!.,;()~", key);
            //Console.WriteLine(encrypted);
            //Console.WriteLine(rot47.Encrypt(encrypted, negKey));

            XOR xor = new XOR();
            //StrInt key = new StrInt("HELLO");
            //string encrypted = xor.Encrypt("~ABCabcXYZxyz123890!.,; ()~", key);
            //Console.WriteLine(encrypted);
            //Console.WriteLine(xor.Decrypt(encrypted, key));

            FreqAnalysis freqAnalysis = new FreqAnalysis();
            //Console.WriteLine(freqAnalysis.Classify("The purpose of Experiment V was to determine the upper bound for the accuracy of the set of classification methods that they were using. They did this by using an ‘Oracle’ classifier, which allowed them to fuse the set - the ensemble - of classifiers. For each of a range of inputs, the true value was compared with the results yielded by each individual classifier. The theoretical upper bound for accuracy is Poracle = 1 - P(all classifiers incorrect). This works as it assumes that the theoretical ensemble chooses to side with a correct classifier every time if there is one. An ensemble of classifiers will not always meet the threshold maximum and in fact this is rare. They used the Oracle classifier in order to aid with comparison between the methods and evaluate the benefits and drawbacks of certain classifier combinations. This evaluation allowed them to find certain classifier ensembles that provide better results for each language. This would be a helpful stage to consider including in my investigation. It could allow me to compare different classifier ensembles and to consider each ensemble’s theoretical range of  maximum performance across the different ciphers. It could also help me to find a basis for a combination of the classifiers to use for each cipher. However, Malmasi and Dras appear to rely on a majority rules ensemble in which each classifier votes in one direction and the class with the majority of votes from the classifiers selected to make up the ensemble is selected overall. Another alternative that I could consider is whether a proportional majority voting system would provide more accurate results, where each classifier is given a different influence over the final result and the majority rules."));
            //Console.WriteLine(freqAnalysis.Classify("JKLHhaf;kjsfaiu;abkjv;ka; nhvuhiuhkadkjoriuiewuhkfj;akjsdhfnvankvahfiwhekfakjfcacniefhkakj;kjh;ahs;kjskjsf;kjkjkjhfaskjfhjksfkjkslk;adf;asjnfopianoifaknf;kjaspoinvoain a jaf;f;k fiaeoihfihak;; v;kafnaoi h ;kadf;afoiha;fkjh;kjvkhdhd;i;jkvnkjv ;a ;hfh; a;dfhi;ush;feh;ehkaefkjoi;efj;lefj;eejioeaj;iaoej;oif;aoijf;oijae;oijef;oiealj;vn;ak ;vjlkjlkjvljiovh;ioahgo;gih;oi;oiehoih;iottkndaka;vkvnkna;kdhf;oiehoieho;ieh;oiho;fi;knv"));

            DataGenerator dataGenerator = new DataGenerator();
            string txt = dataGenerator.Generate("EnglishDictionary.txt", 60, random);
            //Console.WriteLine(txt);
            //Console.WriteLine(freqAnalysis.Classify(txt));
            //Console.WriteLine(freqAnalysis.Classify(rot47.Encrypt(txt, new StrInt(random.Next(26)))));
            //Console.WriteLine(freqAnalysis.Classify(xor.Encrypt(dataGenerator.Generate("EnglishDictionary.txt", 500, random), new StrInt(dataGenerator.Generate("EnglishDictionary.txt", 10, random))))); //for an XOR, the resulting text is usually mostly hexadecimal because of the way the encryption works -> not always in alphabet
            //Console.WriteLine(freqAnalysis.Classify("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxwwwwwwwwwwwwwwwwwwwwwwqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqquuuuuu"));
            string encr;
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

            //while (true)
            //{
            //    txt = dataGenerator.Generate("EnglishDictionary.txt", 100, random);
            //    Console.WriteLine(txt);
            //    Console.WriteLine(freqAnalysis.Classify(txt) * 100 + "%");
            //    encr = rot13.Encrypt(txt, new StrInt(random.Next(1, 26)));
            //    Console.WriteLine(encr);
            //    Console.WriteLine(freqAnalysis.Classify(encr) * 100 + "%");
            //    Console.ReadKey();
            //}

            //Console.ReadKey();

        }
    }
}
