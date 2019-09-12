using System;

namespace CalculatorExample
{
    public class Calculator : ICalculator
    {
        

        public int Result { get; private set; }
        public void Add(int x) // 1 + MaxValue < MaxValue
        {
            if(x > 0 && (Result + x) <Result )
                throw new OverflowException("Overflow by addition.");
            if(x<0 && (Result + x)> Result)
                throw new OverflowException("Underflow by addition.");
            Result += x;
        }

        public void Divide(int x)
        {
            throw new System.NotImplementedException();
        }

        public void Modulus(int x)
        {
            throw new System.NotImplementedException();
        }

        public void Multiply(int x)
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Subtract(int x)
        {
            throw new System.NotImplementedException();
        }
    }
}