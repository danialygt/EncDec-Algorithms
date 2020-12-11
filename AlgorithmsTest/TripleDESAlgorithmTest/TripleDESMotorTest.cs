﻿using Alghotithms.TripleDESAlgorithm;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlghotithmsTest.TripleDESAlgorithmTest
{
    public class TripleDESMotorTest
    {
        TripleDESMotor tDesMotor = new TripleDESMotor();

        #region EncryptionTests
        [Theory]
        [InlineData("0000000100100011010001010110011110001001101010111100110111101111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "0000010010101110111111010010101010001110111110011110011000011001"
        )]
        [InlineData("1001011010011000011001010111010001110101011100100111100110011111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "1011101000000110111100001010110101000000101110110011111000001100"
        )]


        [InlineData("0100000101101100011011110110111100100000010100110110110001101101",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "1000111000011101001111100001001101010100011011101001100001101011"
        )]

        public void EncryptTest(string plainText, string key1, string key2, string cipherText)
        {
            Assert.Equal(cipherText, tDesMotor.Encrypt(plainText, key1, key2));
        }

       
        #endregion

        #region DecryptionTests

        [Theory]
        [InlineData("0000000100100011010001010110011110001001101010111100110111101111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "0000010010101110111111010010101010001110111110011110011000011001"
        )]
        [InlineData("1001011010011000011001010111010001110101011100100111100110011111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "1011101000000110111100001010110101000000101110110011111000001100"
        )]


        [InlineData("0100000101101100011011110110111100100000010100110110110001101101",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1010011001010101010101101011100110011011101111001101110110110101",
                    "1000111000011101001111100001001101010100011011101001100001101011"
        )]

        public void DecryptTest(string plainText, string key1, string key2, string cipherText)
        {
            Assert.Equal(plainText, tDesMotor.Decrypt(cipherText, key1, key2));
        }

       
        #endregion
    }
}