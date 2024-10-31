using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_taskt123__C__
{
    internal class Matrix
    {
        private int[,] matrix1;
        private Random rnd = new Random();

        public int[,] A { get { return matrix1; } }

        public Matrix(int x)
        {
            if (x == 1)
            {
                int n = Chek.inputChek("Введите количество строк матрицы от 1 до 10", 1, 10);
                int m = Chek.inputChek("Введите количество столбцов матрицы от 1 до 10", 1, 10);
                matrix1 = new int[n, m];
                matrix1 = mass1(n, m);
            }
            else if (x == 2)
            {
                int n = Chek.inputChek("Введите размерность матрицы от 1 до 10", 1, 10);
                matrix1 = new int[n, n];
                matrix1 = mass2(n);
            }
            else if (x == 3)
            {
                int n = Chek.inputChek("Введите размерность матрицы от 1 до 10", 1, 10);
                matrix1 = new int[n, n];
                matrix1 = mass3(n);
            }
            else
                throw new Exception("Такой нет");

        }

        public Matrix(int[,] a)
        {
            matrix1 = a;
        }
        public int[,] mass1(int x, int y)
        {
            int[,] result = new int[x, y];
            for (int j = 0; j < y; j++)
            {
                for (int i = x - 1; i >= 0; i--)
                {
                    int inp = Chek.inputChek("Введи элемент матрицы (4ёх значное число)", -9999, 9999);
                    result[i, j] = inp;
                }
            }
            return result;
        }

        public int[,] mass2(int x)
        {
            int[,] result = new int[x, x];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Random random = new Random();
                    char[] nums = { '1', '3', '5', '7', '9' };
                    char[] number = new char[4];
                    for (int k = 0; k < 4; k++)
                    {
                        number[k] = nums[random.Next(nums.Length)];
                    }
                    result[i,j] = int.Parse(new string(number)); 
                }
            }
            return result;
        }

        public int[,] mass3(int x)
        {
            int[,] result = new int[x, x];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x - i - 1; j++)
                    result[i, j] = 0;
            }
            for (int i = 0; i < x; i++)
            {
                int k = i;
                int l = x - 1;
                int s;
                if (i % 2 != 0)
                {
                    s = x - i;
                    while (k < x)
                    {
                        result [k, l] = s;
                        k++; l--; s--;
                    }
                }
                else
                {
                    s = 1;
                    while (k < x)
                    {
                        result[k, l] = s;
                        k++; l--; s++;
                    }
                }
            }
            return result;
        }

        //public void writeMatrix(int[,] matrix, int x, int y)
        //{
        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            Console.Write(" {0,4} ", matrix[i,j]);
        //        }
        //        Console.Write("\n");
        //    }
        //}

        public void arithMean()
        {
            int n = this.matrix1.GetLength(0);
            int m = this.matrix1.GetLength(1);
            if (m == 1)
            {
                Console.WriteLine("В матрице только один столбец, невозможно выполнить подсчёт");
            }
            else
            {
                float sum = 0;
                for (int i = 0; i < n; i++)
                    sum += this.matrix1[i, 0];
                int count = 0;
                sum = sum / n;
                for (int i = 1; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                        if (this.matrix1[j, i] > sum) count++;
                    Console.WriteLine($"В столбце {i + 1} находится {count} чисел больших чем ср.арифмет. первого столбца");
                    count = 0;
                }
            }
        }

        public static Matrix operator *(int a, Matrix matrix)
        {
            int[,] result = new int[matrix.A.GetLength(0),matrix.A.GetLength(1)];
            for (int i = 0; i < matrix.A.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.A.GetLength(1); j++)
                {
                    result[i,j] = matrix.A[i,j] * a;
                }
            }
            return new Matrix(result);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.A.GetLength(1) != matrixB.A.GetLength(0))
                throw new InvalidOperationException("Невозможно умножить матрицы: количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            int[,] result = new int[matrixA.A.GetLength(0), matrixB.A.GetLength(1)];
            for (int i = 0; i < matrixA.A.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.A.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixA.A.GetLength(1); k++)
                        result[i, j] += matrixA.A[i, k] * matrixB.A[k, j];
                }
            }
            return new Matrix(result);
        }

        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.A.GetLength(0) != matrixB.A.GetLength(0) || matrixA.A.GetLength(1) != matrixB.A.GetLength(1))
                throw new InvalidOperationException("Невозможно вычесть матрицы: размеры матриц должны совпадать.");
            int[,] result = new int[matrixA.A.GetLength(0), matrixA.A.GetLength(1)];
            for (int i = 0; i < matrixA.A.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.A.GetLength(1); j++)
                {
                    result[i, j] = matrixA.A[i, j] - matrixB.A[i, j];
                }
            }
            return new Matrix(result);
        }

        public static Matrix operator !(Matrix matrix)
        {
            int[,] result = new int[matrix.A.GetLength(1), matrix.A.GetLength(0)];
            for (int i = 0; i < matrix.A.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.A.GetLength(1); j++)
                {
                    result[i, j] = (matrix.A[j, i]);
                }
            }
            return new Matrix(result);
        }

        public override string ToString()
        {
            int max = 0;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        if (matrix1[i, j].ToString().Length > max) max = matrix1[i, j].ToString().Length;
                    }
            }
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result.AppendFormat($"{{0,{max}}}", matrix1[i, j]);
                    result.Append(" ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

    }
}
