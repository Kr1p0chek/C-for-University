using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6C_
{
    public interface IFraction
    {
        public double GetValue();
        public void SetNumDen(int numerator, int denominator);
    }
    internal class Fraction : IEquatable<Fraction>, ICloneable, IFraction
    {
        public int numerator { get; private set; }
        public int denominator { get; private set; }


        public Fraction()
        {
            this.numerator = 1;
            this.denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                string inp;
                Console.WriteLine("Знаменатель дроби должен быть целым числом и не может быть меньше или равен 0");
                while (denominator <= 0)
                {
                    Console.WriteLine("Введите другой знаменатель");
                    inp = Console.ReadLine();
                    if (!(int.TryParse(inp, out denominator)))
                    {
                        Console.WriteLine("Знаменатель дроби должен целым быть числом не может быть меньше или равен 0");
                    }
                }
            }
            this.numerator = numerator;
            this.denominator = denominator;
            //Console.WriteLine($"Создана дробь {this}");
        }

        public double GetValue()
        {
            return (double)numerator / denominator;
        }
        public void SetNumDen(int numerator, int denominator)
        {
            string old = $"{this}";
            if (denominator <= 0)
            {
                string inp;
                Console.WriteLine("Знаменатель дроби должен быть целым числом и не может быть меньше или равен 0");
                while (denominator <= 0)
                {
                    Console.WriteLine("Введите другой знаменатель");
                    inp = Console.ReadLine();
                    if (!(int.TryParse(inp, out denominator)))
                    {
                        Console.WriteLine("Знаменатель дроби должен целым быть числом не может быть меньше или равен 0");
                    }
                }
            }
            this.numerator = numerator;
            this.denominator = denominator;
            Console.WriteLine("Дробь " + old + $" изменена на {this}");
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        private static int gcd(int a, int b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int num, den;
            if (a.denominator == b.denominator)
            {
                num = a.numerator + b.numerator;
                den = a.denominator;
                return new Fraction(num, den);
            }
            else
            {
                num = (a.numerator * b.denominator) + (b.numerator * a.denominator);
                den = (a.denominator * b.denominator);
                int c = gcd(num, den);
                num = num / c;
                den = den / c;
                return new Fraction(num, den);
            }
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int num, den;
            if (a.denominator == b.denominator)
            {
                num = a.numerator - b.numerator;
                den = a.denominator;
                return new Fraction(num, den);
            }
            else
            {
                num = (a.numerator * b.denominator) - (b.numerator * a.denominator);
                den = (a.denominator * b.denominator);
                int c = gcd(num, den);
                num = num / c;
                den = den / c;
                return new Fraction(num, den);
            }
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            int num, den;
            num = a.numerator * b.numerator;
            den = a.denominator * b.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            int num, den;
            num = a.numerator * b.denominator;
            den = a.denominator * b.numerator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }

        public static Fraction operator +(Fraction a, int b)
        {
            int num, den;
            num = a.numerator + (a.denominator * b);
            den = a.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator -(Fraction a, int b)
        {
            int num, den;
            num = a.numerator - (a.denominator * b);
            den = a.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator *(Fraction a, int b)
        {
            int num, den;
            num = a.numerator * b;
            den = a.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator /(Fraction a, int b)
        {
            int num, den;
            num = a.numerator ;
            den = a.denominator * b;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }

        public static Fraction operator +(int a, Fraction b)
        {
            int num, den;
            num = b.numerator + (b.denominator * a);
            den = b.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator -(int a, Fraction b)
        {
            int num, den;
            num = (a * b.denominator) - b.numerator;
            den = b.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator *(int a, Fraction b)
        {
            int num, den;
            num = b.numerator * a;
            den = b.denominator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }
        public static Fraction operator /(int a, Fraction b)
        {
            int num, den;
            num = (a * b.denominator) * b.denominator;
            den = (a * b.denominator) * b.numerator;
            int c = gcd(num, den);
            num = num / c;
            den = den / c;
            return new Fraction(num, den);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Fraction);
        }

        public bool Equals(Fraction other)
        {
            return other != null &&
               numerator == other.numerator &&
               denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        public object Clone()
        {
            return new Fraction(numerator, denominator);
        }
    }
}
