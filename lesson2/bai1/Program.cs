using System;

namespace bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] i = { 2, 3, 1, 5, 4, 6, 8, 20, 14 };
            int min = 100;
            for (int j = 0; j < i.Length; j++) {
                if (i[j] < min) {
                    min = i[j];
                }
            }
            Console.WriteLine("min : {0}",min);
            Console.ReadLine();
        }
    }
}
