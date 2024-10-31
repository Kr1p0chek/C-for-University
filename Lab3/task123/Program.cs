using Lab3_taskt123__C__;

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
    }
}