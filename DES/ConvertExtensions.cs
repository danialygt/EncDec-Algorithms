using System;
using System.Collections.Generic;
using System.Text;

namespace DES
{
    public static class ConvertExtensions
    {
        public static string StringToBinaryString(this string data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryStringToString(this string data)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static int[] BinaryStringToIntArray(this string data)
        {
            var tmp = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                tmp[i] = (data[i] == '1') ? 1 : 0;
            }
            return tmp;
        }

        public static bool IsBinaryString(this string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }

            foreach (char item in data)
            {
                if(item != '0' && item != '1')
                {
                    return false;
                }
            }
            return true;
        }
    
        public static int ToDecimalInt(this int[] data)
        {
            int sum = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                if(data[i] == 1)
                {
                    sum += (int)Math.Pow(2, len - 1 - i);
                }
            }
            return sum;
        }
    
        public static int[] ToIntArray4Bit(this int data)
        {
            if(data > 15 || data < 0)
            {
                throw new ArgumentOutOfRangeException("number must between 0 and 15");
            }
            var t = new int[4];
            
            for (int i = 3; i >= 0; i--)
            {
                if(data < 0)
                {
                    data = 0;
                }
                t[i] = data % 2;
                data = (int)(data / 2);
            }

            return t;
        }


        public static string IntArrayToString(this int[] data)
        {
            string sum = "";
            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i].ToString();
            }
            return sum;
        }


    }
}
