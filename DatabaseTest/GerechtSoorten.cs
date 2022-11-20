namespace DatabaseTest;

public class GerechtSoorten
{
    public string Naam { get; set; }
    public int GerechtSoortID { get; set; }
    public string Beschrijving { get; set; }

    public override string ToString()
    {
        return $"{GerechtSoortID} => {Naam} - {Beschrijving}";
    }
}