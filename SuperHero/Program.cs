/*
## Lesson 3 - Variables and Data Types

- Create variables:
    - Hero name - String
    - Hero age - int
    - Hero powers - heroPower1, heroPower2, heroPower3
    - Create "Hero Card" view. Print variables to console
*/

namespace SuperHero // Note: actual namespace depends on the project name.
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            string[] superHeroNameList = { ".Net man","Superman","Barman","Batman" };
            int[] superHeroAgeList = { 20, 21, 23, 24 };

            string[,] superHeroPowers2D = {
                { "power1", "laser eyes", "great beer" },
                { "flight","2", "3" },
                {"beer", "vodka", "gin" },
                {"bat","car", "robin" }
            };
            bool isMenuRunning = true;
            do
            {
                string menuItems;

                Console.WriteLine($"Welcome to the superhero application!");
                Console.WriteLine($"Select what to do:");
                Console.WriteLine($"1 - Show a list of superheroes");
                Console.WriteLine($"2 - Show specific hero");
                Console.WriteLine($"3 - Adding a superhero");
                Console.WriteLine($"4 - Deleting a superhero");
                Console.WriteLine($"5 - Exit");

                menuItems = Console.ReadLine();

                switch (menuItems)
                {
                    case "1":
                        Console.WriteLine("============List=of=superheroes============");
                        for (int i = 0; i < superHeroNameList.Length; i++)
                        {
                            Console.WriteLine($"{i}. {superHeroNameList[i]}");
                        }
                        Console.WriteLine("===========================================");
                        break;
                    case "2":
                        Console.WriteLine($"Please choose a superhero by number");

                        for (int i = 0; i < superHeroNameList.Length; i++)
                        {
                            Console.WriteLine($"{i}. {superHeroNameList[i]}");
                        }

                        int.TryParse(Console.ReadLine(), out int chosenNumber);
                        Console.WriteLine($"You have chosen {superHeroNameList[chosenNumber]}");

                        Console.WriteLine("Choose what type of info to show");
                        Console.WriteLine($"1 - GENERAL INFO");
                        Console.WriteLine($"2 - FINANCIAL INFO");
                        string showMenu = Console.ReadLine();
                        if (showMenu == "1")
                        {
                            Console.WriteLine("*********************GENERAL INFO******************");
                            Console.WriteLine($"Hero: {superHeroNameList[chosenNumber]}");
                            Console.WriteLine($"Age:  {superHeroAgeList[chosenNumber]} year old");
                            Console.WriteLine($"Hero powers2d array: \n ");
                            for (int i = 0; i < superHeroPowers2D.GetLength(1); i++)
                            {
                                Console.WriteLine($"{i}. {superHeroPowers2D[chosenNumber,i]} ");
                            }
                            Console.WriteLine("******************************************** \n \n");
                        }else if(showMenu == "2")
                        {
                            double salary = 1000;
                            int deedTimeInHours1, deedTimeInHours2, deedTimeInHours3;
                            deedTimeInHours1 = 5;
                            deedTimeInHours2 = 10;
                            deedTimeInHours3 = 15;
                            var totalTimeSpent = (deedTimeInHours1 + deedTimeInHours2 + deedTimeInHours3);
                            double rewardMoney = totalTimeSpent * 5;
                            salary += rewardMoney;
                            var averageTime = totalTimeSpent / 3;

                            double cookieCost = 1.29;
                            double boughtCookies = Math.Floor(salary / cookieCost);
                            double dailySalary = Math.Round(salary / 30, 2);


                            Console.WriteLine("************FINANCIAL INFO*****************");
                            Console.WriteLine($"The hero can buy {boughtCookies}");
                            Console.WriteLine($"Our hero earns daily {dailySalary}");
                            Console.WriteLine($"Our hero spent {totalTimeSpent} hours doing deeds");
                            Console.WriteLine($"Our hero on average spent {averageTime} hours per deed");
                            Console.WriteLine($"For the deeds our hero got as a reward {rewardMoney} EUR");
                        }


                        break;
                    case "3":
                        Console.WriteLine("What is the new superhero name?");
                        string superHeroName = Console.ReadLine();
                        superHeroNameList = superHeroNameList.Append(superHeroName);
                        Console.WriteLine($"SuperHero {superHeroName} Added!");
                        break;
                    case "4":
                        Console.WriteLine("Which superhero to remove?");
                        for (int i = 0; i < superHeroNameList.Length; i++)
                        {
                            Console.WriteLine($"{i}. {superHeroNameList[i]}");
                        }
                        int.TryParse(Console.ReadLine(),out int positionToRemove);
                        Console.WriteLine($"SuperHero {superHeroNameList[positionToRemove]} Removed!");
                        superHeroNameList = superHeroNameList.Remove(positionToRemove);
                        break;
                    case "5":
                        isMenuRunning = false;
                        Console.WriteLine($"Good bye!");
                        break;
                    default:
                        Console.WriteLine("Please choose from the available menu!");
                        break;
                }
            } while (isMenuRunning);
            



            string name = ".Net man";
            int age = 33;
            string heroPower1, heroPower2, heroPower3;
            heroPower1 = "Can compile .net code in his mind";
            heroPower2 = "Knows all of .net versions quirks";
            heroPower3 = "Knows all the answers to your .net questions";
            //double salary = 1000; // Monthly
            bool isEvil = false;

            Console.WriteLine("*********************GENERAL INFO******************");
            Console.WriteLine($"Hero: {name}");
            Console.WriteLine("Age: " + age + " year old");
            Console.WriteLine("Hero powers: \n {0}, \n {1},\n {2}\n", heroPower1, heroPower2, heroPower3);
            Console.WriteLine("******************************************** \n \n");



            // Cookie calculation
            /*
             * - Continue working on Hero Card view
                - Add new variables - deedTimeInHours1, deedTimeInHours2, deedTimeInHours3 (INT), holding time that a deed took to complete
                 - Add methods to calculate:
                - Total time spent on deeds
                - Average time spent on one deed
                - How many cookies Hero will get. 5 cookies per hour
             */

           

            if (!isEvil)
            {
                Console.WriteLine("Protects the city and earns his cookies");
            }
            else
            {
                Console.WriteLine("The villain is stealing the cookie supply");
            }


            // DEED
            char deed = 'A';

            switch (deed)
            {
                case 'A':
                case 'B':
                    Console.WriteLine("Perfect! You are so brave!");
                    break;
                case 'C':
                    Console.WriteLine("Good! But You can do better!");
                    break;
                case 'D':
                case 'E':
                    Console.WriteLine("It is not good! You should choose your bad or good side!");
                    break;
                case 'G':
                    Console.WriteLine("Bad, you are true villain");
                    break;
                default:
                    Console.WriteLine("Undefined grade, please regrade it");
                    break;
            }
        }
    }
}

//  BUSINESS REQUIREMENTS
// 1. I would like to see a menu, to select different parts of superhero information card
// 2. A list of superheroes - arrays/ maybe lists
// 3, Add a new superhero
// 4. Showing a specific superhero information
// 5. Delete the superhero from the list
//
//
//
//
// A. A list of their powers
// 
