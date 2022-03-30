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

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public int HeroId { get; set; }

        public HeroType Type { get; set; }

        public int DeedTime { get; set; }

        public Hero()
        {
            Name = "John";
            Surname = "Smith";
            Nickname = "Hero";
            HeroId = 0;
            Type = HeroType.Hero;
            DeedTime = 0;
        }

        public Hero(string name, string surname, string nickname,
            int heroId, HeroType type, int deedTime)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            HeroId = heroId;
            Type = type;
            DeedTime = deedTime;
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
    }
}
