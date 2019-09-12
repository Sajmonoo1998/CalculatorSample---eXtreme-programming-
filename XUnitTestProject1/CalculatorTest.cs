

using CalculatorExample;
using System;

using Xunit;

namespace CalculatorXUnitTestProject1
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(0,int.MinValue, int.MaxValue)]
        [InlineData(0, int.MinValue, int.MaxValue)]
        [InlineData(5,0,5)]
        public void Add_Valid_Input(int initial,int x,int expected)
        {
            ICalculator c = new Calculator();
            c.Add(initial);
            c.Add(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Add_Overflow_Expect_OverflowException()
        {
        // Arrange
        ICalculator c = new Calculator();
        c.Add(1);
            // Act + Assert
        var e = Assert.Throws<OverflowException>(() =>
            {
                c.Add(int.MaxValue);
            });

            Assert.True(e.Message == "Overflow by addition");
        }


        [Fact]
        public void Add_Underflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(1);
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Add(int.MinValue);
            });

            Assert.True(e.Message == "Overflow by addition");
        }

    }
}
