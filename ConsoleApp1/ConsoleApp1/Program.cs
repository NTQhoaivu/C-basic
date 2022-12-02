using System;

namespace RectangleApplication
{
    class Rectangle
    {
        protected double length;
        protected double width;

        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }

        public async Task<int> DisplayAsync()
        {
            await Task.Delay(3000);
            return 1;
        }
    }
    class Tabletop : Rectangle
    {
        public Tabletop(double l, double w) : base(l, w)
        { }

        public double GetCost()
        {
            return GetArea() * 70;
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine("Cost: {0}", GetCost());
        }
    }
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle tabletop = new Rectangle(4, 3);
            Task<int> a = tabletop.DisplayAsync();
            tabletop.Display();
            Console.ReadLine();
        }
    }

    abstract class Animal
    {
        public abstract void Speak();

    }

}