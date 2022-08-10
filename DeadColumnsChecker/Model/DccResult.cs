namespace DeadColumnsChecker.Model;

public class DccResult
{
    public List<DccTable> MissingTables { get; set; } = new List<DccTable>();

    public List<DccTable> MissingColumns { get; set; } = new List<DccTable>();

    public string Message
    {
        get
        {
            return $"{MissingTables.Count} tables and {MissingColumns.Sum(mc => mc.Columns.Count)} columns are not in your DbContext";
        }
    }
}
