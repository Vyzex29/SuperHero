namespace SuperHero
{
    internal class Villain : Person
    {
        public Villain(string name, int age, string surname, string nickname, List<string> powerList, int villainId, int crimeTime) : base(name, age, surname, nickname, powerList)
        {
            VillainId = villainId;
            CrimeTime = crimeTime;
        }

        public int VillainId { get; set; }

        public int CrimeTime { get; set; }

        public override void PrintGeneralInfo()
        {
            base.PrintGeneralInfo();
            Console.WriteLine($"Villain's Crime time: {CrimeTime}");
            Console.WriteLine($"VillainID: {VillainId}");
            Console.WriteLine("******************************************** \n \n");
        }

    }
}
