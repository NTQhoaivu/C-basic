using System;
using System.Text;

namespace bai2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            int check = 0;
            do
            {
                Console.WriteLine("Nhập ngày mà bạn muốn");
                string day = Console.ReadLine();
                check = 0;
                switch (day)
                {
                    case "2":
                        Console.WriteLine("Thứ 2");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Thứ 3");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Thứ 4");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Thứ 5");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Thứ 6");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Thứ 7");
                        Console.ReadLine();
                        break;
                    case "cn":
                        Console.WriteLine("Chủ Nhật");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Bạn đã nhập sai định dạng. hãy nhập lại");
                        check = 1;
                        break;
                }
            } while (check == 1);
        }
    }
}
