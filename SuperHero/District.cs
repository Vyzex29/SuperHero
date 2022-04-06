namespace SuperHero
{
    internal class District
    {

        public string Title { get; set; }

        public string City { get; set; }

        public int  DistrinctID { get; set; }

        public List<Hero> HeroesInTheDistrict { get; set; }

        public List<Villain> VillainsInTheDistrict { get; set; }

        public District(string title, string city, int distrinctID, List<Hero> heroesInTheDistrict, List<Villain> villainsInTheDistrict)
        {
            Title = title;
            City = city;
            DistrinctID = distrinctID;
            HeroesInTheDistrict = heroesInTheDistrict;
            VillainsInTheDistrict = villainsInTheDistrict;
        }

        public void addNewHero(Hero hero)
        {
            HeroesInTheDistrict.Add(hero);
        }

        public void RemoveHero(int index)
        {
            HeroesInTheDistrict.RemoveAt(index);
        }

        public void PrintInfoAboutDistrict()
        {
            Console.WriteLine($"{City}: {Title}, ID: {DistrinctID}");
            PrintListOfHeroes();
            PrintListOfVillains();
        }
        public void PrintListOfHeroes()
        {
            Console.WriteLine("============List=of=superheroes============");
            for (int i = 0; i < HeroesInTheDistrict.Count; i++)
            {
                Console.WriteLine($"{i}. {HeroesInTheDistrict[i].Nickname}");
            }
            Console.WriteLine("===========================================");
        }

        public void PrintListOfVillains()
        {
            Console.WriteLine("============List=of=Villains============");
            for (int i = 0; i < VillainsInTheDistrict.Count; i++)
            {
                Console.WriteLine($"{i}. {VillainsInTheDistrict[i].Nickname}");
            }
            Console.WriteLine("===========================================");
        }

        public float CalculateAvgHeroLevelInDistrict()
        {
            float MaxLevel = 0f;

            foreach (var hero in HeroesInTheDistrict)
            {
                MaxLevel += hero.CalculateLevel();
            }
            var averageLevel = MaxLevel / HeroesInTheDistrict.Count;

            return averageLevel;
        }

        public int CalculateTotalCrimeTime()
        {
            int totalCrimeTime = 0;
            foreach(var villain in VillainsInTheDistrict)
            {
                totalCrimeTime += villain.CrimeTime;
            }

            return totalCrimeTime;
        }
    }
}
