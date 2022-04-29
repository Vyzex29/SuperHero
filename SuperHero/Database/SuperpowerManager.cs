using System.Data.SqlClient;

namespace SuperHero.Database
{
    public class SuperpowerManager
    {
        private DBConnection dbConnection { get; set; }

        public SuperpowerManager(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public Superpower Build(int id, string name, string description)
        {
            return new Superpower(id, name, description);
        }

        public Superpower AddASuperPower(string superPowerName, int personsId) 
        {
            var superPowerInserted = InsertASuperPower(superPowerName);
            var superPower = FindASuperPowerId(superPowerName, superPowerName);
            var superPower_PersonInserted = InsertASuperPower_Person(superPower.ID, personsId);
            if (superPowerInserted && superPower_PersonInserted) 
            {
                Console.WriteLine("AddASuperPower command executed");
            }
            return superPower;
        }

        private bool InsertASuperPower(string superPowerName) 
        {
            try
            {
                string query = $"INSERT INTO Superpowers(Name, Description) VALUES('{superPowerName}', '{superPowerName}'); ";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("InsertASuperPower command executed");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }

        private Superpower FindASuperPowerId(string superPowerName, string superPowerDescription)
        {
            Superpower superpower = new Superpower();
            try
            {
                string query = $"SELECT * FROM Superpowers WHERE Name = '{superPowerName}' AND Description = '{superPowerDescription}';";
                SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    superpower = Build( Convert.ToInt32(reader["ID"]), reader["Name"].ToString(), reader["Description"].ToString());
                    Console.WriteLine("FindASuperPowerId command executed");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return superpower;
        }
        private bool InsertASuperPower_Person(int superpowerId, int personsId)
        {
            try
            {
                if (superpowerId != 0 && personsId != 0)
                {
                    string query = $"INSERT INTO SuperHero_SuperPowers(SuperHeroId, SuperHeroPowersId) VALUES({personsId}, {superpowerId}); ";
                    SqlCommand cmd = new SqlCommand(query, dbConnection.connection);
                    var rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("InsertASuperPower command executed");
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return false;
        }
    }
}
