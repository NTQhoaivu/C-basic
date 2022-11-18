using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] num = { 889, 100, 546, 1001, 2022, 579, 68, 99999, 4687 };

        for (int i = 0; i < num.Length; i++)
        {
            int a = num[i];
            if (Check(a) == true)
            {
                Console.WriteLine(num[i]);
            }

        }

    }

    public static Boolean Check(int a)
    {

        do
        {
            a = a / 10;
        } while (a >= 10);
        int check = a % 2;
        if (check == 1 || a == 10)
        {
            return true;
        }

        return false;
    }
}