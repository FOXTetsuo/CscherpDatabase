namespace DatabaseTest;

public class Gerechten
{
    public string Naam { get; set; }
    public string Beschrijving { get; set; }
    public int Prijs { get; set; }

    public Gerechten(string naam, string beschrijving, int prijs)
    {
        Naam = naam;
        Beschrijving = beschrijving;
        Prijs = prijs;
    }
    
    public Gerechten()
    {
    }

    public override string ToString()
    {
        return $"Naam: {Naam}, Beschrijving: {Beschrijving}, Prijs: {Prijs}";
    }
}
