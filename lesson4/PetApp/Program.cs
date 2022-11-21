namespace PetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> pet = new List<Animal>();
            string chose;
            do
            {
                Console.WriteLine("Chose type of pet :");
                chose = Console.ReadLine().ToLower();
                switch (chose)
                {
                    case "dog":
                        Dog dog = new Dog();
                        Console.WriteLine("Input height of the dog:");


                        dog.Height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input weight of the dog:");
                        dog.Weight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input Color of the dog:");
                        dog.Color = Console.ReadLine();
                        pet.Add(dog);

                        break;
                    case "cat":
                        Meo meo = new Meo();
                        Console.WriteLine("Input height of the meo:");


                        meo.Height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input weight of the meo:");
                        meo.Weight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input Color of the meo:");
                        meo.Color = Console.ReadLine();
                        pet.Add(meo);
                        break;
                    case "pig":
                        Pig pig = new Pig();
                        Console.WriteLine("Input height of the pig:");


                        pig.Height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input weight of the pig:");
                        pig.Weight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input Color of the pig:");
                        pig.Color = Console.ReadLine();
                        pet.Add(pig);

                        break;
                    case "chicken":
                        Chicken chicken = new Chicken();
                        Console.WriteLine("Input height of the chicken:");


                        chicken.Height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input weight of the chicken:");
                        chicken.Weight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input Color of the chicken:");
                        chicken.Color = Console.ReadLine();
                        pet.Add(chicken);

                        break;
                    default:
                        break;
                }
            } while (chose != "exit");
            foreach (Animal p in pet)
            {
                p.Talk();
            }

        }
    }
}