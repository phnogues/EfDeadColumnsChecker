using DeadColumnsChecker.Model;

namespace DeadColumnsChecker.Utilities;

public static class DeadCheckerExtensions
{
    public static DccTable FindTable(this DccResult result, DccTable table)
    {
        return result.MissingColumns.FirstOrDefault(mc => mc.Name == table.Name && mc.Schema == table.Schema);
    }

    public static List<DccTable> FilterSchemas(this List<DccTable> tables, string[] schemasToExclude)
    {
        return tables
                .Where(t => schemasToExclude != null ? !schemasToExclude.Contains(t.Schema) : true)
                .ToList();
    }
}
