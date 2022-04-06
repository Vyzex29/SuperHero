namespace SuperHero
{
    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public List<string> PowerList { get; set; }


        public Person(string name, int age, string surname, string nickname, List<string> powerList)
        {
            Name = name;
            Age = age;
            Surname = surname;
            Nickname = nickname;
            PowerList = powerList;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}\n Surname: {Surname}" +
                $"\n Nickname: {Nickname}\n");
        }

        public virtual void PrintGeneralInfo()
        {
            Console.WriteLine("*********************GENERAL INFO******************");
            Console.WriteLine($"Hero: {Nickname}");
            Console.WriteLine($"Age:  {Age} year old");
            Console.WriteLine($"SuperPersons powers2d array: \n ");
            for (int i = 0; i < PowerList.Count; i++)
            {
                Console.WriteLine($"{i}. {PowerList[i]} ");
            }
        }
    }
}
