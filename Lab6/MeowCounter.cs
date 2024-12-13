using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6C_
{
    public class MeowCounter<T> where T : IMeowable
    {
        private Dictionary<T, int> meowCounts;

        public MeowCounter()
        {
            meowCounts = new Dictionary<T, int>();
        }

        public void MakeThemMeow(params T[] meowables)
        {
            foreach (var meowable in meowables)
            {
                meowable.meow();
                if (meowCounts.ContainsKey(meowable))
                {
                    meowCounts[meowable]++;
                }
                else
                {
                    meowCounts[meowable] = 1;
                }
            }
        }

        public int GetMeowCount(T meowable)
        {
            return meowCounts.ContainsKey(meowable) ? meowCounts[meowable] : 0;
        }

        public void PrintAllMeowCounts()
        {
            foreach (var entry in meowCounts)
            {
                Console.WriteLine($"Количество мяуканий {entry.Key}: {entry.Value}");
            }
        }
    }
}
