using Lab6C_;
using System.ComponentModel.DataAnnotations;

internal class Programm
{
    public static void Main()
    {
        Console.WriteLine("Задание 1\nСоздадим кота и вызовем метод meow без параметров и с параметром 3");
        Cat cat = new Cat("Барсик");
        cat.meow();
        cat.meow(3);

        Console.WriteLine("Создадим льва, вызовем для него метод meow");
        IMeowable lion = new Lion();
        lion.meow();

        Console.WriteLine("Создадим ещё 2ух котов и вызовем для всех котов и льва метод meow с помощью отдельного метода");
        Cat cat2 = new Cat();
        IMeowable cat3 = new Cat("Крошик");
        IMeowable[] meowables = new IMeowable[] { cat, cat2, cat3, lion };
        MeowCounter<IMeowable> Funs = new MeowCounter<IMeowable>();
        Funs.MakeThemMeow(meowables);

        Console.WriteLine("Выведим счётчикк мяуканий, затем заставим мяукать котов и льва и снова выведем счётчик");
        Funs.PrintAllMeowCounts();
        Funs.MakeThemMeow(cat);
        Funs.MakeThemMeow(cat);
        Funs.MakeThemMeow(cat2);
        Funs.MakeThemMeow(lion);
        Funs.MakeThemMeow(lion);
        Funs.MakeThemMeow(lion);
        Funs.PrintAllMeowCounts();



        Console.WriteLine("Задание 2\nСоздадим дроби 2/3 и 2/5 и проверим операции на их примере");
        //string inp; int num; int den;
        Fraction a = new Fraction(2, 3);
        Fraction b = new Fraction(2, 6);
        Console.WriteLine($"{a} + 3 = {a + 3}");
        Console.WriteLine($"{a} - 2 = {a - 2}");
        Console.WriteLine($"2 - {a} = {2 - a}");
        Console.WriteLine($"5 * {b} = {5 * b}");
        Console.WriteLine($"6 / {b} = {6 / b}");
        Console.WriteLine($"{a} / 4 = {a / 4}");
        Console.WriteLine($"{a} + {b} = {a + b}");
        Console.WriteLine($"{a} - {b} = {a - b}");
        Console.WriteLine($"{a} * {b} = {a * b}");
        Console.WriteLine($"{a} / {b} = {a / b}");

        Console.WriteLine("Теперь создадим дроби 12/17, 5/8, 3/5 и вычислим выражение из примера задачи");
        Fraction c = new Fraction(12, 17);
        Fraction d = new Fraction(5, 8);
        Fraction e = new Fraction(3, 5);
        Console.WriteLine($"({c} + {d}) / {e} - 5 = {(c + d) / e - 5}");

        Fraction g = new Fraction(2, 3);
        Console.WriteLine("Создадим ещё одну дробь 2/3 и произведём несколько сравнений");
        if (a.Equals(g))
            Console.WriteLine($"{a} = {g}");
        else { Console.WriteLine($"{a} != {g}"); }
        if (a.Equals(b))
            Console.WriteLine($"{a} = {b}");
        else { Console.WriteLine($"{a} != {b}"); }

        Console.WriteLine("Копируем дроь 2/3 и вычтем из оригинала 1, выведем обе дроби");
        Fraction g2 = (Fraction)g.Clone();
        g = g - 1;
        Console.WriteLine(g + "   " + g2);
        Console.WriteLine("Воспользуемся методом для изменения значений числителя и знаменателя и попродуем установить знаменатель -3");
        g.SetNumDen(10, -3);

        Console.WriteLine("Выведем значение получившейся дроби\n" + g.GetValue());
        Console.WriteLine("Передадим дробь во вспомогательный класс CacheFraction дробь и вызовем метод GetValue(), чтобы сохранить значение дроби в кэш");
        CacheFraction cache = new CacheFraction(g);
        Console.WriteLine(cache.GetValue());
        Console.WriteLine("Кэшированное значение  " + cache.GetCachedValue());
        Console.WriteLine("Изменим числитель и знаменатель дроби на 5 и 9 соответственно");
        cache.SetNumDen(5, 9);
        Console.WriteLine(g);
        Console.WriteLine("Кэшированное значение " + cache.GetCachedValue());

        //Console.WriteLine("Введите числитель дроби (целое число)");
        //inp = Console.ReadLine();
        //while (!int.TryParse(inp, out num))
        //{
        //    Console.WriteLine("Введите числитель дроби заного");
        //    inp = Console.ReadLine();
        //}
        //Console.WriteLine("Введите знаменатель дроби (целое число, > 0)");
        //inp = Console.ReadLine();
        //while (!int.TryParse(inp, out den))
        //{
        //    Console.WriteLine("Введите знаменатель дроби заного");
        //    inp = Console.ReadLine();
        //}
    }
}
