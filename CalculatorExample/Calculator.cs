using System;

namespace CalculatorExample
{
    public class Calculator : ICalculator
    {
        

        public int Result { get; private set; }
        public void Add(int x) // 1 + MaxValue < MaxValue
        {
            if(x>0 && (Result + x)<Result )
                throw new OverflowException("Overflow by addition.");
            if(x<0 && (Result + x)>Result)
                throw new OverflowException("Underflow by addition.");
            Result += x;
        }

        public void Divide(int x)
        {
            if (x == 0)
                throw new DivideByZeroException("You can't divide by 0.");
            Result /= x;
        }

        public void Modulus(int x) // reszta z 
        {
            if (x == 0)
                throw new DivideByZeroException("You can't mod by 0.");
            Result = Result % x;
        }

        public void Multiply(int x)
        {
            if(Result > 0 && x > 0 && (x * Result) <0)
                throw new OverflowException("Underflow by multiplying.");
            if(Result < 0 && x < 0 && (x * Result) <0)
                throw new OverflowException("Underflow by multiplying.");
            if(Result > 0 && x < 0 && (x * Result) >0)
                throw new OverflowException("Overflow by multiplying.");
            if(Result < 0 && x > 0 && (x * Result) >0)
                throw new OverflowException("Overflow by multiplying.");
            Result *= x;
        }

        public void Reset()
        {
            Result = 0;
        }

        public void Subtract(int x)
        {
            if(Result<0 && x>0 && (Result-x) >0 )
                throw new OverflowException("Overflow by subtraction.");
            if (Result > 0 && x < 0 && (Result - x) < 0)
                throw new OverflowException("Underflow by subtraction.");

            Result -= x;

        }
    }
}