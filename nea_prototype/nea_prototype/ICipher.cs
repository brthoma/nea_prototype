using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public interface ICipher
    {
        string Encrypt(string plaintext, StrInt key);
        string Decrypt(string ciphertext, StrInt key);
    }


    public class NullCipher : ICipher
    {
        public string Encrypt(string plaintext, StrInt key)
        {
            return plaintext;
        }
        public string Decrypt(string ciphertext, StrInt key)
        {
            return ciphertext;
        }
    }

    public class ROT47 : ICipher
    {
        public string Encrypt(string plaintext, StrInt bKey)
        {
            int key = bKey.ToInt();
            string ciphertext = "";
            foreach (char c in plaintext)
            {
                char newChar;
                if (c >= 33 && c <= 126)
                {
                    newChar = (char)(33 + (c + key - 33) % (126 - 33 + 1));
                }
                else
                {
                    newChar = c;
                }
                ciphertext += newChar;
            }
            return ciphertext;
        }
        public string Decrypt(string ciphertext, StrInt bKey)
        {
            int key = bKey.ToInt();
            string plaintext = "";
            foreach (char c in ciphertext)
            {
                char newChar;
                if (c >= 33 && c <= 126)
                {
                    newChar = (char)(33 + (c + (126 - 33 + 1) - key - 33) % (126 - 33 + 1));
                }
                else
                {
                    newChar = c;
                }
                plaintext += newChar;
            }
            return plaintext;
        }
    }

    public class ROT13 : ICipher
    {
        public string Encrypt(string plaintext, StrInt bKey)
        {
            int key = bKey.ToInt();
            string ciphertext = "";
            foreach (char c in plaintext)
            {
                char newChar;
                if (c >= 'A' && c <= (int)'Z')
                {
                    newChar = (char)(65 + (c + key - 65) % 26);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    newChar = (char)(97 + (c + key - 97) % 26);
                }
                else
                {
                    newChar = c;
                }
                ciphertext += newChar;
            }
            return ciphertext;
        }
        public string Decrypt(string ciphertext, StrInt bKey)
        {
            //StrInt bEKey = new StrInt(bKey.ToInt() * -1);    Not really sure why this doesnt work but ok
            StrInt bEKey = new StrInt((26 - bKey.ToInt()) % 26);
            return Encrypt(ciphertext, bEKey);
            int key = bKey.ToInt();
            string plaintext = "";
            foreach (char c in ciphertext)
            {
                char newChar;
                if (c >= 'A' && c <= 'Z')
                {
                    newChar = (char)(65 + (c + 26 - key - 65) % 26);
                }
                else if (c >= 'a' && c <= 'z')
                {
                    newChar = (char)(97 + (c + 26 - key - 97) % 26);
                }
                else
                {
                    newChar = c;
                }
                plaintext += newChar;
            }
            return plaintext;
        }
    }

    public class XOR : ICipher
    {
        private char CharXOR(char plainC, char keyC)
        {
            char cipherC = (char)(plainC ^ keyC);
            return cipherC;
        }
        public string Encrypt(string plaintext, StrInt bKey)
        {
            string key = bKey.ToString();
            string ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                ciphertext += CharXOR(plaintext[i], key[i % key.Length]);
            }
            return ciphertext;
        }
        public string Decrypt(string ciphertext, StrInt bKey)
        {
            return Encrypt(ciphertext, bKey);
        }
    }

}

