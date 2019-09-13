

using CalculatorExample;
using System;

using Xunit;

namespace CalculatorXUnitTestProject1
{
    public class CalculatorTest
    {


        // Adding
        [Theory]
        [InlineData(0, int.MinValue, int.MinValue)] 
        [InlineData(0, int.MaxValue, int.MaxValue)] 
        [InlineData(1_000_000, 1_000_000, 2_000_000)] 
        [InlineData(5, 0, 5)]
        [InlineData(123,123,246)]
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

            Assert.True(e.Message == "Overflow by addition.");
        }


        [Fact]
        public void Add_Underflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(-1);
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Add(int.MinValue);
            });

            Assert.True(e.Message == "Underflow by addition.");
        }
        /////////
        //Subtracting
        [Theory]
        [InlineData(int.MaxValue, 1, int.MaxValue-1)]
        [InlineData(5000, 3500, 1500)]
        [InlineData(-1_000_000, 1_000_000, -2_000_000)]
        [InlineData(-5, 4, -9)]
        [InlineData(246, -123, 369)]
        public void Subtract_Valid_Input(int initial, int x, int expected)
        {
            ICalculator c = new Calculator();
            c.Add(initial);
            c.Subtract(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Subtract_Overflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(int.MinValue);  
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {                               
                c.Subtract(1);  
                
            });

            Assert.True(e.Message == "Overflow by subtraction.");
        }


        [Fact]
        public void Subtract_Underflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(1); 
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Subtract(-int.MaxValue); 
            });

            Assert.True(e.Message == "Underflow by subtraction.");
        }
        /////////////
        ///Divide
        [Theory]
        [InlineData(10000, 4, 2500)]
        [InlineData(5000, 2, 2500)]
        [InlineData(-1_000_000, 1000, -1000)]
        [InlineData(10, 5, 2)]
        [InlineData(333, 3, 111)]
        public void Divide_Valid_Input(int initial, int x, int expected)
        {
            ICalculator c = new Calculator();
            c.Add(initial);
            c.Divide(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Divide_Expect_DivideByZeroException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(int.MinValue);
            // Act + Assert
            var e = Assert.Throws<DivideByZeroException>(() =>
            {                              
                c.Divide(0);  

            });

            Assert.True(e.Message == "You can't divide by 0.");
        }
        //////
        ///MULTIPLY
        [Theory]
        [InlineData(10000, 4, 40000)]
        [InlineData(5000, 2, 10000)]
        [InlineData(-1_000_000, 10, -10_000_000)]
        [InlineData(123_456, 12, 1_481_472)]
        [InlineData(333333, 333, 110_999_889)]
        public void Multiply_Valid_Input(int initial, int x, int expected)
        {
            ICalculator c = new Calculator();
            c.Add(initial);
            c.Multiply(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Multiply_Overflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(int.MinValue+10000);
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Multiply(2);

            });
            c.Reset();
            c.Add(2);
            // Act + Assert
            var e2 = Assert.Throws<OverflowException>(() =>
            {
                c.Multiply(int.MinValue + 15000);

            });

            Assert.True(e.Message == "Overflow by multiplying." && e2.Message == "Overflow by multiplying.");
        }
        [Fact]
        public void Multiply_Underflow_Expect_OverflowException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(int.MaxValue-10000);
            // Act + Assert
            var e = Assert.Throws<OverflowException>(() =>
            {
                c.Multiply(2);

            });
            c.Reset();
            c.Add(2);
            // Act + Assert
            var e2 = Assert.Throws<OverflowException>(() =>
            {
                c.Multiply(int.MaxValue - 15000);

            });

            Assert.True(e.Message == "Underflow by multiplying." && e.Message == "Underflow by multiplying.");
        }
        //////
        ///Modulus
        [Theory]
        [InlineData(101, 100, 1)]
        [InlineData(123, 20, 3)]
        [InlineData(125, 25, 0)]
        [InlineData(10, 4, 2)]
        [InlineData(57, 5, 2)]
        public void Modulo_Valid_Input(int initial, int x, int expected)
        {
            ICalculator c = new Calculator();
            c.Add(initial);
            c.Modulus(x);
            Assert.Equal(expected, c.Result);
        }

        [Fact]
        public void Modulo_Expect_DivideByZeroException()
        {
            // Arrange
            ICalculator c = new Calculator();
            c.Add(int.MinValue);
            // Act + Assert
            var e = Assert.Throws<DivideByZeroException>(() =>
            {
                c.Modulus(0);

            });

            Assert.True(e.Message == "You can't mod by 0.");
        }

        [Fact]
        public void Reset_Expect_Zero()
        {
            ICalculator c = new Calculator();
            var expected = 0;
            c.Add(123456);
            c.Reset();
            Assert.Equal(expected, c.Result);
        }
    }
}
