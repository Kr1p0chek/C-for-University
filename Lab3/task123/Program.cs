using Lab3_taskt123__C__;
using static Lab3_taskt123__C__.Files;

internal class Program
{
    public static void Main()
    {
        Console.WriteLine("Привет, это программа создаст три матрицы, указанных вами размеров.\nВам будет предложено самостоятельно заполнить первую матрицу (по столбцам снизу вверх).\nВторая и третья матрицы будут заполнены автоматически.\n");
        try
        {
            Matrix m1 = new Matrix(1);
            Console.Clear();
            Console.WriteLine("Получилась матрица A:\n" + m1);
            Matrix m2 = new Matrix(2);
            Console.WriteLine("Получилась матрица B:\n" + m2);
            Matrix m3 = new Matrix(3);
            Console.WriteLine("Получилась матрица C:\n" + m3);
            Console.WriteLine("Для матрицы A");
            m1.arithMean();
            Matrix m4 = 7 * m1 * (!m2 - m3);
            Console.WriteLine("\nРезультат вычисления 7*A*(Bt-C)");
            Console.WriteLine(m4);
        }
        catch (InvalidOperationException e) { Console.WriteLine("\n" + e.Message + "\nПерезапустите программу"); }
        catch (OverflowException) { Console.WriteLine("\nПри вычислении произошло превышение допустимого диапазона для int" + "\nПерезапустите программу"); }

        //-----------------------------------------------------------------------------------------------

        Console.WriteLine("Задание 4");
        string filePath = "numbers.bin";
        int numberOfElements = Chek.inputChek("Введите количество чисел в бинарном файле", 1, 5000);
        try
        {
            Files.FileRandomFill(filePath, numberOfElements);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при заполнении файла: {e.Message}");
            return;
        }
        try
        {
            int difference = Files.FindDifBetweenMaxMin(filePath);
            Console.WriteLine($"Разность между максимальным и минимальным элементами: {difference}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return;
        }

        Console.WriteLine("\nЗадание 5");
        string filePath2 = "toys.bin";
        int countOfToys = Chek.inputChek("Введите количество игрушек в файле (не более 200)", 1, 200);
        try
        {
            Files.CreateToysFile(filePath2, countOfToys);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при заполнении файла: {e.Message}");
            return;
        }
        int k = Chek.inputChek("Введите k ", 0, 9999);
        try
        {
            Files.ExpensiveToys(k, filePath2);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return;
        }

        Console.WriteLine("\nЗадание 6");
        string filePath3 = "numbers.txt";
        int countOfNumbers = Chek.inputChek("Введите количество чисел в текстовом файле", 1, 5000);
        try
        {
            Files.GenerateNumbersFile(filePath3, countOfNumbers);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при заполнении файла: {e.Message}");
            return;
        }
        try
        {
            Files.CountMaxOccurrences(filePath3);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return;
        }

        Console.WriteLine("\nЗадание 7");
        string filePath4 = "numbers2.txt";
        int numberOfLines = Chek.inputChek("Введите количество строк файла (от 1 до 100)", 1, 100);
        int numbersPerLine = Chek.inputChek("Введите количество чисел в строках файла (от 1 до 100)", 1, 100);
        TextFileInfo textFileInfo = new TextFileInfo(filePath4, numberOfLines, numbersPerLine);
        try
        {
            Files.GenerateNumbersLinesFile(textFileInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при заполнении файла: {e.Message}");
            return;
        }
        try
        {
            Files.CountEvenNumbers(textFileInfo);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            return;
        }

        Console.WriteLine("\nЗадание 8");
        string filePathInp = "text.txt";
        string filePathOut = "termLines.txt";
        Console.WriteLine("Введите комбинацию для копирования");
        string searchTerm = Console.ReadLine();
        if (searchTerm == "") searchTerm = "игр";
        try
        {
            Files.WriteLinesContainingTerm(filePathInp, filePathOut, searchTerm);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
            return;
        }
    }
}
