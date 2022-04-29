namespace SuperHero
{
    public class Hero : Person
    {
        public int DeedTime { get; set; }

        public Hero() : base(1, "John", "Smith", "Hero", new List<Superpower>())
        {
            DeedTime = 0;
        }

        public Hero(string name, string surname, string nickname,
            int heroId, List<Superpower> heroPowerList) : base(heroId, name, surname,nickname, heroPowerList)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            PowerList = heroPowerList;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"\n HeroID: {Id} " +
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
            Console.WriteLine($"HeroID: {Id}");
            Console.WriteLine($"Deedtime: {DeedTime}");
            Console.WriteLine("******************************************** \n \n");
        }

    }
}
