using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int T,n,contor=0;
            Console.Write("n= ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti cele n elemente: ");
            int[] v = new int[100000];
            for(int i=0;i<n;i++)
            {
                v[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Numarul de intervale T= ");
            T = int.Parse(Console.ReadLine());

            int[]s = new int[100000];
            int[]d = new int[100000];

            Console.WriteLine("Introduceti intervalele: ");
            for(int i=0;i<T;i++)
            {
                Console.Write("x{0},y{0}=", i);
                s[i]= int.Parse(Console.ReadLine());
                d[i]= int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("Cele {0} numere introduse sunt: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", v[i]); ;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Intervalele sunt: ");
            for (int i = 0; i < T; i++)
            {
                {
                    Console.Write("(x"+i+",y"+i+")="+"("+s[i]+","+d[i]+")");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Raspuns: ");
            for(int i = 0; i < T; i++)
            {
                contor = 0;
                for(int j = 0; j<n;j++)
                {
                    if (v[j] <= d[i] && v[j] >= s[i]) contor++;
                }
                Console.WriteLine(contor+" numar/numere gasite pentru intervalul ("+ s[i] + ","+d[i]+")");
            }
        }
    }
}
