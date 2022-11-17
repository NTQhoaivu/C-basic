using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] num = { 889, 100, 546, 1001, 2022, 579, 68, 99999, 4687 };
        int[] num2 = new int[];
        CheckNumber(num, ref num2);
        for (int i = 0; i < num2.Length; i++)
        {
            Console.WriteLine(num2[i]);
        }

    }
    public static void CheckNumber(int[] num, ref int[] num2)
    {
        int k = 0;
        for (int i = 0; i < num.Length; i++)
        {
            int check;
            do
            {
                check = num[i];
                check = check / 10;
            } while (check > 10);
            int a = check % 2;
            if (a == 1 || check == 10)
            {
                num2[k] = i;
                k++;
            }
        }
    }
    public static Boolean Check(int a)
    {
        do
        {

        } while (true);

        return false;
    }
}