namespace SuperHero
{

    public class Villain : Person
    {
        public Villain(string name, string surname, string nickname, List<Superpower> heroPowerList, int villainId)
            : base(villainId, name, surname, nickname, heroPowerList)
        {
        }

        public int CrimeTime { get; set; }


        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"\n VillainID: {Id} " +
                $"\n CrimeTime: {CrimeTime}");
        }

        public override void PrintGeneralInfo()
        {
            base.PrintGeneralInfo();
            Console.WriteLine($"VillainID: {Id}");
            Console.WriteLine($"CrimeTime: {CrimeTime}");
            Console.WriteLine("******************************************** \n \n");
        }

    }
}
