// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using Lab2_2_3_C__;

internal class Program
{
    private static void Main()
    {
        bool start = true;
        while (start)
        {
            Console.Clear();
            try
            {
                byte h1, h2, m1, m2;
                Console.WriteLine("Привет, эта программа для работы с электронными часами, давай установим время на часах");
                Program program = new Program();
                Time time1 = program.ins();
                Console.WriteLine("Установим время на вторых часах");
                Time time2 = program.ins();
                Console.Clear();
                Console.WriteLine($"Первые часы показывают - {time1}");
                Console.WriteLine($"Вторые часы показывают - {time2}");
                Console.WriteLine("Увеличим время на первых часах на 1 минуту, а на вторых уменьшим на 1 минуту");
                time1++;
                time2--;
                Console.WriteLine($"Теперь первые часы показывают - {time1}, а вторые - {time2}\n");
                Console.WriteLine("Ещё раз увеличим время на первых часах на 1 минуту, а на вторых уменьшим на 1 минуту");
                time1++;
                time2--;
                Console.WriteLine($"Теперь первые часы показывают - {time1}, а вторые - {time2}\n");
                Console.WriteLine($"Сравним, время на часах 1 < времени на часах 2 - {time1 < time2}");
                Console.WriteLine($"Сравним, время на часах 1 > времени на часах 2 - {time1 > time2}\n");
                Time time3 = time1.minus(time2);
                Console.WriteLine("Настроим время на третьих часах, время на них - это время на первых часах минус время на вторых часах");
                Console.WriteLine($"Третьи часы показывают - {time3}\n");
                Console.WriteLine("Время на третьих часах в минутах: " + (int)time3);
                Console.WriteLine("\nКонец, если хочешь запустить программу заного введи 1");
            }
            catch (System.OverflowException) { Console.WriteLine("Введённое вами значение не соответствует условию, введите 1, чтобы перезапустить программу и попробуйте снова"); }
            catch (System.FormatException) { Console.WriteLine("Введённое вами значение не является числом, введите 1, чтобы перезапустить программу и попробуйте снова"); }
            string restart = Console.ReadLine();
            if (restart != "1") break;
        }
    }

    public Time ins()
    {
        string h, m;
        byte hours, minutes;
        Console.WriteLine("Введи часы от 0 до 23 (если хочешь установить значения 00:00, то просто нажми Enter):");
        h = Console.ReadLine();
        if (h == "")
            return new Time();
        else
        {
            hours = Convert.ToByte(h);
            if (hours < 0 || hours > 23)
                throw new OverflowException();
        }
        Console.WriteLine("Введи минуты от 0 до 59 (если хочешь установить 0 минут, то можешь нажать Enter):");
        m = Console.ReadLine();
        if (m == "") return new Time(hours, 0);
        else
        {
            minutes = Convert.ToByte(m);
            if (minutes < 0 || minutes > 59) throw new OverflowException();
            else return new Time(hours, minutes);
        }
    }
}
