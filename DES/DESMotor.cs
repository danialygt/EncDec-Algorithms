using System;

namespace DES
{
    public class DESMotor
    {
        private int[,] _subkeys = new int[16, 48];



        private void GenerateSubKeys(string stringKey)
        {
            int[] key = new int[64];
            int[] keyPlus = new int[56];
            int[,] cKeys = new int[17, 28];
            int[,] dKeys = new int[17, 28];



            if (string.IsNullOrEmpty(stringKey))
            {
                throw new ArgumentNullException("Key is empty!");
            }
            if (stringKey.Length != 64)
            {
                throw new ArgumentOutOfRangeException("Key must be 64 bit");
            }

            // convert string to int[]
            for (int i = 0; i < 64; i++)
            {
                key[i] = (stringKey[i] == '1') ? 1 : 0;
            }
            // do pc1 and (c0, d0) 
            for (int i = 0; i < DESFixedData.PermutedChoice1.Length; i++)
            {
                //pc1
                keyPlus[i] = key[DESFixedData.PermutedChoice1[i] - 1];
                //(c0, d0)
                if (i < 28)
                {
                    cKeys[0, i] = keyPlus[i];
                }
                else
                {
                    dKeys[0, i - 28] = keyPlus[i];
                }
            }
            // make c and d !
            for (int i = 1; i <= 16; i++)
            {
                int[] cKey = new int[28];
                int[] dKey = new int[28];

                for (int k = 0; k < 28; k++)
                {
                    cKey[k] = cKeys[i - 1, k];
                    dKey[k] = dKeys[i - 1, k];
                }
                for (int j = 0; j < DESFixedData.LeftShift[i - 1]; j++)
                {
                    cKey.LeftShift();
                    dKey.LeftShift();
                }
                for (int k = 0; k < 28; k++)
                {
                    cKeys[i, k] = cKey[k];
                    dKeys[i, k] = dKey[k];
                }
            }
            // do pc2
            for (int i = 0; i < 16; i++)
            {
                int[] thisKey = new int[56];
                for (int j = 0; j < 28; j++)
                {
                    thisKey[j] = cKeys[i + 1, j];
                    thisKey[j + 28] = dKeys[i + 1, j];
                }
                for (int k = 0; k < DESFixedData.PermutedChoice2.Length; k++)
                {
                    _subkeys[i, k] = thisKey[DESFixedData.PermutedChoice2[k] - 1];
                }
            }
        }


        public string Encrypt(string plainText, string stringKey)
        {
            GenerateSubKeys(stringKey);



            return "ciphertexemon";
        }

        public string Decrypt(string cipherText, string stringKey)
        {

            return "plaittexemon";
        }


    }
}
