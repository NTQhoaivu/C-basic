public delegate void stringDeligate(string text);
public class Program
{
    public static void Main(string[] args)
    {
        stringDeligate stringa = ToUpcase;
        stringa("test");
    }
    static void ToUpcase(string text) => Console.WriteLine(text.ToUpper());
    static void ToLowcase(string text) => Console.WriteLine(text.ToLower());
}