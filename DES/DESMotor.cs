using System;
using System.Collections.Generic;

namespace DES
{
    public class DESMotor
    {
        

        public string Encrypt(string plainText, string stringKey)
        {
            int[] finalRound = new int[64];
            int[][] lText = new int[17][] {
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32]
                                            };
            int[][] rText = new int[17][] {
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32]
                                            };

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

            var _subkeys = GenerateSubKeys(stringKey);

            InitialPermutationAndSeparate(plainText.BinaryStringToIntArray(), lText, rText);

            // do 16 round 
            for (int i = 1; i <= 16; i++)
            {
                int[] result = function(rText[i - 1], _subkeys[i - 1]);
                for (int j = 0; j < 32; j++)
                {
                    lText[i][j] = rText[i - 1][j];
                    rText[i][j] = lText[i - 1][j] ^ result[j];
                    if (i == 16)
                    { // after last round L and R must be Swap!
                        finalRound[j] = rText[16][j];
                        finalRound[j + 32] = lText[16][j];
                    }
                }
            }

            var finalPermutation = FinalPermutation(finalRound);

            return finalPermutation.IntArrayToString();
        }

        public string Decrypt(string cipherText, string stringKey)
        {
            int[] finalRound = new int[64];
            int[][] lTextD = new int[17][] {
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32]
                                            };
            int[][] rTextD = new int[17][] {
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32],
                                                new int[32]
                                            };


            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentNullException("cipher text is empty!");
            }
            if (cipherText.Length != 64)
            {
                throw new ArgumentOutOfRangeException("cipher text must be 64 bit");
            }
            if (!cipherText.IsBinaryString())
            {
                throw new ArgumentException("cipher text must be a string of binaray numbers");
            }

            var _subkeys = GenerateSubKeys(stringKey);


            InitialPermutationAndSeparate(cipherText.BinaryStringToIntArray(), lTextD, rTextD);


            // do 16 round 
            for (int i = 1; i <= 16; i++)
            {
                int[] result = function(rTextD[i - 1], _subkeys[16 - i]);
                for (int j = 0; j < 32; j++)
                {
                    lTextD[i][j] = rTextD[i - 1][j];
                    rTextD[i][j] = lTextD[i - 1][j] ^ result[j];
                    if (i == 16)
                    { // after last round L and R must be Swap!
                        finalRound[j] = rTextD[16][j];
                        finalRound[j + 32] = lTextD[16][j];
                    }
                }
            }

            var finalPermutation = FinalPermutation(finalRound);

            return finalPermutation.IntArrayToString();
        }



        private int[][] GenerateSubKeys(string stringKey)
        {
            int[] key = new int[64];
            int[] keyPlus = new int[56];
            int[,] cKeys = new int[17, 28];
            int[,] dKeys = new int[17, 28];
            int[][] _subkeys = new int[16][] {
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48],
                                                new int[48]
                                            };

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
                    _subkeys[i][k] = thisKey[DESFixedData.PermutedChoice2[k] - 1];
                }
            }
            return _subkeys;
        }

        private static void InitialPermutationAndSeparate(int[] text, int[][] lText, int[][] rText)
        {
            int[] initialPermutation = new int[64];
            for (int i = 0; i < DESFixedData.InitialPermutation.Length; i++)
            {
                // do initial permutation
                initialPermutation[i] = text[DESFixedData.InitialPermutation[i] - 1];
                // make separate!
                if (i < 32)
                {
                    lText[0][i] = initialPermutation[i];
                }
                else
                {
                    rText[0][i - 32] = initialPermutation[i];
                }
            }
        }

        private int[] function(int[] rText, int[] _subkey)
        {
            int[] eRTextXorSubkeys = new int[48];
            int[,] BArray = new int[8, 6];
            int[][] _4bitOfSbox = new int[8][];
            int[] tmp = new int[32];
            int[] final = new int[32];


            // xor and make b array
            for (int i = 0; i < DESFixedData.EBitSelection.Length; i++)
            {
                eRTextXorSubkeys[i] = rText[DESFixedData.EBitSelection[i] - 1] ^ _subkey[i];
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

        private static int[] FinalPermutation(int[] finalRound)
        {
            int[] finalPermutation = new int[64];
            //last permutataion
            for (int i = 0; i < DESFixedData.FinalPermutation.Length; i++)
            {
                finalPermutation[i] = finalRound[DESFixedData.FinalPermutation[i] - 1];
            }
            return finalPermutation;
        }

    }
}
