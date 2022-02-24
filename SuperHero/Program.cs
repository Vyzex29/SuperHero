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

            Console.WriteLine("********************************************");
            Console.WriteLine($"Hero: {name}");
            Console.WriteLine("Age: " + age + " year old");
            Console.WriteLine("Hero powers: \n {0}, \n {1},\n {2}\n", heroPower1, heroPower2, heroPower3);
            Console.WriteLine($"Hero powers: {heroPower1},  {heroPower2}, {heroPower3}");
            Console.WriteLine("********************************************");
        }
    }
}