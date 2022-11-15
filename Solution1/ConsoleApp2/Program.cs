using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        string old;

        Boolean a;
        int olds;
        int check = 1;
        do
        {
            Console.WriteLine("nhập tuổi của bạn:");
            old = Console.ReadLine();
            a = int.TryParse(old, out olds);

            if (a == true)
            {
                Console.WriteLine("Tôi năm nay  :" + olds + " tuổi.");
                check = 1;
            }
            else
            {
                Console.WriteLine("Hãy nhập lại đúng định dạng.");
                check = 0;
            }
        }while (check == 0);
    }
}