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
            string name = ".Net man";
            int age = 33;
            string heroPower1, heroPower2, heroPower3;
            heroPower1 = "Can compile .net code in his mind";
            heroPower2 = "Knows all of .net versions quirks";
            heroPower3 = "Knows all the answers to your .net questions";
            double salary = 1000; // Monthly
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

            if (!isEvil)
            {
                Console.WriteLine("Protects the city and earns his cookies");
            }
            else
            {
                Console.WriteLine("The villain is stealing the cookie supply");
            }


        }
    }
}