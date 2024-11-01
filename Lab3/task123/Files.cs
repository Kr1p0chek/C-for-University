using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_taskt123__C__
{
    internal class Files
    {
        [Serializable]
        public struct Toy
        {
            public string Name;
            public int Price;
            public int MinAge;
            public int MaxAge;
        }

        [Serializable]
        public struct TextFileInfo
        {
            public string FilePath;
            public int NumberOfLines;
            public int NumbersPerLine;

            public TextFileInfo(string filePath, int numberOfLines, int numbersPerLine)
            {
                FilePath = filePath;
                NumberOfLines = numberOfLines;
                NumbersPerLine = numbersPerLine;
            }
        }

        private static readonly string[] toyNames =
    {
        "Плюшевый мишка", "Кукла", "Машинка", "Пазл", "Конструктор",
        "Самолётик", "Меч", "Мяч", "Домик"
    };

        public static void CreateToysFile(string filePath, int toysCount)
        {
            List<Toy> toys = new List<Toy>();

            Random random = new Random();

            for (int i = 0; i < toysCount; i++)
            {
                string name = $"{toyNames[random.Next(toyNames.Length)]} {i + 1}";
                int price = random.Next(199, 10000);
                int minAge = random.Next(0, 13);
                int maxAge = random.Next(minAge + 1, 100);

                toys.Add(new Toy { Name = name, Price = price, MinAge = minAge, MaxAge = maxAge });
            }

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Toy toy in toys)
                    {
                        writer.Write(toy.Name);
                        writer.Write(toy.Price);
                        writer.Write(toy.MinAge);
                        writer.Write(toy.MaxAge);
                    }
                }
                Console.WriteLine($"Файл '{filePath}' успешно сгенерирован с {toysCount} игрушками (с ценами в промежутке от 199 до 9999).");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine("Ошибка при записи в файл: " + IOEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }
        }

        public static List<Toy> ReadToysFile(string filePath)
        {
            List<Toy> toys = new List<Toy>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        Toy toy = new Toy
                        {
                            Name = reader.ReadString(),
                            Price = reader.ReadInt32(),
                            MinAge = reader.ReadInt32(),
                            MaxAge = reader.ReadInt32()
                        };
                        toys.Add(toy);
                    }
                }
            }
            catch (FileNotFoundException NotFoundEx)
            {
                Console.WriteLine("Файл не найден: " + NotFoundEx.Message);
                throw;
            }
            catch (IOException IOEx)
            {
                Console.WriteLine("Ошибка при чтении файла: " + IOEx.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
                throw;
            }

            return toys;
        }

        public static void ExpensiveToys(int k, string filePath)
        {
            try
            {
                List<Files.Toy> toys = Files.ReadToysFile(filePath);
                if (toys.Count > 0)
                {
                    int maxPrice = toys.Max(t => t.Price);
                    List<string> expensiveToys = toys.Where(t => t.Price >= maxPrice - k).Select(t => t.Name).ToList();

                    Console.WriteLine("Дорогие игрушки:");
                    foreach (string toy in expensiveToys)
                    {
                        Console.WriteLine(toy);
                    }
                }
                else
                {
                    Console.WriteLine("Нет игрушек для отображения.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                throw;
            }
        }

        public static void FileRandomFill(string filePath, int count)
        {
            Random random = new Random();
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    for (int i = 0; i < count; i++)
                    {
                        int randomNumber = random.Next(-10000, 10001);
                        writer.Write(randomNumber);
                    }
                }
                Console.WriteLine($"Файл '{filePath}' успешно сгенерирован с {count} числами (все числа в промежутке от -10k до 10k).");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {IOEx.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
                throw;
            }
        }
        public static int FindDifBetweenMaxMin(string filePath)
        {
            int max = -10000;
            int min = 10000;
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32();
                        if (number > max)
                        {
                            max = number;
                        }
                        if (number < min)
                        {
                            min = number;
                        }
                    }
                }
            }
            catch (FileNotFoundException NotFoundEx)
            {
                Console.WriteLine("Файл не найден: " + NotFoundEx.Message);
                throw;
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {IOEx.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
                throw;
            }

            return max - min;
        }

        public static void GenerateNumbersFile(string filePath, int count)
        {
            Random random = new Random();
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < count; i++)
                    {
                        int number = random.Next(1, 1001);
                        writer.WriteLine(number);
                    }
                }
                Console.WriteLine($"Файл '{filePath}' успешно сгенерирован с {count} числами (все числа в промежутке от 1 до 1000).");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка записи в файл: {IOEx.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }

        public static void CountMaxOccurrences(string filePath)
        {
            try
            {
                List<int> numbers = File.ReadAllLines(filePath).Select(int.Parse).ToList();

                if (numbers.Count == 0)
                {
                    Console.WriteLine("Файл пуст.");
                    return;
                }
                int maxNumber = numbers.Max();
                int occurrences = numbers.Count(n => n == maxNumber);
                Console.WriteLine($"Максимальное число: {maxNumber}");
                Console.WriteLine($"Количество вхождений максимального числа: {occurrences}");
            }
            catch (FileNotFoundException NotFoundEx)
            {
                Console.WriteLine("Файл не найден: " + NotFoundEx.Message);
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine($"Ошибка формата данных в файле: {formatEx.Message}");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка чтения файла: {IOEx.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }

        public static void GenerateNumbersLinesFile(TextFileInfo textFileInfo)
        {
            Random random = new Random();
            try
            {
                using (StreamWriter writer = new StreamWriter(textFileInfo.FilePath))
                {
                    for (int i = 0; i < textFileInfo.NumberOfLines; i++)
                    {
                        List<int> numbers = new List<int>();
                        for (int j = 0; j < textFileInfo.NumbersPerLine; j++)
                        {
                            numbers.Add(random.Next(1, 101));
                        }
                        writer.WriteLine(string.Join(" ", numbers));
                    }
                }
                Console.WriteLine($"Файл '{textFileInfo.FilePath}' успешно заполнен случайными числами из промежутка от 1 до 100.");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка записи в файл: {IOEx.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }

        public static void CountEvenNumbers(TextFileInfo textFileInfo)
        {
            try
            {
                List<int> numbers = new List<int>();
                string[] lines = File.ReadAllLines(textFileInfo.FilePath);
                for (int i = 0; i < textFileInfo.NumberOfLines; i++)
                {
                    string[] elements = lines[i].Split(' ');
                    for (int j = 0; j < textFileInfo.NumbersPerLine; j++)
                    {
                        numbers.Add(int.Parse(elements[j]));
                    }
                }
                int evenCount = numbers.Count(n => n % 2 == 0);
                Console.WriteLine($"Количество четных чисел: {evenCount}");
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine($"Ошибка формата данных в файле: {formatEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Ошибка чтения файла: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void WriteLinesContainingTerm(string inputFilePath, string outputFilePath, string searchTerm)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine($"Файл '{inputFilePath}' не найден.");
                    return;
                }
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (string line in File.ReadLines(inputFilePath))
                    {
                        if (line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine($"Строки, содержащие '{searchTerm}', успешно записаны в файл '{outputFilePath}'.");
            }
            catch (IOException IOEx)
            {
                Console.WriteLine($"Ошибка при работе с файлом: {IOEx.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }
    }
}
