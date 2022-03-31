namespace SuperHero
{
    internal class District
    {
        public string Title { get; set; }

        public string City { get; set; }

        public int DistrinctId { get; set; }

        public List<Hero> HeroesInTheDistrict { get; set; }


        public District(string title, string city, int distrinctId, List<Hero> heroesInTheDistrict)
        {
            Title = title;
            City = city;
            DistrinctId = distrinctId;
            HeroesInTheDistrict = heroesInTheDistrict;
        }

        public void AddHero(Hero hero)
        {
            Console.WriteLine($"We have added to {Title} hero {hero.Nickname}");
            HeroesInTheDistrict.Add(hero);
        }

        public void RemoveHero(int position) 
        {
            Console.WriteLine($"We removed the hero {HeroesInTheDistrict[position].Nickname} from {Title}");
            HeroesInTheDistrict.RemoveAt(position);
        }

        public float CalculateAvgLevelInDistrict()
        {
            float totalHeroLevel = 0f;
            foreach (Hero hero in HeroesInTheDistrict)
            {
                totalHeroLevel += hero.CalculateLevel();
            }
            float averageLevelInDistrict = totalHeroLevel / HeroesInTheDistrict.Count;

            return averageLevelInDistrict;
        }

        public void PrintInformationAboutDistrict()
        {
            Console.WriteLine($"======={City}=======");
            Console.WriteLine($"District: {Title}");
            Console.WriteLine($"Id : {DistrinctId}");
            Console.WriteLine($"Heroes:");
            foreach (Hero hero in HeroesInTheDistrict)
            {
                hero.PrintInfo();
            }
        }
    }
}
