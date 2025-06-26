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
}
