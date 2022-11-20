using System.Collections;

namespace DatabaseTest;

public class DataSet
{
    public List<Gerechten> Gerechtens { get; set; }
    public List<Gerechten> Gerechten { get; set; }
    public List<GerechtSoorten> GerechtSoortens { get; set; }

    public DataSet()
    {
        Gerechten = new List<Gerechten>();
        Gerechtens = new List<Gerechten>();
    }

    public void Fill()
    {
        Database.Database.Connect();
        // get the type of list from properties
        var type = this.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            // get the type of the list
            var listType = property.PropertyType;
            // get the type of the list items
            var itemType = listType.GetGenericArguments()[0];
            // get the method to get the data and make it generic with the item type
            var method = typeof(Database.Database).GetMethod("GenerateList").MakeGenericMethod(itemType);
            // get the data
            var data = method.Invoke(null, null);
            // set the data to the property
            property.SetValue(this, data);
        }
        
        Database.Database.Disconnect();
    }

    public void PrintLists()
    {
        var type = this.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name + "---------------------------------");
            foreach (var item in (IEnumerable)property.GetValue(this))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}