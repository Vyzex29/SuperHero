namespace SuperHero
{
    internal class District
    {

        public string Title { get; set; }

        public string City { get; set; }

        public int  DistrinctID { get; set; }

        public List<Person> PeopleInTheDistrict { get; set; }

        public District(string title, string city, int distrinctID, List<Person> peopleInTheDistrict)
        {
            Title = title;
            City = city;
            DistrinctID = distrinctID;
            PeopleInTheDistrict = peopleInTheDistrict;
        }

        public void addNewHero()
        {
            Console.WriteLine("What is the new superhero name?");
            string superHeroName = Console.ReadLine();
            Hero newHero = new Hero();
            newHero.Nickname = superHeroName;
            Console.WriteLine($"SuperHero {superHeroName} Added!");
            PeopleInTheDistrict.Add(newHero);
        }

        public void RemovePerson()
        {
            Console.WriteLine("Which person to remove?");
            PrintListOfPeople();
            int.TryParse(Console.ReadLine(), out int positionToRemove);
            Console.WriteLine($"Person {PeopleInTheDistrict[positionToRemove]} Removed!");
            PeopleInTheDistrict.RemoveAt(positionToRemove);
        }

        public void PrintListOfPeople()
        {
            Console.WriteLine("============List=Of=People============");
            for (int i = 0; i < PeopleInTheDistrict.Count; i++)
            {
                Console.WriteLine($"{i}. {PeopleInTheDistrict[i].Nickname}");
            }
            Console.WriteLine("===========================================");
        }

        public float CalculateAvgHeroLevelInDistrict()
        {
            float MaxLevel = 0f;
            int heroCount = 0;
            foreach (Person person in PeopleInTheDistrict)
            {
                if (person is Hero)
                {
                    MaxLevel += person.CalculateLevel();
                    heroCount++;
                }
            }
            var averageHeroLevel = MaxLevel / heroCount;

            return averageHeroLevel;
        }

        public int CalculateMaxVillainLevelInDistrict()
        {
            int maxLevel = 0;
            foreach (Person person in PeopleInTheDistrict)
            {
                if (person is Villain)
                {
                    Villain villain = (Villain)person;
                    if (maxLevel < villain.CrimeTime)
                    {
                        maxLevel = villain.CrimeTime;

                    }
                }
            }
            return maxLevel;
        }

        public void PrintMaxLevelVillainInDistrict()
        {
            int maxLevel = 0;
            string maxVillainName = string.Empty;
            var villainList = PeopleInTheDistrict.Where(person => person is Villain).ToList();
            foreach (Person person in villainList)
            {
                Villain villain = (Villain)person;
                if (maxLevel < villain.CrimeTime)
                {
                    maxLevel = villain.CrimeTime;
                    maxVillainName = villain.Nickname;
                }
            }
            Console.WriteLine($"The max crime time in {Title} is {maxVillainName} with {maxLevel} hours");
        }

        public void PrintOutSpecificPerson()
        {
            Console.WriteLine($"Please choose a superhero by number");

            PrintListOfPeople();

            int.TryParse(Console.ReadLine(), out int chosenNumber);
            Console.WriteLine($"You have chosen {PeopleInTheDistrict[chosenNumber].Nickname}");

            Console.WriteLine("Choose what type of info to show");
            Console.WriteLine($"1 - GENERAL INFO");
            Console.WriteLine($"2 - FINANCIAL INFO");
            string showMenu = Console.ReadLine();
            if (showMenu == "1")
            {
                PeopleInTheDistrict[chosenNumber].PrintGeneralInfo();
            }
            else if (showMenu == "2")
            {
                PeopleInTheDistrict[chosenNumber].PrintFinancialInfo();
            }

        }
    }
}
