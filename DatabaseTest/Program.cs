// See https://aka.ms/new-console-template for more information


using System.Data;
using System.Reflection;
using DatabaseTest;
using MySql.Data.MySqlClient;


var props = typeof(Gerechten).GetProperties();

// join props togehter with a comma
var propsJoined = string.Join(",", props.Select(p => p.Name));

MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
builder.Server = "localhost";
builder.UserID = "root";
builder.Database = "maccie";
MySqlConnection connection = new MySqlConnection(builder.ToString());
connection.Open();
MySqlCommand command = connection.CreateCommand();
command.CommandText = $"SELECT {propsJoined} FROM `gerechten`";

MySqlDataAdapter adapter = new MySqlDataAdapter(command);

DataSet ds = new DataSet();
adapter.Fill(ds);

List<Gerechten> gerechten = new List<Gerechten>();

foreach (DataRow row in ds.Tables[0].Rows)
{
    gerechten.Add(new Gerechten((string) row["Naam"], (string) row["Beschrijving"], (int) row["Prijs"]));
}

connection.Close();

foreach (var gerecht in gerechten)
{
    Console.WriteLine(gerecht);
}
