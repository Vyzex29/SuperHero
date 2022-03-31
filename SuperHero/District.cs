namespace SuperHero
{
    internal class District
    {

        public string Title { get; set; }

        public string City { get; set; }

        public int  DistrinctID { get; set; }

        public List<Hero> HeroesInTheDistrict { get; set; }

        public District(string title, string city, int distrinctID, List<Hero> heroesInTheDistrict)
        {
            Title = title;
            City = city;
            DistrinctID = distrinctID;
            HeroesInTheDistrict = heroesInTheDistrict;
        }

        public void addNewHero(Hero hero)
        {
            HeroesInTheDistrict.Add(hero);
        }

        public void RemoveHero(int index)
        {
            HeroesInTheDistrict.RemoveAt(index);
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

        public float CalculateAvgLevelInDistrict()
        {
            float MaxLevel = 0f;

            foreach (var hero in HeroesInTheDistrict)
            {
                MaxLevel += hero.CalculateLevel();
            }
            var averageLevel = MaxLevel / HeroesInTheDistrict.Count;

            return averageLevel;
        }
    }
}
