using System.Data.SqlClient;
namespace SuperHero.Database
{
    public class DBConnection
    {
        string datasource { get; set; }//your server
        string database { get; set; } //your database name
        string connString { get; set; } //your connection string 
        public SqlConnection connection { get; set; }

        public DBConnection() 
        {
            try
            {
                datasource = @"LAPTOP-971UE9VO";//your server
                database = "SuperHero"; //your database name
                connString = @$"Server={datasource};Database={database};Trusted_Connection=True;";
                connection = new SqlConnection(connString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
