using System.Data.SqlClient;

namespace SuperHero.Database
{
    public class DeedsAndCrimeTimeCalculation
    {
        private DBConnection dbConnection { get; set; }

        public DeedsAndCrimeTimeCalculation(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void SetHeroDeedTime(List<Person> people)
        {
            var peopleAsHeros = people.Where(x => x.GetType() == typeof(Hero)).ToList();
            foreach (Hero hero in peopleAsHeros)
            {
                hero.DeedTime = GetDeedOrCrimeCount(hero.Id);
            }
        }

        public void SetVillainCrimeTime(List<Person> people)
        {
            var villains = people.Where(x => x.GetType() == typeof(Villain)).ToList();
            foreach (Villain villain in villains)
            {
                villain.CrimeTime = GetDeedOrCrimeCount(villain.Id);
            }
        }

        private int GetDeedOrCrimeCount(int personsId) 
        {
            int count = 0;
            try
            {
                string query = $"SELECT * FROM DeedsOrCrime WHERE PesonId = {personsId};";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                    Console.WriteLine("SetHerosDeedTime command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return count;
        }
    }
}
