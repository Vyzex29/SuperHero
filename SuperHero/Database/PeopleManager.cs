using System.Data.SqlClient;

namespace SuperHero.Database
{
    public class PeopleManager
    {
        private DBConnection dbConnection { get; set; }
        private SuperpowerManager superpowerBuilder { get; set; }

        public PeopleManager(DBConnection dbConnection, SuperpowerManager superpowerBuilder)
        {
            this.dbConnection = dbConnection;
            this.superpowerBuilder = superpowerBuilder;
        }

        public List<Hero> GetHerosForDistrict(int districtId) 
        { 
            List<Hero> heros = new List<Hero>();

            try
            {
                string query = "SELECT  shsp.SuperHeroId, " +
                    "shsp.SuperHeroPowersId, " +
                    "p.Name, p.Surname, " +
                    "p.Nickname, p.Type, " +
                    "p.DistrictId, " +
                    "sp.Name as superPowerName, " +
                    "sp.Description as superPowerDescription " +
                    "FROM SuperHero_SuperPowers shsp " +
                    "JOIN Persons p on shsp.SuperHeroId=p.ID " +
                    "JOIN Superpowers sp on shsp.SuperHeroPowersId=sp.ID " +
                    "WHERE p.Type = 0 AND p.DistrictId =" + districtId + "; ";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var personsId = Convert.ToInt32(reader["SuperHeroId"]);
                        var existingHero = GetsHeroFromListWithId(heros, personsId);
                        if (existingHero == null)
                        {
                            Hero hero = CreateANewHero(reader["Name"].ToString(), reader["Surname"].ToString(), reader["Nickname"].ToString(), personsId);
                            Superpower superpower = superpowerBuilder.Build(Convert.ToInt32(reader["SuperHeroPowersId"]), reader["superPowerName"].ToString(), reader["superPowerDescription"].ToString());
                            hero.PowerList.Add(superpower);
                            heros.Add(hero);
                        }
                        else
                        {
                            Superpower superpower = superpowerBuilder.Build(Convert.ToInt32(reader["SuperHeroPowersId"]), reader["superPowerName"].ToString(), reader["superPowerDescription"].ToString());
                            existingHero.PowerList.Add(superpower);
                        }
                    }
                    Console.WriteLine("GetDistricts command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return heros;
        }

        public List<Villain> GetVillansForDistrict(int districtId)
        {
            List<Villain> villains = new List<Villain>();

            try
            {
                string query = "SELECT  shsp.SuperHeroId, " +
                    "shsp.SuperHeroPowersId, " +
                    "p.Name, p.Surname, " +
                    "p.Nickname, p.Type, " +
                    "p.DistrictId, " +
                    "sp.Name as superPowerName, " +
                    "sp.Description as superPowerDescription " +
                    "FROM SuperHero_SuperPowers shsp " +
                    "JOIN Persons p on shsp.SuperHeroId=p.ID " +
                    "JOIN Superpowers sp on shsp.SuperHeroPowersId=sp.ID " +
                    "WHERE p.Type = 1 AND p.DistrictId =" + districtId + "; ";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var personsId = Convert.ToInt32(reader["SuperHeroId"]);
                        var existingVillain = GetsVillainFromListWithId(villains, personsId);
                        if (existingVillain == null)
                        {
                            Villain villain = CreateANewVillain(reader["Name"].ToString(), reader["Surname"].ToString(), reader["Nickname"].ToString(), personsId);
                            Superpower superpower = superpowerBuilder.Build(Convert.ToInt32(reader["SuperHeroPowersId"]), reader["superPowerName"].ToString(), reader["superPowerDescription"].ToString());
                            villain.PowerList.Add(superpower);
                            villains.Add(villain);
                        }
                        else
                        {
                            Superpower superpower = superpowerBuilder.Build(Convert.ToInt32(reader["SuperHeroPowersId"]), reader["superPowerName"].ToString(), reader["superPowerDescription"].ToString());
                            existingVillain.PowerList.Add(superpower);
                        }
                    }
                    Console.WriteLine("GetDistricts command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return villains;
        }

        public bool InsertAHeroInDB(string name, string surname, string nickname, int districtId) 
        {
            try
            {
                string query = $"INSERT INTO Persons (Name, Surname, Nickname, Type, DistrictId) VALUES('{name}', '{surname}', '{nickname}', 0, {districtId}); ";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                Console.WriteLine("InsertAHeroInDB command executed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        public Hero FindAHero(string name, string surname, string nickname, int districtId)
        {
            Hero hero = null;
            try
            {
                string query = $"SELECT * FROM Persons WHERE Name = '{name}' AND Surname = '{surname}' AND Nickname = '{nickname}' AND DistrictId = {districtId} AND Type = 0;";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    hero = CreateANewHero(reader["Name"].ToString(), reader["Surname"].ToString(), reader["Nickname"].ToString(), Convert.ToInt32(reader["ID"]));
                    Console.WriteLine("FindAHero command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return hero;
        }

        public void DeleteAHero(int peopleId)
        {
            try
            {
                DeleteASuperPower_Persona(peopleId);
                DeleteDeedsAndCrimes(peopleId);
                string query = $"DELETE FROM Persons WHERE ID={peopleId};";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                Console.WriteLine("DeleteAHero command executed");
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void DeleteASuperPower_Persona(int personaId) 
        {
            try
            {
                string query = $"DELETE FROM SuperHero_SuperPowers WHERE SuperHeroId={personaId};";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                Console.WriteLine("DeleteASuperPower_Persona command executed");
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void DeleteDeedsAndCrimes(int personaId)
        {
            try
            {
                string query = $"DELETE FROM DeedsOrCrime WHERE PesonId={personaId};";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                Console.WriteLine("DeleteDeedsAndCrimes command executed");
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private Hero GetsHeroFromListWithId(List<Hero> heros, int id)
        {
            return heros.FirstOrDefault(x => x.Id == id);
        }

        private Hero CreateANewHero(string name, string surname, string nickname, int id)
        {
            return new Hero(name, surname, nickname, id, new List<Superpower>());
        }

        private Villain GetsVillainFromListWithId(List<Villain> villains, int id)
        {
            return villains.FirstOrDefault(x => x.Id == id);
        }

        private Villain CreateANewVillain(string name, string surname, string nickname, int id)
        {
            return new Villain(name, surname, nickname, new List<Superpower>(), id);
        }

    }
}
