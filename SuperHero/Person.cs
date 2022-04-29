namespace SuperHero
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public List<Superpower> PowerList { get; set; }


        public Person(int id, string name, string surname, string nickname,List<Superpower> heroPowerList)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Nickname = nickname;
            PowerList = heroPowerList;
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
            Console.WriteLine($"Person's powers: \n ");
            for (int i = 0; i < PowerList.Count; i++)
            {
                Console.WriteLine($"{i}. {PowerList[i].Name} ");
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
