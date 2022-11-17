using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int check = 1;

        do
        {
            check = 1;
            Console.WriteLine("nhập ngày bạn mong muốn:");
            string day = Console.ReadLine().ToLower();
            switch (day)
            {
                case "2":
                    Console.WriteLine("Thứ 2.");
                    break;
                case "3":
                    Console.WriteLine("Thứ 3.");
                    break;
                case "4":
                    Console.WriteLine("Thứ 4.");
                    break;
                case "5":
                    Console.WriteLine("Thứ 5.");
                    break;
                case "6":
                    Console.WriteLine("Thứ 6.");
                    break;
                case "7":
                    Console.WriteLine("Thứ 7.");
                    break;
                case "cn":
                    Console.WriteLine("Chủ nhật .");
                    break;
                default:
                    Console.WriteLine("Bạn đã nhập sai định dạng hãy nhập lại .");
                    check=0;
                    break;
            }

        } while (check == 0);

    }
}