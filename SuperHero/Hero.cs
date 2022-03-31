namespace SuperHero
{
    public enum HeroType
    {
        Hero,
        Villain
    }

    internal class Hero
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public int HeroId { get; set; }

        public HeroType Type { get; set; }

        public int DeedTime { get; set; }

        public List<string> HeroPowerList { get; set; }

        public Hero()
        {
            Name = "John";
            Surname = "Smith";
            Nickname = "Hero";
            HeroId = 0;
            Type = HeroType.Hero;
            DeedTime = 0;
            HeroPowerList = new List<string>();
            Age = 18;
        }

        public Hero(string name, string surname, string nickname,
            int heroId, HeroType type, int deedTime, List<string> heroPowerList, int age)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            HeroId = heroId;
            Type = type;
            DeedTime = deedTime;
            HeroPowerList = heroPowerList;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}\n Surname: {Surname}" +
                $"\n Nickname: {Nickname}\n HeroID: {HeroId} " +
                $"\n Type : {Type} \n Deedtime: {DeedTime}");
        }

        public int CalculateLevel()
        {
            int level = 0;
            if (DeedTime < 20)
            {
                level = 1;
            }
            if (DeedTime >= 20 && DeedTime <= 40)
            {
                level = 2;
            }
            if (DeedTime > 40)
            {
                level = 3;
            }

            return level;
        }

        public void PrintGeneralInfo()
        {
            Console.WriteLine("*********************GENERAL INFO******************");
            Console.WriteLine($"Hero: {Nickname}");
            Console.WriteLine($"Age:  {Age} year old");
            Console.WriteLine($"Hero powers2d array: \n ");
            for (int i = 0; i < HeroPowerList.Count; i++)
            {
                Console.WriteLine($"{i}. {HeroPowerList[i]} ");
            }
            Console.WriteLine("******************************************** \n \n");
        }

        public void PrintFinancialInfo()
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
