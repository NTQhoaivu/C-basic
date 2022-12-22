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
        Test t1;
        t1.echoa();
        Test.echob();

    }
 
}
   public class Test { 
        public int a=5;
        public static int b=5;
        public void echoa() {
        Console.WriteLine(a);}
        public static void echob() {
            Console.WriteLine(b);
    }
        }