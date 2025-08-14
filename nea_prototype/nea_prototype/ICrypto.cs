using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public interface ICrypto
    {
        IEnumerable<string> GetLikelyPlain(ICipher cipher, string ciphertext);
    }

    public class ROT13Cycle : ICrypto
    {
        public IEnumerable<string> GetLikelyPlain(ICipher rot13Cipher, string ciphertext)
        {
            for (int i = 0; i < 26; i++)
            {
                yield return rot13Cipher.Decrypt(ciphertext, new StrInt(i));
            }
        }
    }

    public class XORCycle : ICrypto
    {
        public IEnumerable<string> GetLikelyPlain(ICipher xorCipher, string ciphertext)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                yield return xorCipher.Decrypt(ciphertext, new StrInt(c.ToString()));
            }
        }
    }

    public class ROT47Cycle : ICrypto
    {
        public IEnumerable<string> GetLikelyPlain(ICipher rot47Cipher, string ciphertext)
        {
            for (int i = 0; 0 <= '~' - '!';  i++)
            {
                yield return rot47Cipher.Decrypt(ciphertext, new StrInt(i));
            }
        }
    }
}
