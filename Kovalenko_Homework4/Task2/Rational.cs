using System;

namespace Task2
{
    public sealed class Rational : IComparable<Rational>
    {
        private readonly int _numerator, _denumerator;

        private int GetGCD(int x, int y)
        {
            if (y == 0)
                return x;
            else
                return GetGCD(y, x % y);
        }

        private void ConvertToIrreducible(int numerator, int denumerator, out int changedNumerator, out int changedDenumerator) 
        {
            var gcd = GetGCD(numerator, denumerator);
            changedNumerator = numerator / gcd;
            changedDenumerator = denumerator / gcd;
            if(changedDenumerator < 0)
            {
                changedNumerator = -changedNumerator;
                changedDenumerator = -changedDenumerator;
            }
        }
        public Rational() : this(0, 1)
        { }
        public Rational(int numerator, int denumerator)
        {
            if (denumerator <= 0) throw new ArgumentException("Denumerator is natural number");
            ConvertToIrreducible(numerator, denumerator, out _numerator, out _denumerator);
        }

        public int CompareTo(Rational other)
        {
            var value1 = (double)this;
            var value2 = (double)other;
            if (value1 == value2) return 0;
            return (value1 > value2) ? 1 : -1; 
        }

        public override bool Equals(object obj)
        {
            return obj is Rational r && this.CompareTo(r) == 0;
        }

        public override int GetHashCode()
        {
            return (_numerator << 2) ^ _denumerator;
        }

        public override string ToString() => _numerator != 0 ? $"{_numerator}/{_denumerator}" : "0";

        public static Rational operator +(Rational a, Rational b)
        {
            var numerator = a._numerator * b._denumerator + a._denumerator * b._numerator;
            var denumerator = a._denumerator * b._denumerator;
            if(denumerator == 0)
            {
                denumerator = 1;
            } 
            if(denumerator < 0)
            {
                denumerator = -denumerator;
                numerator = -numerator;
            }
            return new Rational(numerator,denumerator);
        }
        public static Rational operator -(Rational a, Rational b)
        { 
            var numerator = a._numerator * b._denumerator - a._denumerator * b._numerator;
            var denumerator = a._denumerator * b._denumerator;
            if (denumerator == 0)
            {
                denumerator = 1;
            }
            if (denumerator < 0)
            {
                denumerator = -denumerator;
                numerator = -numerator;
            }
            return new Rational(numerator, denumerator);
        }
        public static Rational operator *(Rational a, Rational b)
        {
            var numerator = a._numerator * b._numerator;
            var denumerator = a._denumerator * b._denumerator;
            if (denumerator < 0)
            {
                denumerator = -denumerator;
                numerator = -numerator;
            }
            return new Rational(numerator, denumerator);
        }
        public static Rational operator /(Rational a, Rational b)
        {
            if (b._numerator == 0) throw new DivideByZeroException("zero divide");
            var numerator = a._numerator * b._denumerator;
            var denumerator = a._denumerator * b._numerator;
            if (denumerator < 0)
            {
                denumerator = -denumerator;
                numerator = -numerator;
            }
            return new Rational(numerator, denumerator);
              
        }
        public static explicit operator double(Rational a)
        {
            return a._numerator / (double)a._denumerator;
        }
        public static implicit operator Rational(int number)
        {
            return new Rational(number, 1);
        }


    }
}
