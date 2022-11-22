using System.ComponentModel.Design;
using System.Drawing;
using System.Text.RegularExpressions;

namespace PetApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> pet = new List<Animal>(){
            new Cat
            {
                Id = 1,
                Name = "d",
                Height = 50,
                Weight = 5,
                Color = "Yellow"
            },
            new Dog
            {
                Id = 2,
                Name = "c",
                Height = 70,
                Weight = 20,
                Color = "Black"
            },
            new Chicken
            {
                Id = 3,
                Name = "b",
                Height = 61,
                Weight = 3,
                Color = "White"
            },
            new Pig
            {
                Id = 4,
                Name = "a",
                Height = 65,
                Color = "Pink",
                Weight = 40
            }

        };
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
                    case "4":
                        Console.WriteLine("Input ID:");
                        int i = Convert.ToInt32(RemoveSpace(Console.ReadLine()));
                        FindIdRemove(pet, i);
                        break;
                    case "5":
                        Console.WriteLine("Input name");
                        string s =RemoveSpace(Console.ReadLine());

                        FindNameRemove(pet, s);
                        break;
                    case "2":
                        EditById(pet, 1, "test", 10, 10, "red");
                        break;
                    case "3":
                        EditByName(pet, "a", "test", 10, 10, "red");
                        break;
                    case "6":
                        ShowPet(pet);
                        break;
                    case "7":
                        check = 0;
                        break;
                    default:
                        Console.WriteLine("Wrong");

                        break;
                }
            } while (check != 0);


        }
        public static void Menu()
        {
            Console.WriteLine("===Menu===");
            Console.WriteLine("1.Add Pet");
            Console.WriteLine("2.Edit by ID");
            Console.WriteLine("3.Edit by Name");
            Console.WriteLine("4.Delete by ID");
            Console.WriteLine("5.Delete by Name");
            Console.WriteLine("6.Show Pet");
            Console.WriteLine("7.Exit");
        }
        public static void AddPet(List<Animal> pet)
        {
            string chose;
            do
            {
                Console.WriteLine("Chose type of pet (dog,cat,pig,chicken):");
                Console.WriteLine("type exit if you want to exit.");
                chose = RemoveSpace(Console.ReadLine().ToLower());
                switch (chose)
                {
                    case "dog":
                        Dog dog = new Dog();
                        string sDog;
                        dog.Id = pet.Count() + 1;
                        do
                        {
                            Console.WriteLine("Input name of the dog:");
                            dog.Name = RemoveSpaceName(Console.ReadLine());
                        } while (dog.Name == null);
                        do
                        {
                            do
                            {
                                Console.WriteLine("Input height of the dog(0-30cm):");
                                sDog = RemoveSpace(Console.ReadLine());
                            } while (sDog == "");

                            dog.Height = Convert.ToInt32(sDog);
                        } while (dog.Height == 0 || dog.Height < 0 || dog.Height > 30);

                        do
                        {
                            do
                            {
                                Console.WriteLine("Input weight of the dog(0-30kg):");
                                sDog = RemoveSpace(Console.ReadLine());
                            } while (sDog == "");

                            dog.Weight = Convert.ToInt32(sDog);
                        } while (dog.Weight == 0 || dog.Weight < 0 || dog.Weight > 30);

                        do
                        {
                            Console.WriteLine("Input Color of the dog:");
                            Console.WriteLine("Chose one of this color : red, orange, yellow, green, blue, indigo, violet.");
                            dog.Color = RemoveSpace(Console.ReadLine());
                        } while (dog.Color == null || CheckColor(dog.Color) == false);
                        pet.Add(dog);

                        break;
                    case "cat":
                        Cat cat = new Cat();
                        cat.Id = pet.Count() + 1;
                        string sCat;
                        do
                        {
                            Console.WriteLine("Input name of the Cat:");
                            cat.Name = (RemoveSpace(Console.ReadLine()));
                        } while (cat.Name == null);
                        do
                        {
                            do
                            {
                                Console.WriteLine("Input height of the Cat(0-30cm):");
                                sCat = RemoveSpace(Console.ReadLine());
                            } while (sCat == "");
                            cat.Height = Convert.ToInt32(sCat);
                        } while (cat.Height == 0 || cat.Height < 0 || cat.Height > 30);

                        do
                        {
                            do
                            {
                                Console.WriteLine("Input weight of the Cat(0-30kg):");
                                sCat = RemoveSpace(Console.ReadLine());
                            } while (sCat == "");

                            cat.Weight = Convert.ToInt32(sCat);
                        } while (cat.Weight == 0 || cat.Weight < 0 || cat.Weight > 30);

                        do
                        {
                            Console.WriteLine("Input Color of the Cat:");
                            Console.WriteLine("Chose one of this color : red, orange, yellow, green, blue, indigo, violet.");
                            cat.Color = RemoveSpace(Console.ReadLine());
                        } while (cat.Color == null || CheckColor(cat.Color) == false);
                        pet.Add(cat);
                        break;
                    case "pig":
                        Pig pig = new Pig();
                        pig.Id = pet.Count() + 1;
                        string sPig;
                        do
                        {
                            Console.WriteLine("Input name of the pig:");
                            pig.Name = (RemoveSpaceName(Console.ReadLine()));
                        } while (pig.Name == null);
                        do
                        {
                            do
                            {
                                Console.WriteLine("Input height of the pig(0-30cm):");
                                sPig = RemoveSpace(Console.ReadLine());
                            } while (sPig == "");

                            pig.Height = Convert.ToInt32(sPig);


                        } while (pig.Height == 0 || pig.Height < 0 || pig.Height > 30);

                        do
                        {
                            do
                            {
                                Console.WriteLine("Input weight of the pig(0-30kg):");
                                sPig = RemoveSpace(Console.ReadLine());
                            } while (sPig == "");


                            pig.Weight = Convert.ToInt32(sPig);
                        } while (pig.Weight == 0 || pig.Weight < 0 || pig.Weight > 30);

                        do
                        {
                            Console.WriteLine("Input Color of the pig:");
                            Console.WriteLine("Chose one of this color : red, orange, yellow, green, blue, indigo, violet.");
                            pig.Color = RemoveSpace(Console.ReadLine());
                        } while (pig.Color == null || CheckColor(pig.Color)==false);
                        pet.Add(pig);

                        break;
                    case "chicken":
                        Chicken chicken = new Chicken();
                        chicken.Id = pet.Count() + 1;
                        string sChicken;
                        do
                        {
                            Console.WriteLine("Input name of the chicken:");
                            chicken.Name = (Console.ReadLine());
                        } while (chicken.Name == null);

                        do
                        {
                            do
                            {
                                Console.WriteLine("Input height of the chicken(0-30cm):");
                                sChicken = RemoveSpace(Console.ReadLine());
                            } while (sChicken == "");

                            chicken.Height = Convert.ToInt32(sChicken);
                        } while (chicken.Height == 0 || chicken.Height < 0 || chicken.Height > 30);
                        do
                        {
                            do
                            {
                                Console.WriteLine("Input weight of the chicken(0-30kg):");
                                sChicken = RemoveSpace(Console.ReadLine());
                            } while (sChicken == "");

                            chicken.Weight = Convert.ToInt32(sChicken);
                        } while (chicken.Weight == 0 || chicken.Weight < 0 || chicken.Weight > 30);

                        do
                        {
                            Console.WriteLine("Input Color of the chicken:");
                            Console.WriteLine("Chose one of this color : red, orange, yellow, green, blue, indigo, violet.");
                            chicken.Color = RemoveSpace(Console.ReadLine());

                        } while (chicken.Color == null || CheckColor(chicken.Color) == false);


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
                string type = p.GetType().ToString().ToLower().Replace("petapp.", "");
                Console.WriteLine("/n");
                Console.WriteLine("Pet number: " + p.Id + " Type of pet:" + type);
                Console.WriteLine("Pet name: " + p.Name);
                Console.WriteLine("Pet height: " + p.Height);
                Console.WriteLine("Pet weight: " + p.Weight);
                Console.WriteLine("Pet Color: " + p.Color);
                p.Talk();
            }

        }
        public static void FindIdRemove(List<Animal> pet, int id)
        {
            Animal a;
            Console.WriteLine("ok");
            for (int i = 0; i < pet.Count; i++)
            {
                Animal p = pet[i];
                if (p.Id == id)
                {
                    pet.Remove(p);

                }
            }
            foreach (Animal p2 in pet)
            {
                if (p2.Id > id)
                {
                    p2.Id = p2.Id - 1;
                }
            }
            //return a;
        }
        public static void FindNameRemove(List<Animal> pet, String name)
        {
            foreach (Animal p2 in pet)
            {
                if (p2.Name == name)
                {
                    for (int i2 = p2.Id; i2 <= pet.Count; i2++)
                    {
                        p2.Id = p2.Id - 1;
                    }
                }
            }
            for (int i = 0; i < pet.Count; i++)
            {
                Animal p = pet[i];
                if (p.Name == name)
                {
                    pet.Remove(p);

                }
            }

            //return a;
        }
        public static void EditById(List<Animal> pet, int id, string name, int height, int weight, string color)
        {
            Animal a;
            for (int i = 0; i < pet.Count; i++)
            {
                Animal p = pet[i];
                if (p.Id == id)
                {
                    p.Name = name;
                    p.Height = height;
                    p.Weight = weight;
                    p.Color = color;

                }
            }

            //return a;
        }
        public static void EditByName(List<Animal> pet, String name, string rename, int height, int weight, string color)
        {
            foreach (Animal p in pet)
            {
                if (p.Name == name)
                {
                    p.Name = name;
                    p.Height = height;
                    p.Weight = weight;
                    p.Color = color;

                }
            }
        }

       
        public static string RemoveSpace(string sent)
        {

            sent = sent.Trim();
            var trimmer = new Regex(@"\s\s+");
            sent = trimmer.Replace(sent, " ");
            return sent;
        }
        public static string RemoveSpaceName(string sent)
        {

            sent = sent.Trim();
            return sent;
        }
        public static Boolean CheckColor(string color)
        {
            string mainColor = "red orange yellow green blue indigo violet";
            return mainColor.Contains(color);
        }
        public static bool HasSpecialCharacter(string s)
        {
            foreach (var c in s)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
            //var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            //if (regexItem.IsMatch(s))
            //{
            //    return true;
            //}
            //else return false;
        }
    }
}