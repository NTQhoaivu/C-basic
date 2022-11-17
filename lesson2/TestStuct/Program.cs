using System.Diagnostics;

internal class Program
{

    class TestClass
    {
        public int n1;
        public int n2;
        public TestClass(int n01, int n02)
        {
            this.n1 = n01;
            this.n2 = n02;
        }
        public void ShowValue()
        {
            Console.WriteLine("{0},{1}" , this.n1, this.n2);
        }

    }
    struct TestStruct
    {
        public int n1;
        public int n2;
        public TestStruct(int n01, int n02)
        {
            this.n1 = n01;
            this.n2 = n02;

        }
        public void ShowValue()
        {
            Console.WriteLine("{0},{1}" , this.n1, this.n2);
        }


    }

    private static void Main(string[] args)
    {
        TestClass s1 = new TestClass(10, 20);
       TestStruct s2 =new TestStruct(10, 20);
         Console.WriteLine("Before add 100 class");
        s1.ShowValue();
        AddValue(s1);
        Console.WriteLine("After add 100 class ");
        s1.ShowValue();
        Console.WriteLine("-----------------------------------");

        Console.WriteLine("Before add 100 class ");
        s2.ShowValue();
        AddValue(s2);

        Console.WriteLine("After add 100 class ");
        s2.ShowValue();
    }
    private static void AddValue(TestClass A)
    {
        A.n1 += 100;
        A.n2 += 100;
    }
    private static void AddValue(TestStruct A)
    {
        A.n1 += 100;
        A.n2 += 100;
    }
}
