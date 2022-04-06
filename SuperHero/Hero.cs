namespace SuperHero
{

    internal class Hero : Person
    {
        public int HeroId { get; set; }

        public int DeedTime { get; set; }

        public Hero() : base("John",18,"Smith","Hero", new List<string>())
        {
            HeroId = 0;
            DeedTime = 0;
        }

        public Hero(string name, string surname, string nickname,
            int heroId, int deedTime, List<string> powerList, int age) : base (name, age,surname,nickname,powerList)
        {  
            HeroId = heroId;
            DeedTime = deedTime;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}\n Surname: {Surname}" +
                $"\n Nickname: {Nickname}\n HeroID: {HeroId} " +
                $"\n Deedtime: {DeedTime}");
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

        public override void PrintGeneralInfo()
        {
            base.PrintGeneralInfo();
            Console.WriteLine($"Hero DEED time: {DeedTime}");
            Console.WriteLine($"HeroID: {HeroId}");
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
