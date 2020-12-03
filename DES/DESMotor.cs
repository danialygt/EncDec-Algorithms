using System;
using System.Collections.Generic;

namespace DES
{
    public class DESMotor
    {
        private int[,] _subkeys = new int[16, 48];




        public string Encrypt(string plainText, string stringKey)
        {
            int[] text = new int[64];
            int[] initialPermutation = new int[64];
            int[] finalRound = new int[64];
            int[] finalPermutation = new int[64];
            int[,] lText = new int[17, 32];
            int[,] rText = new int[17, 32];

            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException("plaint text is empty!");
            }
            if (plainText.Length != 64)
            {
                throw new ArgumentOutOfRangeException("plaint text must be 64 bit");
            }
            if (!plainText.IsBinaryString()) 
            {
                throw new ArgumentException("plain text must be a string of binaray numbers");
            }

            GenerateSubKeys(stringKey);

            text = plainText.BinaryStringToIntArray();
            // do initial permutation
            for (int i = 0; i < DESFixedData.InitialPermutation.Length; i++)
            {
                initialPermutation[i] = text[DESFixedData.InitialPermutation[i] - 1];
                if (i < 32)
                {
                    lText[0, i] = initialPermutation[i];
                }
                else
                {
                    rText[0, i - 32] = initialPermutation[i];
                }
            }

            // do 16 round 
            for (int i = 1; i <= 16; i++)
            {
                int[] result = function(rText, i);
                for (int j = 0; j < 32; j++)
                {
                    lText[i, j] = rText[i - 1, j];
                    rText[i, j] = lText[i - 1, j] ^ result[j];
                    if(i == 16)
                    { // after last round L and R must be Swap!
                        finalRound[j] = rText[16, j];
                        finalRound[j + 32] = lText[16, j];
                    }
                }
            }

            //last permutataion
            for (int i = 0; i < DESFixedData.FinalPermutation.Length; i++)
            {
                finalPermutation[i] = finalRound[DESFixedData.FinalPermutation[i] - 1];
            }

            return finalPermutation.IntArrayToString();
        }

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
            if (!stringKey.IsBinaryString())
            {
                throw new ArgumentException("key must be a string of binaray numbers");
            }


            key = stringKey.BinaryStringToIntArray();
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

        private int[] function(int[,] rText, int n)
        {
            int[] eRTextXorSubkeys = new int[48];
            int[,] BArray = new int[8, 6];
            int[][] _4bitOfSbox = new int[8][];
            int[] tmp = new int[32];
            int[] final = new int[32];


            // xor and make b array
            for (int i = 0; i < DESFixedData.EBitSelection.Length; i++)
            {
                eRTextXorSubkeys[i] = rText[n - 1, DESFixedData.EBitSelection[i] - 1] ^ _subkeys[n-1, i];
                BArray[(int)(i / 6), (i % 6)] = eRTextXorSubkeys[i];
            }

            // get Sboxes
            for (int i = 0; i < 8; i++)
            {
                int row = (new int[2] { BArray[i, 0], BArray[i, 5] }).ToDecimalInt();
                int column = (new int[4] { BArray[i, 1], BArray[i, 2], 
                    BArray[i, 3], BArray[i, 4] }).ToDecimalInt();

                _4bitOfSbox[i] = (DESFixedData.SBoxes[i][row, column]).ToIntArray4Bit();                
            }
            for (int i = 0; i < _4bitOfSbox.Length; i++)
            {
                for (int j = 0; j < _4bitOfSbox[i].Length; j++)
                {
                    tmp[i * 4 + j] = _4bitOfSbox[i][j];
                }
            }

            // permutation P
            for (int i = 0; i < DESFixedData.PermutationP.Length; i++)
            {
                final[i] = tmp[DESFixedData.PermutationP[i] - 1];
            }

            return final;
        }




        public string Decrypt(string cipherText, string stringKey)
        {

            return "plaittexemon";
        }



    
    }
}
