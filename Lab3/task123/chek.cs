using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_taskt123__C__
{
    internal class Chek
    {
        static public int inputChek(string message, int left, int right)
        {
            bool ok;
            int n;
            do
            {
                Console.WriteLine(message);
                ok = int.TryParse(Console.ReadLine(), out n);
                if (ok && (n < left || n > right)) ok = false;
                if (!ok)
                {
                    Console.WriteLine($"Некорректные данные или число не принадлежит отрезку [{left}; {right}]. Повторите ввод!");
                }
            } while (!ok);
            return n;
        }
    }
}
