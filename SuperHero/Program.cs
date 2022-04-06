
namespace SuperHero // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero defaultHero = new Hero();

            string[,] superHeroPowers2D = {
                { "power1", "laser eyes", "great beer" },
                { "flight","2", "3" },
                {"beer", "vodka", "gin" },
                {"bat","car", "robin" }
            };

            for (int i = 0; i < superHeroPowers2D.GetLength(1); i++)
            {
                defaultHero.PowerList.Add(superHeroPowers2D[0, i]);
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
            Hero netMan = new Hero("Valera", "Dik", ".NetMan", 1, 21, netManHeroPowers, 20);
            Hero sonic = new Hero("Kent", "Clark", "Sonic", 2, 46, sonicHeroPower, 24);
            List<Hero> kengaragsHeroes = new List<Hero>();
            kengaragsHeroes.Add(defaultHero);
            kengaragsHeroes.Add(netMan);
            kengaragsHeroes.Add(sonic);

            
            Villain electro = new Villain("George", 25, "Kreed", "Electro", new List<string> {"electric hands", "lightining fast"},1,50);
            List<Villain> villains = new List<Villain>();
            villains.Add(electro);
            List<Hero> purvciemHeroes = new List<Hero> ();
            List<Villain> purvciemVillains = new List<Villain>();
            District kengarags = new District("Kengarags", "Riga", 0, kengaragsHeroes, villains);
            District purvciems = new District("Purvciems","Riga",1, purvciemHeroes, purvciemVillains);

            /*var foundHero = metropole.Find(find => find.Name == "Valera");
            Console.WriteLine($"We found {foundHero.Nickname}");
            metropole.Remove(foundHero);

            for (int i = 0; i < metropole.Count; i++)
            {
               Console.WriteLine(metropole[i].Nickname);
            }*/


            bool isMenuRunning = true;
            do
            {
                string menuItems;
                PrintMenu();
                menuItems = Console.ReadLine();

                switch (menuItems)
                {
                    case "1":
                        kengarags.PrintListOfHeroes();
                        break;
                    case "2":
                        Console.WriteLine($"Please choose a superhero by number");

                        kengarags.PrintListOfHeroes();

                        int.TryParse(Console.ReadLine(), out int chosenNumber);
                        Console.WriteLine($"You have chosen {kengarags.HeroesInTheDistrict[chosenNumber].Nickname}");

                        Console.WriteLine("Choose what type of info to show");
                        Console.WriteLine($"1 - GENERAL INFO");
                        Console.WriteLine($"2 - FINANCIAL INFO");
                        string showMenu = Console.ReadLine();
                        if (showMenu == "1")
                        {
                            kengarags.HeroesInTheDistrict[chosenNumber].PrintGeneralInfo();
                        }
                        else if (showMenu == "2")
                        {
                            kengarags.HeroesInTheDistrict[chosenNumber].PrintFinancialInfo();
                        }

                        break;
                    case "3":
                        Console.WriteLine("What is the new superhero name?");
                        string superHeroName = Console.ReadLine();
                        Hero newHero = new Hero();
                        newHero.Nickname = superHeroName;
                        kengarags.addNewHero(newHero);
                        Console.WriteLine($"SuperHero {superHeroName} Added!");
                        break;
                    case "4":
                        Console.WriteLine("Which superhero to remove?");
                        kengarags.PrintListOfHeroes();
                        int.TryParse(Console.ReadLine(), out int positionToRemove);
                        Console.WriteLine($"SuperHero {kengarags.HeroesInTheDistrict[positionToRemove]} Removed!");
                        kengarags.RemoveHero(positionToRemove);
                        break;
                    case "5":
                        Console.WriteLine($"{defaultHero.Nickname} level is {defaultHero.CalculateLevel()}");
                        foreach (Hero hero in kengarags.HeroesInTheDistrict)
                        {
                            if (hero.CalculateLevel() > 1)
                            {
                                Console.WriteLine($"{hero.Nickname} is higher than level 1");
                            }
                        }
                        break;
                    case "6":
                        Console.WriteLine($"Average level in {kengarags.Title} is: {kengarags.CalculateAvgHeroLevelInDistrict()}");
                        break;
                    case "7":
                        isMenuRunning = false;
                        Console.WriteLine($"Good bye!");
                        break;
                    case "8":
                        kengarags.PrintListOfVillains();

                        Console.WriteLine($"Total CrimeTime is :{kengarags.CalculateTotalCrimeTime()}");
                        break;
                    case "9":
                        kengarags.PrintInfoAboutDistrict();
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
