﻿using DES;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace DESTest
{
    public class DESMotorTest
    {
        DESMotor desMotor = new DESMotor();
        
        

        [Theory(Skip = "felan naresidam!")]
        [InlineData("", "", "")]
        public void EncryptTest(string plainText, string key, string cipherText) 
        {
            Assert.Equal(cipherText, desMotor.Encrypt(plainText, key));
        
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Encrypt_WhenKey_Null_Then_ArgumentNullException(string key)
        {
            Assert.Throws<ArgumentNullException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }

        [Theory]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000")]
        [InlineData("00000000000000000000000000000000000000000000000000000000000000000")]
        public void Encrypt_WhenKey_Not64bit_Then_ArgumentOutOfRangeException(string key)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }






        [Theory(Skip = "ib test besorate koli bayad anjam beshe!")]
        [InlineData("0001001100110100010101110111100110011011101111001101111111110001")]
        public void testkey(string key)
        {
            int[] jvbkplus = { 1,1,1,1,0,0,0, 0,1,1,0,0,1,1, 0,0,1,0,1,0,1, 0,1,0,1,1,1,1,
                0,1,0,1,0,1,0, 1,0,1,1,0,0,1, 1,0,0,1,1,1,1, 0,0,0,1,1,1,1 };

            int[] jvbC0 = {1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1};
            int[] jvbD0 = {0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1};

            int[,] jvbC = {
                            {1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1}, 
                            {1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1},
                            {1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1},
                            {0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1},
                            {0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0},
                            {1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0},
                            {0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1},
                            {1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0},
                            {0,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1},
                            {0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0},
                            {0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1},
                            {0,1,0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1},
                            {0,1,0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1},
                            {0,1,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1},
                            {1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1},
                            {1,1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1},
                            {1,1,1,1,0,0,0,0,1,1,0,0,1,1,0,0,1,0,1,0,1,0,1,0,1,1,1,1},
                          };
            int[,] jvbD = {
                            {0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1},
                            {1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0},
                            {0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1},
                            {0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1},
                            {0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1},
                            {0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1},
                            {1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1},
                            {0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0},
                            {1,0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1},
                            {0,0,1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1},
                            {1,1,1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0},
                            {1,1,0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1},
                            {0,0,0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1},
                            {0,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0},
                            {1,1,1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1},
                            {1,0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1},
                            {0,1,0,1,0,1,0,1,0,1,1,0,0,1,1,0,0,1,1,1,1,0,0,0,1,1,1,1}
                          };

            int[,] _subkeys = {
                                {0,0,0,1,1,0,1,1,0,0,0,0,0,0,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,1,1,1,0,0,1,0},
                                {0,1,1,1,1,0,0,1,1,0,1,0,1,1,1,0,1,1,0,1,1,0,0,1,1,1,0,1,1,0,1,1,1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,1},
                                {0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,0,1,0,0,0,1,0,1,0,0,1,0,0,0,0,1,0,1,1,0,0,1,1,1,1,1,0,0,1,1,0,0,1},
                                {0,1,1,1,0,0,1,0,1,0,1,0,1,1,0,1,1,1,0,1,0,1,1,0,1,1,0,1,1,0,1,1,0,0,1,1,0,1,0,1,0,0,0,1,1,1,0,1},
                                {0,1,1,1,1,1,0,0,1,1,1,0,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,0,1,0,1,1,0,1,0,1,0,0,1,1,1,0,1,0,1,0,0,0},
                                {0,1,1,0,0,0,1,1,1,0,1,0,0,1,0,1,0,0,1,1,1,1,1,0,0,1,0,1,0,0,0,0,0,1,1,1,1,0,1,1,0,0,1,0,1,1,1,1},
                                {1,1,1,0,1,1,0,0,1,0,0,0,0,1,0,0,1,0,1,1,0,1,1,1,1,1,1,1,0,1,1,0,0,0,0,1,1,0,0,0,1,0,1,1,1,1,0,0},
                                {1,1,1,1,0,1,1,1,1,0,0,0,1,0,1,0,0,0,1,1,1,0,1,0,1,1,0,0,0,0,0,1,0,0,1,1,1,0,1,1,1,1,1,1,1,0,1,1},
                                {1,1,1,0,0,0,0,0,1,1,0,1,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,0,0,1,1,1,1,0,0,0,0,0,0,1},
                                {1,0,1,1,0,0,0,1,1,1,1,1,0,0,1,1,0,1,0,0,0,1,1,1,1,0,1,1,1,0,1,0,0,1,0,0,0,1,1,0,0,1,0,0,1,1,1,1},
                                {0,0,1,0,0,0,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,0,1,1,1,1,0,1,1,1,1,0,1,1,0,1,0,0,1,1,1,0,0,0,0,1,1,0},
                                {0,1,1,1,0,1,0,1,0,1,1,1,0,0,0,1,1,1,1,1,0,1,0,1,1,0,0,1,0,1,0,0,0,1,1,0,0,1,1,1,1,1,1,0,1,0,0,1},
                                {1,0,0,1,0,1,1,1,1,1,0,0,0,1,0,1,1,1,0,1,0,0,0,1,1,1,1,1,1,0,1,0,1,0,1,1,1,0,1,0,0,1,0,0,0,0,0,1},
                                {0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,1,1,0,1,1,0,1,1,1,1,1,1,1,0,0,1,0,1,1,1,0,0,1,1,1,0,0,1,1,1,0,1,0},
                                {1,0,1,1,1,1,1,1,1,0,0,1,0,0,0,1,1,0,0,0,1,1,0,1,0,0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,0,0,0,0,1,0,1,0},
                                {1,1,0,0,1,0,1,1,0,0,1,1,1,1,0,1,1,0,0,0,1,0,1,1,0,0,0,0,1,1,1,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1}
                              };

            //desMotor.GenerateSubKeys(key);
            //Assert.Equal(_subkeys, desMotor._subkeys);
        }
    }
}



