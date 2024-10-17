using Lab2_1_C__;

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
                int x, y, z;
                Console.Write("x - ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("y - ");
                y = Convert.ToInt32(Console.ReadLine());
                Console.Write("z - ");
                z = Convert.ToInt32(Console.ReadLine());
                defaultClass obj1 = new defaultClass(x, y, z);
                defaultClass obj2 = new defaultClass(obj1);
                Console.WriteLine("Экземпляр класса: " + obj1);
                Console.WriteLine("Копия экземпляра класса: " + obj2);
                Console.WriteLine("x * y * z = " + obj2.GetProduct());
                Cuboid cuboid1;
                Console.WriteLine("Создадим экземпляр дочернего класса Прямоугольный параллелепипед\nПомните, что стороны параллелепипеда должны быть положительными, целыми значениями\nЕсли хотите использовать для его значений длинны, ширины и высоты значения x, y, z, нажмите Enter");
                if (Console.ReadLine() == "")
                    cuboid1 = new Cuboid(x, y, z);
                else
                {

                    Console.Write("Введите длинну - ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите ширину - ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите высоту - ");
                    z = Convert.ToInt32(Console.ReadLine());
                    cuboid1 = new Cuboid(x, y, z);
                }
                Console.WriteLine(cuboid1);
                Console.Write("Создадим второй экземпляр класса, копию первого, и заменим его высоту на новое значение.\nВведите новую высоту - ");
                Cuboid cuboid2 = new Cuboid(cuboid1);
                cuboid2.Z = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(cuboid2);
                Console.WriteLine($"\nОбъём параллелепипеда 2 = {cuboid2.GetVolume()}");
                Console.WriteLine($"Куб со стороной = {cuboid2.GetSimCub()} будет иметь тот же объём, что и заданный параллелепипед");
                Console.WriteLine($"Площадь поверхности параллелепипеда = {cuboid2.GetSurfaceArea()}");
                Console.WriteLine("\nВведи 1, если хочешь перезапустить программу");
            }
            catch (ArgumentException) { Console.WriteLine("Длинна, ширина и высота должны быть положительными числами, введите 1, если хотите перезапустить программу"); }
            catch (System.OverflowException) { Console.WriteLine("Значение превысило допустимый диапозон, введите 1, если хотите перезапустить программу"); }
            catch (System.FormatException) { Console.WriteLine("Введённое значение не является числом,  введите 1, если хотите перезапустить программу"); }
            string restart = Console.ReadLine();
            if (restart != "1") break;
        }

    }
}