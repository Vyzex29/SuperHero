namespace SuperHero
{
    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public List<string> PowerList { get; set; }


        public Person(string name, string surname, string nickname, int age,List<string> heroPowerList)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            PowerList = heroPowerList;
            Age = age;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}\n Surname: {Surname}" +
                $"\n Nickname: {Nickname}");
        }

        public virtual void PrintGeneralInfo()
        {
            Console.WriteLine("*********************GENERAL INFO******************");
            Console.WriteLine($"Hero: {Nickname}");
            Console.WriteLine($"Age:  {Age} year old");
            Console.WriteLine($"Person's powers2d array: \n ");
            for (int i = 0; i < PowerList.Count; i++)
            {
                Console.WriteLine($"{i}. {PowerList[i]} ");
            }
        }

        public virtual int CalculateLevel()
        {
            int level = 0;
            return level;
        }

        public virtual void PrintFinancialInfo()
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
    }
}
