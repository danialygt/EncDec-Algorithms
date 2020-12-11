using DES;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace DESTest
{
    public class DESMotorTest
    {
        DESMotor desMotor = new DESMotor();

        #region EncryptionTests
        [Theory]
        [InlineData("0000000100100011010001010110011110001001101010111100110111101111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1000010111101000000100110101010000001111000010101011010000000101"
        )]
        [InlineData("1001011010011000011001010111010001110101011100100111100110011111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "0010011001110101111101001101100010001001100001110100001101110100"
        )]


        [InlineData("0100000101101100011011110110111100100000010100110110110001101101",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1001001000101100011111111100011010011100000101011100100011011011"
        )]

        public void EncryptTest(string plainText, string key, string cipherText) 
        {
            Assert.Equal(cipherText, desMotor.Encrypt(plainText, key));        
        }


        [Theory]
        [InlineData("0000000000000000000000000000000000000000000000000000000000000002")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000a")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000A")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000!")]
        public void Encrypt_WhenText_NotbinaryString_Then_ArgumentException(string text)
        {
            Assert.Throws<ArgumentException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", text));
        }

        [Theory]
        [InlineData("0000000000000000000000000000000000000000000000000000000000000002")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000a")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000A")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000!")]
        public void Encrypt_WhenKey_NotbinaryString_Then_ArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }



        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Encrypt_WhenText_Null_Then_ArgumentNullException(string text)
        {
            Assert.Throws<ArgumentNullException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", text));
        }

        [Theory]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000")]
        [InlineData("00000000000000000000000000000000000000000000000000000000000000000")]
        public void Encrypt_WhenText_Not64bit_Then_ArgumentOutOfRangeException(string text)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => desMotor.Encrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", text));
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

        #endregion

        #region DecryptionTests

        [Theory]
        [InlineData("0000000100100011010001010110011110001001101010111100110111101111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1000010111101000000100110101010000001111000010101011010000000101"
        )]
        [InlineData("1001011010011000011001010111010001110101011100100111100110011111",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "0010011001110101111101001101100010001001100001110100001101110100"
        )]


        [InlineData("0100000101101100011011110110111100100000010100110110110001101101",
                    "0001001100110100010101110111100110011011101111001101111111110001",
                    "1001001000101100011111111100011010011100000101011100100011011011"
        )]

        public void DecryptTest(string plainText, string key, string cipherText)
        {
            Assert.Equal(plainText, desMotor.Decrypt(cipherText, key));
        }

        [Theory]
        [InlineData("0000000000000000000000000000000000000000000000000000000000000002")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000a")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000A")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000!")]
        public void Decrypt_WhenText_NotbinaryString_Then_ArgumentException(string text)
        {
            Assert.Throws<ArgumentException>(() => desMotor.Decrypt(
                text, "0000000000000000000000000000000000000000000000000000000000000000"));
        }

        [Theory]
        [InlineData("0000000000000000000000000000000000000000000000000000000000000002")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000a")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000A")]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000!")]
        public void Decrypt_WhenKey_NotbinaryString_Then_ArgumentException(string key)
        {
            Assert.Throws<ArgumentException>(() => desMotor.Decrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }



        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Decrypt_WhenText_Null_Then_ArgumentNullException(string text)
        {
            Assert.Throws<ArgumentNullException>(() => desMotor.Decrypt(
                text, "0000000000000000000000000000000000000000000000000000000000000000"));
        }

        [Theory]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000")]
        [InlineData("00000000000000000000000000000000000000000000000000000000000000000")]
        public void Decrypt_WhenText_Not64bit_Then_ArgumentOutOfRangeException(string text)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => desMotor.Decrypt(
                text, "0000000000000000000000000000000000000000000000000000000000000000"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Decrypt_WhenKey_Null_Then_ArgumentNullException(string key)
        {
            Assert.Throws<ArgumentNullException>(() => desMotor.Decrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }

        [Theory]
        [InlineData("000000000000000000000000000000000000000000000000000000000000000")]
        [InlineData("00000000000000000000000000000000000000000000000000000000000000000")]
        public void Decrypt_WhenKey_Not64bit_Then_ArgumentOutOfRangeException(string key)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => desMotor.Decrypt(
                "0000000000000000000000000000000000000000000000000000000000000000", key));
        }


        #endregion
    }
}



