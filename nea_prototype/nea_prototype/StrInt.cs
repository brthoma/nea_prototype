using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public class StrInt
    {
        private byte[] value;
        private char type;
        public StrInt(byte[] value)
        {
            this.value = value;
            type = 'b';
        }
        public StrInt(int value)
        {
            this.value = BitConverter.GetBytes(value);
            type = 'i';
        }
        public StrInt(string value)
        {
            //this.value = Encoding.Unicode.GetBytes(value);
            this.value = Encoding.UTF8.GetBytes(value);
            type = 's';
        }
        public byte[] ToBytes()
        {
            return value;
        }
        public int ToInt()
        {
            if (type != 'i') throw new Exception("Value cannot be cast to this type.");
            return BitConverter.ToInt32(value, 0);
        }
        public override string ToString()
        {
            if (type != 's') throw new Exception("Value cannot be cast to this type");
            //return Encoding.Unicode.GetString(value); THIS IS A DIFFERENT CHARACTER SET AND iS NOT COMPATIBLE WITH ASCII
            return Encoding.UTF8.GetString(value);
        }
    }
}
