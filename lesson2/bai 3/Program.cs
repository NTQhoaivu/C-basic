using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        int check = 0;
        string[] s ={ "Event-Assign", "Event-View", "Event-Assign", "Event-Acept", "Event-Delete", "Event-Assign", "Event-Acept", "Event-Delete", "Event-Delete", "Event-View", "Event-Assign", "Event-Acept", "Event-Delete", "Event-Assign" };
        for (int i = 0; i < (s.Length - 3); i++)
        {
            if (s[i] == "Event-View" && s[i + 1] == "Event-Assign" && s[i + 2] == "Event-Acept" && s[i + 3] == "Event-Delete")
            {
                check=check+1;
                Console.WriteLine("ví trí bắt đầu giao dịch {0} ", i + 1);
            }
        }
        
        Console.WriteLine("số giao dịch :{0}", check);
        Console.WriteLine("----------------------------------------------------");
        int check1 = 0;
        for (int i = 0; i < (s.Length); i++)
        {
            if (s[i] == "Event-Acept")
            {
                check1 = check1 + 1;
                Console.WriteLine("ví trí sự kiện  {0} ", i + 1);
            }
        }
        Console.WriteLine("số sự kiện Event-Acept là:{0}", check1);

    }
}