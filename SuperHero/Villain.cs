namespace SuperHero
{

    internal class Villain : Person
    {
        public Villain(string name, string surname, string nickname, int age, List<string> heroPowerList, int villainId, int crimeTime) 
            : base(name, surname, nickname, age, heroPowerList)
        {
            VillainId = villainId;
            CrimeTime = crimeTime;
        }

        public int VillainId { get; set; }

        public int CrimeTime { get; set; }


        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"\n VillainID: {VillainId} " +
                $"\n CrimeTime: {CrimeTime}");
        }

        public override void PrintGeneralInfo()
        {
            base.PrintGeneralInfo();
            Console.WriteLine($"VillainID: {VillainId}");
            Console.WriteLine($"CrimeTime: {CrimeTime}");
            Console.WriteLine("******************************************** \n \n");
        }

    }
}
