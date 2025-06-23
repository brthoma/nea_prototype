using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public interface ICrypto
    {
        string GetLikelyKey(string ciphertext);
    }
}
