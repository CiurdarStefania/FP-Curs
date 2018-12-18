using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1812
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matrici

            int[,] matrix;
            matrix = ReadMatrix("input.txt");
            PrintMatrix(matrix);

            // Suma maximelor de pe fiecare linie (daca maximul se repeta pe o linie atunci se aduna o singura data);
            Console.WriteLine();
            int suma;
            suma = SumaMaxime(matrix);
            Console.WriteLine("Suma maximelor de pe linie este {0}", suma);

            // Interschimbam liniile a.i. sumele de pe fiecare linie sa fie in ordine crescatoare
            Console.WriteLine();
            Console.WriteLine("Dupa interschimbare");
            SortByLineSum(matrix);
            PrintMatrix(matrix);

            // Afisati elementele matrcii parcurgand-o in spirala.
            Console.WriteLine();
            Console.Write("Parcurgere in spirala: ");
            ParcurgereSpirala(matrix);
            Console.WriteLine();

            // Matrici patratice (nr linii === nr coloane)
            Console.WriteLine();
            Console.WriteLine("Matrice patratica");
            int[,] matrix2;
            matrix2 = ReadMatrix("input2.txt");
            PrintMatrix(matrix2);
            
            // Inmultirea a 2 matrici;
            Console.WriteLine();
            Console.WriteLine("Produsul: ");
            int[,] matrix3;

            matrix3 = Product(matrix, matrix2);
            PrintMatrix(matrix3);
            Console.WriteLine();

            // Suma elementelor de pe diagonala principala
            Console.WriteLine("Suma elementelor de pe diagonala principala: {0}", SumDiag(matrix2));

            // suma elementelor de pe diagonala secundara
            Console.WriteLine("Suma elementelor de pe diagonala secundara: {0}", SumDiag2(matrix2));

            //suma elementelor de deasupra diagonalei principale;
            Console.WriteLine("Suma elementelor care sunt deasupra diagonala principala: {0}", SumDiagAbove(matrix2));

            // suma elementeor de sub diagonala principala.
            Console.WriteLine("Suma elementelor care sunt sub diagonala principala: {0}", SumDiagBelow(matrix2));

            // suma elementelor de deasupra diagonalei secundare
            Console.WriteLine("Suma elementelor care sunt deasupra diagonala secundara: {0}", SumDiag2Above(matrix2));

            //suma elementelor de sub diagonala secundara
            Console.WriteLine("Suma elementelor care sunt sub diagonala secundara: {0}", SumDiag2Below(matrix2));

            //suma elementelor de pe o banda de dimensiune k a diagonalei principale.
            Console.WriteLine();
            Console.Write("Introduceti banda K: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Suma elementelor diagonala principala si banda k: {0}", SumDiagK(matrix2, k));

            //suma elementelor din sectorul S, N, V,E
            Console.WriteLine();
            Console.WriteLine("Suma elementelor: ");
            SumCardinale(matrix2);
            
        }

        private static void SumCardinale(int[,] matrix2)
        {
            int i, j, s1=0, s2=0, s3=0, s4=0;
            int n = matrix2.GetLength(0);
            for (i = 0; i <= n - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    if (i < j && i + j < n - 1)
                    {
                        s1 += matrix2[i,j];
                    }
                    else
                    {
                        if (i + j < n - 1 && i > j)
                        {
                            s2 += matrix2[i, j];
                        }
                        else
                        {
                            if (i > j && i + j > n - 1)
                            {
                                s3 += matrix2[i, j];
                            }
                            else
                            {
                                if (i < j && i + j > n - 1)
                                {
                                    s4 += matrix2[i, j];

                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("N: {0}, V: {1}, S: {2}, E: {3}",s1,s2,s3,s4);
        }

        private static int SumDiagK(int[,] matrix2, int k)
        {
            int sum = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for(int j = 0; j < matrix2.GetLength(0); j++)
                {
                    if ( Math.Abs(i-j)<=k || i == j) sum += matrix2[i, j];
                }
            }
            return sum;
        }

        private static int SumDiag2Below(int[,] matrix2)
        {
            int sum = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if ((i + j) >= (matrix2.GetLength(0) )) sum += matrix2[i, j];

                }
            }
            return sum;
        }

        private static int SumDiag2Above(int[,] matrix2)
        {
            int sum = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if ((i + j) < (matrix2.GetLength(0)-1)) sum += matrix2[i, j];

                }
            }
            return sum;
        }
        
        private static int SumDiagBelow(int[,] matrix2)
        {
            int sum = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if (i > j) sum += matrix2[i, j];

                }
            }
            return sum;
        }

        private static int SumDiagAbove(int[,] matrix2)
        {
            int sum = 0;
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    if(i<j) sum += matrix2[i,j];

                }
            }
            return sum;
        }
    
        private static int SumDiag2(int[,] matrix2)
        {
            int sum = 0;



            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                sum += matrix2[i, matrix2.GetLength(0) - i - 1];
            }

            return sum;
        }

        private static int SumDiag(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private static void ParcurgereSpirala(int[,] matrix)
        {

            StreamReader sr = new StreamReader("input.txt");
            string line;
            line = sr.ReadLine();
            char[] sep = { ' ', '\t' };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);
            for (int i = 0; i < n / 2 + n % 2; i++)
            {
                if ((n - i - 1) >= i)
                    for (int j = i; j <= m - i - 1; j++)
                        Console.Write("{0}, ", matrix[i, j]);
                if (i <= (m - i - 1))
                    for (int j = i + 1; j <= n - i - 1; j++)
                        Console.Write("{0}, ", matrix[j, m - i - 1]);
                if ((n - i - 1) > i)
                    for (int j = m - i - 2; j >= i; j--)
                        Console.Write("{0}, ", matrix[n - i - 1, j]);
                if (i < (m - i - 1))
                    for (int j = n - i - 2; j >= i + 1; j--)
                        Console.Write("{0}, ", matrix[j, i]);
            }
        }

        private static int[,] Product(int[,] matrix1, int[,] matrix2)
        {
            int[,] result;
            result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int suma = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        suma += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = suma;
                }
            }


            return result;
        }

        private static void SortByLineSum(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (LineSum(matrix, i) > LineSum(matrix, j))
                        SwapLines(matrix, i, j);
                }
            }
        }

        private static void SwapLines(int[,] matrix, int i, int j)
        {
            int aux;
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                aux = matrix[i, k];
                matrix[i, k] = matrix[j, k];
                matrix[j, k] = aux;
            }
        }

        private static int LineSum(int[,] matrix, int i)
        {
            int sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
            return sum;
        }

        private static int SumaMaxime(int[,] matrix)
        {
            int suma = 0;
            int maxim;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                maxim = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxim)
                    {
                        maxim = matrix[i, j];
                    }
                }
                suma += maxim;
            }

            return suma;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix(string fileName)
        {
            int linii, coloane;

            StreamReader sr = new StreamReader(fileName);

            string line;

            line = sr.ReadLine();
            char[] sep = {' ', '\t'};
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            linii = int.Parse(tokens[0]);
            coloane = int.Parse(tokens[1]);

            int[,] matrix = new int[linii, coloane];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line = sr.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(tokens[j]);
                }
            }
            return matrix;
        }
    }
}
