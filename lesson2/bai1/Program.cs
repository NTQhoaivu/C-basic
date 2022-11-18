using System;

namespace bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] i = { 2, 3, 1, 5, 4, 6, 8, 20, 14 };
            void FindMin(int[] a, ref int minx)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] < minx)
                    {
                        minx = a[j];
                    }
                }
            }
            if (i[0] != null)
            {
                int min = i[0];

                FindMin(i, ref min);
                Console.WriteLine("min : {0}", min);
            }
            else
            {
                Console.WriteLine("wrong type");
            }
            Console.ReadLine();
        }
    }
}
