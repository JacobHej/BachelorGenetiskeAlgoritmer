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

        public BitString(String s)
        {
            List<char> list = new List<char>();
            foreach (char c in s)
            {
                if (c == '0' || c == '1')
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

        public BitString(Char[] bitString)
        {
            foreach (char c in bitString)
            {
                if (!(c == '0' || c == '1'))
                {
                    throw new ArgumentException("Input String had a non binary char");
                }
            }
            Bits = bitString;
        }

        static public BitString getRandomBitString(int size)
        {
            Char[] bitString = new char[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                if (r.NextDouble()<0.5)
                {
                    bitString[i] = '0';
                }
                else
                {
                    bitString[i] = '1';
                }
            }
            return new BitString(bitString);
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
            Char[] bitString = new char[Bits.Length];
            Bits.CopyTo(bitString,0);
            return new BitString(bitString);
        }
    }
}
