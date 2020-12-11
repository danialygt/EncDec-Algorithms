using Alghotithms.Extensions;
using System;
using Xunit;

namespace AlghotithmsTest.ExtentionsTest
{
    public class LeftShiftExtentionTest
    {
        [Theory]
        [InlineData(new int[] { 1, 0, 1, 1 }, new int[] { 0, 1, 1, 1 })]
        [InlineData(new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1 },
            new int[] { 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1 })]
        public void LeftShiftTest(int[] input, int[] output)
        {
            Assert.Equal(output, input.LeftShift());
        }



    }
}
