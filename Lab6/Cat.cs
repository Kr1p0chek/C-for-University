using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMeowable
{
    void meow();
}

namespace Lab6C_
{
    internal class Cat : IMeowable
    {
        public string name { get; }

        public Cat()
        {
            this.name = "Мурзик";
        }
        public Cat(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "кот: " + name;
        }

        public void meow()
        {
            Console.WriteLine($"{name}: мяу!");
        }

        public void meow(int c)
        {
            string s = $"{name}: ";
            for (int i = 0; i < c; i++)
            {
                if (i == 0) s += "мяу";
                else s += "-мяу";
            }
            s += "!";
            Console.WriteLine(s);
        }
    }
}
