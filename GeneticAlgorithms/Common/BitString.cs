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

        public BitString(char[] sol)
        {
            this.Bits = sol;
        }

        public BitString(String s)
        {
            List<char> list = new List<char>();
            foreach(char c in s)
            {
                if (c=='0'||c=='1')
                {
                    list.Add(c);
                }
                else
                {
                    throw new ArgumentException("Input String had a non binary char");
                }
            }
            Bits = list.ToArray();
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

        public BitString Copy()
        {
            BitString copy = new BitString(Bits.Length);
            for (int i = 0; i<Bits.Length; i++)
            {
                copy.SetBitAt(i, Bits[i]);
            }
            return copy;
        }
    }
}
