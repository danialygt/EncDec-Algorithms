using System;
using System.Collections.Generic;
using System.Text;

namespace DES
{
    public static class LeftShiftExtention
    {
        public static int[] LeftShift (this int[] data)
        {
            int first = data[0];
            for (int i = 0; i < data.Length - 1 ; i++)
            {
                data[i] = data[i + 1];
            }
            data[data.Length - 1] = first;
            return data;
        }

    }
}
