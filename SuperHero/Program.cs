using SuperHero.Database;
using System.Data.SqlClient;
namespace SuperHero // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBConnection dbConnection = new DBConnection();
            SuperpowerManager superpowerManager = new SuperpowerManager(dbConnection);
            DeedsAndCrimeTimeCalculation deedsAndCrimeTimeCalculation = new DeedsAndCrimeTimeCalculation(dbConnection);
            PeopleManager peopleManager = new PeopleManager(dbConnection, superpowerManager);
            DistrictManager districtManager = new DistrictManager(dbConnection, peopleManager);

            List<District> districts = districtManager.GetDistricts();
            District kengarags = districts.FirstOrDefault(x => x.Title == "Kengarags");
            districtManager.SetAllTheDistrictsUpWithPeople(kengarags);
            deedsAndCrimeTimeCalculation.SetHeroDeedTime(kengarags.PeopleInTheDistrict);
            deedsAndCrimeTimeCalculation.SetVillainCrimeTime(kengarags.PeopleInTheDistrict);
            
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
                        kengarags.addNewHero(peopleManager, superpowerManager);
                        break;
                    case "4":
                        kengarags.RemovePerson(peopleManager);
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
