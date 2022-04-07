
namespace SuperHero // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero defaultHero = new Hero();

            string[,] superHeroPowers2D = {
                { "flight","laser eyes", "X-Ray vision" },
                {"beer", "vodka", "gin" },
                {"bat","car", "robin" }
            };

            for (int i = 0; i < superHeroPowers2D.GetLength(1); i++)
            {
                defaultHero.PowerList.Add(superHeroPowers2D[0,i]);
            }
            var netManHeroPowers = new List<string>();
            for (int i = 0; i < superHeroPowers2D.GetLength(1); i++)
            {
                netManHeroPowers.Add(superHeroPowers2D[1, i]);
            }

            var sonicHeroPower = new List<string>();
            for (int i = 0; i < superHeroPowers2D.GetLength(1); i++)
            {
                sonicHeroPower.Add(superHeroPowers2D[2, i]);
            }
            Hero netMan = new Hero("Valera", "Dik", ".NetMan",1, 21, netManHeroPowers, 20);
            Hero sonic = new Hero("Kent","Clark","Sonic", 2, 46,sonicHeroPower, 24 );
            Villain amy = new Villain("Amy", "Killiko","Killer Amy",25, new List<string> { "Fast", "Killer gaze", "Sleeping touch"}, 0, 40);
            
            List<Person> kengaragsHeroList = new List<Person>();
            kengaragsHeroList.Add(defaultHero);
            kengaragsHeroList.Add(netMan);
            kengaragsHeroList.Add(sonic);
            kengaragsHeroList.Add(amy);

            District kengarags = new District("Kengarags", "Riga", 0, kengaragsHeroList);

            bool isMenuRunning = true;
            do
            {
                string menuItems;
                PrintMenu();
                menuItems = Console.ReadLine();

                switch (menuItems)
                {
                    case "1":
                        kengarags.PrintListOfPeople();
                        break;
                    case "2":
                        kengarags.PrintOutSpecificPerson();
                        break;
                    case "3":
                        kengarags.addNewHero();
                        break;
                    case "4":
                        kengarags.RemovePerson();
                        break;
                    case "5":
                        foreach (Person person in kengarags.PeopleInTheDistrict)
                        {
                            if (person.CalculateLevel() > 1)
                            {
                                Console.WriteLine($"{person.Nickname} is higher than level 1");
                            }
                        }
                        break;
                    case "6":
                        Console.WriteLine($"Average hero level in {kengarags.Title} is: {kengarags.CalculateAvgHeroLevelInDistrict()}");
                        break;
                    case "7":
                        isMenuRunning = false;
                        Console.WriteLine($"Good bye!");
                        break;
                    case "8":
                        Console.WriteLine($"The max crime time in {kengarags.Title} is {kengarags.CalculateMaxVillainLevelInDistrict()}");
                        kengarags.PrintMaxLevelVillainInDistrict();
                        break;
                    default:
                        Console.WriteLine("Please choose from the available menu!");
                        break;
                }
            } while (isMenuRunning);
            
        }

        private static void PrintMenu()
        {
            Console.WriteLine($"\nWelcome to the superhero application!");
            Console.WriteLine($"Select what to do:");
            Console.WriteLine($"1 - Show a list of superheroes");
            Console.WriteLine($"2 - Show specific hero");
            Console.WriteLine($"3 - Adding a superhero");
            Console.WriteLine($"4 - Deleting a superhero");
            Console.WriteLine($"5 - OOP hero");
            Console.WriteLine($"6 - Calculate Average heroes level");
            Console.WriteLine($"7 - Exit");
        }
    }
}
