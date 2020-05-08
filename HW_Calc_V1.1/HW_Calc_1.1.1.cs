using System;
using System.Linq;

namespace HW_Calc_V1._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Меню:\n>> Нахождение среднего << 1\n>> Факториал << 2\n" +
                ">> Матрицы << 3\n>> Фибониччи << 4\n>> ");
        Choice:
            int Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Mean();
                    break;
                case 2:
                    Factorial();
                    break;
                case 3:
                    Matrices();
                    break;
                case 4:
                    Fibonacci();
                    break;
                default:
                    Console.WriteLine("Данного метода нет в программе.");
                    goto Choice;
            }
        }

        static void Matrices()
        {
            int[,] Matrix1, Matrix2;

            Console.Write("Введите количество столбцов в матрице: ");
            int Column = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество линий в матрице: ");
            int Line = Convert.ToInt32(Console.ReadLine());

            Matrix1 = new int[Column, Line];
            Matrix2 = new int[Column, Line];
            Console.Write(">> Ручная запись ячеек матриц << 1\n>> Автоматическая запись ячеек матриц << 2\n>> ");
            string Set = Console.ReadLine();
            switch (Set)
            {
                case "1":
                    for (int i = 0; i < Matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < Matrix1.GetLength(1); j++)
                        {
                            Console.Write($"Матрица 1: Ячейка [{i},{j}]: ");
                            Matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
                            Console.Write($"Матрица 2: Ячейка [{i},{j}]: ");
                            Matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    break;
                case "2":
                    for (int i = 0; i < Matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < Matrix1.GetLength(1); j++)
                        {
                            Matrix1[i, j] = Randomic(0, 100);
                            Matrix2[i, j] = Randomic(0, 100);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Вы захотели сломать программу? Хорошо. bye bye.");
                    break;
            }

            OutputMatrix(Matrix1, Matrix2);
        Matrix:
            Console.Write("\nЧто надо сделать с матрицей? Вычитание '-', Суммирование '+', Умножение '*': ");
            string Maht = Console.ReadLine();
            Console.WriteLine("Итоговая матрица:");
            if (Maht == "*")
                MatrixMultiplication();
            else if (Maht == "-" || Maht == "+")
                MatrixAddRemoveSubtraction();
            else if (Maht != "-" || Maht != "+")
            {
                Console.WriteLine("Такого метода нет.");
                goto Matrix;
            }

            void MatrixAddRemoveSubtraction()
            {
                for (int i = 0; i < Matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix1.GetLength(1); j++)
                    {
                        if (Maht == "+")
                            Console.Write((Matrix1[i, j] + Matrix2[i, j]) + "\t");
                        else if (Maht == "-")
                            Console.Write((Matrix1[i, j] - Matrix2[i, j]) + "\t");

                    }
                    Console.WriteLine();
                }
            }
            void MatrixMultiplication()
            {
                if ( Column != Line)
                {
                    Console.WriteLine("Такие матрицы нельзя перемножить, так как количество столбцов матрицы А не равно количеству строк матрицы В.");
                }
                else
                {
                    int[,] MatrixMultip = new int[Column, Line];
                    for (int i = 0; i < Matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < Matrix2.GetLength(1); j++)
                        {
                            for (int k = 0; k < Matrix1.GetLength(0); k++)
                            {
                                MatrixMultip[i, j] += Matrix1[i, k] * Matrix2[k, j];
                            }
                            Console.Write(MatrixMultip[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }

            static void OutputMatrix(int[,] Matrix1, int[,] Matrix2)
            {
                int[,] Swith = default;
                for (int l = 0; l < 2; l++)
                {
                    if (l == 0)
                        Swith = Matrix1;
                    else
                        Swith = Matrix2;
                    Console.WriteLine($"Матрица {l + 1}:");
                    for (int i = 0; i < Matrix1.GetLength(0); i++)
                    {
                        for (int j = 0; j < Matrix1.GetLength(1); j++)
                        {
                            Console.Write(Swith[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }

            }
        }

        static void Mean()
        {
            double Arithmetical_Mean = 0;
            double Geometric_Mean = 1;
            double Quadratic_mean = 0;
            int Lenght_Massive = 0;
            double[] Number = { 0 };

        Setting:
            Console.Write("Ручной ввод данных >> 1 <<\nАвтоматический >> 2 <<\nНастраиваемый >> 3 <<\n>> ");
            string Setting = Console.ReadLine();
            switch (Setting)
            {
                case "1":
                    try
                    {
                        Console.Write("Введите числа через пробел для нахождения среднее арифметического \n>> ");
                        Number = Console.ReadLine().Trim().Split(" ").Select(double.Parse).ToArray();
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели недопустимый символ.\n");
                        goto case "1";
                    }
                    break;

                case "2":
                    Number = new double[100];
                    for (int i = 0; i < Number.Length; i++)
                    {
                        Number[i] += Randomic(0, 999);
                    }
                    OutputMassive(Number);
                    break;

                case "3":
                    Console.Write("Введите 3 параметра: \n1) Длина массива: ");
                    Lenght_Massive = Convert.ToInt32(Console.ReadLine());
                    Number = new double[Lenght_Massive];
                    Console.Write("2) Минимальный порог чисел: ");
                    int Min_RDM = Convert.ToInt32(Console.ReadLine());
                    Console.Write("3) Максимальный порог чисел: ");
                    int Max_RDM = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < Lenght_Massive; i++)
                    {
                        Number[i] += Randomic(Min_RDM, Max_RDM);
                    }
                    OutputMassive(Number);
                    break;

                default:
                    Console.WriteLine("Такого метода нет");
                    goto Setting;
            }

            Arithmetical_Mean = ArithMean(Arithmetical_Mean, Number);
            Geometric_Mean = GeometMean(Geometric_Mean, Number);
            Quadratic_mean = QuadraticMean(Quadratic_mean, Number);

            Console.WriteLine($"\nСреднее значение чисел равно: {Arithmetical_Mean:N2}\n" +
                $"Среднее геометрическое чисел равно: {Geometric_Mean:N2}\n" +
                $"Среднее квадратическое чисел равно: {Quadratic_mean:N2}");
        }

        static void Factorial()
        {
            Console.Write("Введите число для посчета факториала: ");
            int fac = Convert.ToInt32(Console.ReadLine());
            int[] Factor = new int[fac];
            int Factorial = 1;
            for (int i = 0; i <= fac - 1; i++)
                Factor[i] = fac - i;
            for (int i = 0; i < Factor.Length; i++)
                Factorial *= Factor[i];
            Console.WriteLine($"Факториал равен: {fac}! = {Factorial}");
        }

        static void Fibonacci()
        {
            //Console.WriteLine("Диапозон чисел Фибонеччи от 0 до 100: ");
            Console.Write("Какое число проверить на наличие в числах Фибоначчи?\n>> ");
            double NumberCheck = Convert.ToDouble(Console.ReadLine());
            double[] Fibonacci = new double[100];
            Fibonacci[0] = 0;
            Fibonacci[1] = 1;
            for (int i = 2; i < Fibonacci.Length; i++)
            {
                Fibonacci[i] += Fibonacci[i - 1] + Fibonacci[i - 2];
            }
            for( int i = 0; i < Fibonacci.Length; i++)
            {
                if (Fibonacci[i] == NumberCheck)
                {
                    Console.WriteLine($"Такое число есть, его порядковый номер: {i + 1}");
                    break;
                }
                else if (i == Fibonacci.Length - 1)
                    Console.WriteLine("Такого числа нет!");
            }
            Console.Write("Диапозон чисел Фибоначчи до 100 чисел: \n>> ");
            OutputMassive(Fibonacci);
        }

        static void OutputMassive(double[] Massive)
        {
            foreach (double i in Massive)
                Console.Write($"{i} ");
            Console.WriteLine("\n");
        }

        static int Randomic(int a, int b)
        {
            Random random = new Random();
            int Random = random.Next(a, b);
            return Random;
        }

        static double ArithMean(double Arithmetical_Mean, double[] Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                Arithmetical_Mean += Number[i];
                if (i == Number.Length - 1)
                    Arithmetical_Mean /= Number.Length;
            }
            return Arithmetical_Mean;
        }
        static double GeometMean(double Geometric_Mean, double[] Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                Geometric_Mean *= Number[i];
                if (i == Number.Length - 1)
                    Geometric_Mean = Math.Pow(Geometric_Mean, 1.0 / Number.Length);
            }
            return Geometric_Mean;
        }
        static double QuadraticMean(double Quadratic_mean, double[] Number)
        {
            for (int i = 0; i < Number.Length; i++)
            {
                Quadratic_mean += Math.Pow(Number[i], 2);
                if (i == Number.Length - 1)
                    Quadratic_mean = Math.Sqrt(Quadratic_mean / Number.Length);
            }
            return Quadratic_mean;
        }
    }
}