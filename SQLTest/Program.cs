using System.Data.SqlClient;

namespace sqltest
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
				builder.DataSource = "localhost";
				builder.UserID = "SA";
				builder.Password = "RestaurantHeiwa1337!";
				builder.InitialCatalog = "HWDatabase";

				using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
				{
					Console.WriteLine("\nQuery data example:");
					Console.WriteLine("=========================================\n");

					String sql = "SELECT name, collation_name FROM sys.databases";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
							}
						}
					}
				}
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.ToString());
			}
			Console.ReadLine();
		}
	}
}