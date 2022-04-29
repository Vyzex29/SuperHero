using System.Data.SqlClient;
namespace SuperHero.Database
{
    public class DistrictManager
    {
        private DBConnection dbConnection;
        private PeopleManager peopleManager;

        public DistrictManager(DBConnection dbConnection, PeopleManager peopleManager)
        { 
            this.dbConnection = dbConnection;
            this.peopleManager = peopleManager;
        }

        public List<District> GetDistricts()
        {
            List<District> districts = new List<District>();
            try
            {
                string query = "SELECT * FROM Districts;";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var district = new District(reader["Title"].ToString(), reader["City"].ToString(), Convert.ToInt32(reader["ID"]));
                        districts.Add(district);
                    }
                    Console.WriteLine("GetDistricts command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return districts;
        }

        public void SetAllTheDistrictsUpWithPeople (District district)
        {
            var heros = peopleManager.GetHerosForDistrict(district.DistrinctID);
            var vilains = peopleManager.GetVillansForDistrict(district.DistrinctID);
            AddAllVillainsAndHerosToPeopleInDistrict(heros, vilains, district.PeopleInTheDistrict);
        }

        public void AddAllVillainsAndHerosToPeopleInDistrict(List<Hero> heros, List<Villain> villains, List<Person> peopleInDistrict)
        {
            foreach (var hero in heros) 
            {
                peopleInDistrict.Add(hero);
            }
            foreach (var villain in villains)
            {
                peopleInDistrict.Add(villain);
            }
        }
    }
}
