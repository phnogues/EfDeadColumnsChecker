namespace DeadColumnsChecker.Model;

public class DccTable
{
    public string Catalog { get; set; }

    public string Name { get; set; }

    public string Schema { get; set; }

    public List<DccColumn> Columns { get; set; } = new List<DccColumn>();
}
