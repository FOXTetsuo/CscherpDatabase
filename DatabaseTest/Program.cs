

using DatabaseTest;

Database.Database.Connect();

DataSet dataSet = new DataSet();

dataSet.Fill();

dataSet.PrintLists();

// List<Gerechten> gerechten = Database.Database.GenerateList<Gerechten>();

// foreach (Gerechten gerecht in gerechten)
// {
    // Console.WriteLine(gerecht);
// }

Database.Database.Disconnect();
