using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Database;

public static class Database
{
    private const string Server = "localhost";
    private const string UserID = "root";
    private const string InitalDB = "maccie";
    private static MySqlConnection _connection;

    #region Util

    public static void Connect()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = Server;
        builder.UserID = UserID;
        builder.Database = InitalDB;
        _connection = new MySqlConnection(builder.ConnectionString);
        
        _connection.Open();
    }

    public static void Disconnect()
    {
        _connection.Close();
    }

    #endregion
    
    private static DataTable _getTable<T>()
    {
        DataTable table = new DataTable();
        string items = string.Join(',', typeof(T).GetProperties().Select(x => x.Name));
        string query = $"SELECT {items} FROM {typeof(T).Name}";
        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        adapter.Fill(table);
        return table;
    }
    
    public static List<T> GenerateList<T>()
    {
        List<T> list = new List<T>();
        DataTable table = _getTable<T>();
        foreach (DataRow row in table.Rows)
        {
            T item = Activator.CreateInstance<T>();
            foreach (DataColumn column in table.Columns)
            {
                PropertyInfo property = typeof(T).GetProperty(column.ColumnName);
                property.SetValue(item, row[column]);
            }
            list.Add(item);
        }
        return list;
    }
}