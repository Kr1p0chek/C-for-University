using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main()
    {
        try
        {
            bool start = true;
            while (start)
            {
                Program pr = new Program();
                int block = 0; int task = 0;
                Console.Write("Введи номер блока задач (1 - 4)   "); block = int.Parse(Console.ReadLine());
                Console.Write("Введи номер задачи задач (1 - 5)   "); task = int.Parse(Console.ReadLine());
                switch (block, task)
                {
                    case (1, 1): int num; Console.Write("Сложим 2 последних знака числа\nВведи число:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.sumLastNums(num)); break;
                    case (1, 2): Console.Write("Узнаем является ли число позитивным\nВведи число:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.isPositive(num)); break;
                    case (1, 3): char letter; Console.Write("Узнаем является ли ваш символ заглавной латинской буквой\nВведи символ:  "); letter = char.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.isUpperCase(letter)); break;
                    case (1, 4): int num2; Console.Write("Узнаем может ли в паре чисел одно являться делителем другого\nВведи число 1:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введи число 2:  "); num2 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.isDivisor(num, num2)); break;
                    case (1, 5): Console.Write("Сложим числа из разряда едениц у 5 чисел\nВведи число 1:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введи число 2:  "); num2 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.lastNumSum(num, num2)); break;
                    case (2, 1): Console.Write("Выполним деление\nВведи делимое:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введи делитель:  "); num2 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.safeDiv(num, num2)); break;
                    case (2, 2): Console.Write("Выясним какое число больше\nВведи первое число:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введи второе число:  "); num2 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.makeDecision(num, num2)); break;
                    case (2, 3): int num3; Console.Write("Узнаем, можно ли получить одно число из тройки сложением двух других\nВведи первое число:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введи второе число:  "); num2 = int.Parse(Console.ReadLine()); Console.Write("Введи третье число:  "); num3 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.sum3(num, num2, num3)); break;
                    case (2, 4): Console.Write("Подставим верно год/года/лет\nВведите число:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine(pr.age(num)); break;
                    case (2, 5): string str; Console.Write("Выведем все дни до конца недели\nВведите текущий день недели:  "); str = Console.ReadLine(); Console.WriteLine("Ответ: "); pr.printDays(str); break;
                    case (3, 1): Console.Write("Выведем все числа от X до 0\nВведите X:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ:\n" + pr.reverseListNums(num)); break;
                    case (3, 2): Console.Write("Возведём X в степень Y\nВведите X:  "); num = int.Parse(Console.ReadLine()); Console.Write("Введите Y:  "); num2 = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.pow(num, num2)); break;
                    case (3, 3): Console.Write("Проверим, состоит ли число из одинаковых цифр\nВведите число:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ: " + pr.equalNum(num)); break;
                    case (3, 4): Console.Write("Нарисуем левый треугольник\nВведите высоту треугольника:  "); num = int.Parse(Console.ReadLine()); Console.WriteLine("Ответ:  \n"); pr.leftTriangle(num); break;
                    case (3, 5): Console.WriteLine("Играем в угадайку"); pr.guessGame(); break;
                    case (4, 1): Console.Write("Найдём индекс последнего входжения числа в массив\nВведите размер массива (он будет заполнен случайными значениями в промежутке от -99 до 99):  "); num = int.Parse(Console.ReadLine()); if (num <= 0) { Console.WriteLine("Массив не может иметь размер <= 0, перезапустите и попробуйте снова"); break; } int[] arr = new int[num]; Console.Write("Введите искомое число:  "); num2 = int.Parse(Console.ReadLine()); pr.arrayRandomFill(arr); Console.Write("Массив:  "); pr.arrayPrint(arr); Console.WriteLine("Ответ:  " + pr.findLast(arr, num2)); break;
                    case (4, 2): Console.Write("Вставим ваше значение в указанную позицию массива\nВведите размер массива (он будет заполнен случайными значениями в промежутке от -99 до 99):  "); num = int.Parse(Console.ReadLine()); if (num <= 0) { Console.WriteLine("Массив не может иметь размер <= 0, перезапустите и попробуйте снова"); break; } arr = new int[num]; Console.Write("Введите число, которое хотите добавить:  "); num2 = int.Parse(Console.ReadLine()); Console.Write("Введите позицию, куда его вставить:  "); num3 = int.Parse(Console.ReadLine()); if (num3 > num || num3 < 0) Console.WriteLine("В массиве указанного размера не может существовать число на указанной позиции, перезапустите программу и введите корректные значения"); else { pr.arrayRandomFill(arr); Console.Write("\n                 Массив:  "); pr.arrayPrint(arr); Console.Write("Массив после добавления:  "); pr.arrayPrint(pr.add(arr, num2, num3)); } break;
                    case (4, 3): Console.Write("Развернём массив\nВведите размер массива (он будет заполнен случайными значениями в промежутке от -99 до 99):  "); num = int.Parse(Console.ReadLine()); if (num <= 0) { Console.WriteLine("Массив не может иметь размер <= 0, перезапустите и попробуйте снова"); break; } arr = new int[num]; pr.arrayRandomFill(arr); Console.Write("    Исходный массив: "); pr.arrayPrint(arr); pr.reverse(arr); Console.Write("Перевёрнутый массив: "); pr.arrayPrint(arr); break;
                    case (4, 4): Console.Write("Соединим два массива в один\nВведите размер массива (он будет заполнен случайными значениями в промежутке от -99 до 99):  "); num = int.Parse(Console.ReadLine()); Console.Write("Теперь введите размер второго массива:  "); num2 = int.Parse(Console.ReadLine()); if (num <= 0 || num2 <= 0) { Console.WriteLine("Массив не может иметь размер <= 0, перезапустите и попробуйте снова"); break; } arr = new int[num]; int[] arr2 = new int[num2]; pr.arrayRandomFill(arr); pr.arrayRandomFill(arr2); Console.Write("Первый массив: "); pr.arrayPrint(arr); Console.Write("Второй массив: "); pr.arrayPrint(arr2); Console.Write("Результат: "); pr.arrayPrint(pr.concat(arr, arr2)); break;
                    case (4, 5): Console.Write("Создадим новый массив на основе старого, удалив все отрицательные значения\nВведите размер массива (он будет заполнен случайными значениями в промежутке от -99 до 99):  "); num = int.Parse(Console.ReadLine()); if (num <= 0) { Console.WriteLine("Массив не может иметь размер <= 0, перезапустите и попробуйте снова"); break; } arr = new int[num]; pr.arrayRandomFill(arr); Console.Write("Исходный массив: "); pr.arrayPrint(arr); arr2 = pr.deleteNegative(arr); Console.Write("Результат: "); pr.arrayPrint(arr2); break;
                    default: Console.WriteLine("Такой задачи нет"); break;
                }
                Console.WriteLine("\nЕсли хотите протестировать другую задачу введите \"1\"");
                string restart = Console.ReadLine();
                if (restart != "1")
                    start = false;
                Console.Clear();
            }
            Console.Write("Хорошего дня ;)");
        }
        catch (System.FormatException) { Console.WriteLine("Одно или несколько введённых значений не соответствуют по типу требуемым условием, пожалуйста перезапустите программу и введите значения корректно"); }
    }

    public int sumLastNums(int x)
    {
        int a = x % 10; // Последняя цифра
        x = x / 10; // число без последней цифры
        int b = x % 10; // 2-ая с конца цифра
        return a + b; // вернём сумму
    }
    public bool isPositive(int x)
    {
        if (x >= 0) return true;
        else return false;
    }

    public bool isUpperCase(char x)
    {
        if (x >= 'A' && x <= 'Z') return true; // Если заглянуть под капот, то тут проверка по коду ASCII
        else return false;
    }
    public bool isDivisor(int a, int b)
    {
        if (a % b == 0 || b % a == 0) return true;
        else return false;
    }

    public int lastNumSum(int a, int b)
    {
        Console.Write($"{a} + {b}");
        a = a % 10 + b % 10;
        Console.WriteLine($" это {a}");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Введи следующее слагаемое:  ");
            b = int.Parse(Console.ReadLine());
            Console.Write($"{a} + {b}");
            a = a % 10 + b % 10;
            Console.WriteLine($" это {a}");
        }
        return a;
    }
    public double safeDiv(int x, int y)
    {
        if (y == 0) return 0;
        else
        {
            double z = Convert.ToDouble(x) / Convert.ToDouble(y);
            return z;
        }
    }
    public String makeDecision(int x, int y)
    {
        if (x > y)
            return $"{x}>{y}";
        if (x < y)
            return $"{x}<{y}";
        else
            return $"{x}=={y}";
    }

    public bool sum3(int x, int y, int z)
    {
        if ((x + y == z) || (y + z == x) || (x + z == y))
            return true;
        else
            return false;
    }

    public String age(int x)
    {
        int last_num = x % 10;
        if (last_num == 1 && x != 11)
            return $"{x} год";
        else if ((last_num == 2 || last_num == 3 || last_num == 4) && (x != 12 && x != 13 && x != 14))
            return $"{x} года";
        else
            return $"{x} лет";
    }

    public void printDays(String x)
    {
        switch (x)
        {
            case "понедельник": Console.WriteLine("понедельник"); goto case "вторник";
            case "вторник": Console.WriteLine("вторник"); goto case "среда";
            case "среда": Console.WriteLine("среда"); goto case "четверг";
            case "четверг": Console.WriteLine("четверг"); goto case "пятница";
            case "пятница": Console.WriteLine("пятница"); goto case "суббота";
            case "суббота": Console.WriteLine("суббота"); goto case "воскресенье";
            case "воскресенье": Console.WriteLine("воскресенье"); break;
            default: Console.WriteLine("это не день недели"); break;
        }
    }

    public String reverseListNums(int x)
    {
        string result = "";
        if (x < 0)
        {
            for (int i = x; i <= 0; i++)
            {
                result += Convert.ToString(i) + ' ';
            }
        }
        else if (x > 0)
        {
            for (int i = x; i >= 0; i--)
            {
                result += Convert.ToString(i) + ' ';
            }
        }
        else
            result = "0";
        return result;
    }

    public int pow(int x, int y)
    {
        int result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }

    public bool equalNum(int x)
    {
        int last_num = x % 10;
        x /= 10;
        while (x > 0)
        {
            if (last_num != x % 10)
                return false;
            else
            {
                last_num = x % 10;
                x /= 10;
            }
        }
        return true;
    }

    public void leftTriangle(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= i; j++)
                Console.Write("*");
            Console.Write("\n");
        }
    }

    public void guessGame()
    {
        Random random = new Random();
        int count = 1;
        int guess = random.Next(0, 10);
        int player = -1;
        Console.Write("Введите число от 0 до 9:  ");
        player = int.Parse(Console.ReadLine());
        if (player != guess)
        {
            while (guess != player)
            {
                count++;
                Console.Write("Вы не угадали, введите число от 0 до 9:  ");
                player = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("Вы угадали!");
        Console.WriteLine($"Вы отгадали число за {count} попытки");
    }

    public void arrayRandomFill(int[] arr)
    {
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(-99, 100);
        }
    } // Функция для заполнения массива случайными значениями

    public void arrayPrint(int[] arr)
    {
        Console.Write("[ ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine("]\n");
    } // Функция для вывода массива

    public int findLast(int[] arr, int x)
    {
        int index = -1;
        for (int i =0; i < arr.Length; i++)
        {
            if (arr[i] == x)
                index = i;
        }
        return index;
    }

    public int[] add(int[] arr, int x, int pos)
    {
        int[] newArr = new int[arr.Length + 1];
        int i = 0;
        for (; i != pos; i++)
        {
            newArr[i] = arr[i];
        }
        newArr[i++] = x;
        for (; i < newArr.Length; i++)
        {
            newArr[i] = arr[i- 1];
        }
        return newArr;
    }

    public void reverse(int[] arr)
    {
        int t;
        for (int i = 0; i < arr.Length / 2; i++) {
            t = arr[i];
            arr[i] = arr[arr.Length - 1 - i];
            arr[arr.Length - 1 - i] = t;
        }
    }

    public int[] concat(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length + arr2.Length];
        for (int i = 0; i < arr1.Length; i++)
            result[i] = arr1[i];
        for (int i = arr1.Length; i < arr2.Length + arr1.Length; i++)
            result[i] = arr2[i - arr1.Length];
        return result;
    }

    public int[] deleteNegative(int[] arr)
    {
        int len = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0)
                len++;
        }
        int[] result = new int[len];
        int j = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0)
                result[j++] = arr[i];
        }
        return result;
    }
}
