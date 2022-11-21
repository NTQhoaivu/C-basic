// See https://aka.ms/new-console-template for more information
using OOP;

internal class Program
{
    private static void Main(string[] args)
    {
        Student p1 = new Student();
        Student p2 = new Student();
        Student p3 = new Student();

        Console.WriteLine("Enter 3 name :");
        p1.Name = Console.ReadLine();
        p2.Name = Console.ReadLine();
        p3.Name = Console.ReadLine();
        p1.Show();
        //Console.WriteLine(p1.Show());
        //Console.WriteLine(p2.Show());
        //Console.WriteLine(p3.Show());
    }
}