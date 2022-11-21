using System.ComponentModel.Design;

namespace PetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> pet = new List<Animal>();
            string chose;
            int check = 1;
            do
            {
                Menu();
                chose = Console.ReadLine();
                switch (chose)
                {
                    case "1":
                        AddPet(pet);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        ShowPet(pet);
                        break;
                    case "exit":
                        check = 0;
                        break;
                    default:
                        Console.WriteLine("Wrong");
                        
                        break;
                }
            } while (check!=0);
            
            
        }
        public static void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Add Pet");
            Console.WriteLine("2.Edit by ID");
            Console.WriteLine("3.Edit by Name");
            Console.WriteLine("4.Delete by ID");
            Console.WriteLine("5.Delete by Name");
            Console.WriteLine("6.Show Pet");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void AddPet(List<Animal> pet)
        {
            string chose;
            do
            {
                Console.WriteLine("Chose type of pet :");
                chose = Console.ReadLine().ToLower();
                switch (chose)
                {
                    case "dog":
                        Dog dog = new Dog();
                        dog.Id = pet.Count()+1;
                        Console.WriteLine("Input name of the dog:");


                        dog.Name = (Console.ReadLine());
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
                        meo.Id = pet.Count()+1;
                        Console.WriteLine("Input name of the meo:");


                        meo.Name = (Console.ReadLine());
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
                        pig.Id = pet.Count();
                        Console.WriteLine("Input name of the pig:");


                        pig.Name = (Console.ReadLine());
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
                        chicken.Id = pet.Count()+1;
                        Console.WriteLine("Input name of the chicken:");


                        chicken.Name = (Console.ReadLine());
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
        }
        public static void ShowPet(List<Animal> pet)
        {
            foreach (Animal p in pet)
            {
                p.Talk();
                Console.WriteLine(p.GetType());
            }

        }
        //public static Animal FindID(List<Animal> pet, int id)
        //{
        //    Animal a ;
        //    foreach (var p in pet)
        //    {
        //        if (p.GetType()=="cat")
        //        {

        //        }
        //    }
        //    return a ;
        //}
    }
}