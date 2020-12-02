using DES;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace DESTest
{
    public class ConvertExtensionsTest
    {
        [Theory]
        [InlineData("A", "01000001")]
        [InlineData("Hello", "0100100001100101011011000110110001101111")]
        [InlineData("5164896561",
            "00110101001100010011011000110100001110000011100100110110001101010011011000110001")]
        [InlineData("sdjkl as$34%d0oioa os",
            "011100110110010001101010011010110110110000100000011000010111001100100100001100110011010000100101011001000011000001101111011010010110111101100001001000000110111101110011")]
        [InlineData("", "")]
        public void StringToBinaryStringTest(string text, string binaryText)
        {
            Assert.Equal(binaryText, text.StringToBinaryString());
        }



        [Theory]
        [InlineData("01000001", "A")]
        [InlineData("0100100001100101011011000110110001101111", "Hello")]
        [InlineData("00110101001100010011011000110100001110000011100100110110001101010011011000110001",
            "5164896561")]
        [InlineData("011100110110010001101010011010110110110000100000011000010111001100100100001100110011010000100101011001000011000001101111011010010110111101100001001000000110111101110011", 
            "sdjkl as$34%d0oioa os")]
        [InlineData("", "")]
        public void BinaryStringToStringTest(string binaryText, string text)
        {
            Assert.Equal(text, binaryText.BinaryStringToString());
        }


    }
}
