namespace SuperHero
{
    internal class Hero : Person
    {
        public int HeroId { get; set; }

        public int DeedTime { get; set; }

        public Hero() : base("John", "Smith", "Hero",18, new List<string>())
        {
            HeroId = 0;
            DeedTime = 0;
        }

        public Hero(string name, string surname, string nickname,
            int heroId, int deedTime, List<string> heroPowerList, int age) : base(name, surname,nickname,age, heroPowerList)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            HeroId = heroId;
            DeedTime = deedTime;
            PowerList = heroPowerList;
            Age = age;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"\n HeroID: {HeroId} " +
                $"\n Deedtime: {DeedTime}");
        }

        public override int CalculateLevel()
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
            Console.WriteLine($"HeroID: {HeroId}");
            Console.WriteLine($"Deedtime: {DeedTime}");
            Console.WriteLine("******************************************** \n \n");
        }

    }
}
