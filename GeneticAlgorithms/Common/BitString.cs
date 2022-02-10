using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BitString
    {
        public char[] Bits;

        public BitString(int size)
        {
            Bits = new char[size];

            for (int i = 0; i < Bits.Length; i++)
            {
                Bits[i] = '0';
            }
        }

        public void FlipBitAt(int index)
        {
            if(index < Bits.Length)
            {
                Bits[index] = Bits[index].Equals('1') ? '0' : '1';
            }
        }

        public void SetBitAt(int index, char val)
        {
            if (index < Bits.Length)
            {
                Bits[index] = val;
            }
        }
    }
}
