using Alghotithms.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace AlghotithmsTest.ExtentionsTest
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


        [Theory]
        [InlineData("01000001", new int[] { 0, 1, 0, 0, 0, 0, 0, 1 })]
        [InlineData("0100100001100101011011000110110001101111",
            new int[] { 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1 })]
        [InlineData("", new int[] { })]
        public void BinaryStringToIntArrayTest(string binaryText, int[] binaryArray)
        {
            Assert.Equal(binaryArray, binaryText.BinaryStringToIntArray());
        }

        [Theory]
        [InlineData("010", true)]
        [InlineData("000", true)]
        [InlineData("111", true)]
        [InlineData("0F1", false)]
        [InlineData("@^", false)]
        [InlineData("", false)]
        public void IsBinaryStringTest(string binaryText, bool isBinaryString)
        {
            Assert.Equal(isBinaryString, binaryText.IsBinaryString());
        }

        [Theory]
        [InlineData(new int[] { 0, 1 }, 1)]
        [InlineData(new int[] { 1, 0 }, 2)]
        [InlineData(new int[] { 1, 1 }, 3)]
        [InlineData(new int[] { 0, 0 }, 0)]
        [InlineData(new int[] { 1, 1, 1 }, 7)]
        [InlineData(new int[] { 1, 1, 1, 1 }, 15)]
        public void ToDecimalIntTest(int[] intArray, int decimalInt)
        {
            Assert.Equal(decimalInt, intArray.ToDecimalInt());
        }

        [Theory]
        [InlineData(1, new int[] { 0, 0, 0, 1 })]
        [InlineData(2, new int[] { 0, 0, 1, 0 })]
        [InlineData(3, new int[] { 0, 0, 1, 1 })]
        [InlineData(0, new int[] { 0, 0, 0, 0 })]
        [InlineData(7, new int[] { 0, 1, 1, 1 })]
        [InlineData(15, new int[] { 1, 1, 1, 1 })]
        [InlineData(13, new int[] { 1, 1, 0, 1 })]
        [InlineData(14, new int[] { 1, 1, 1, 0 })]
        public void ToIntArray4BitTest(int decimalInt, int[] intArray)
        {
            Assert.Equal(intArray, decimalInt.ToIntArray4Bit());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(17)]
        [InlineData(16)]
        public void Exception_ToIntArray4BitTest(int decimalInt)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => decimalInt.ToIntArray4Bit());
        }


        [Theory]
        [InlineData(new int[] { 0, 1 }, "01")]
        [InlineData(new int[] { 1, 0 }, "10")]
        [InlineData(new int[] { 1, 1 }, "11")]
        [InlineData(new int[] { 0, 0 }, "00")]
        [InlineData(new int[] { 1, 1, 1 }, "111")]
        [InlineData(new int[] { 1, 1, 1, 1 }, "1111")]
        public void IntArrayToStringTest(int[] intArray, string str)
        {
            Assert.Equal(str, intArray.IntArrayToString());
        }


    }
}
