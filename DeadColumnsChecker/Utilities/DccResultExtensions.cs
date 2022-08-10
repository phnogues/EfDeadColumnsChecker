using DeadColumnsChecker.Model;
using System.Text;

namespace DeadColumnsChecker.Utilities;

public static class DccResultExtensions
{
    public static string ToCsv(this DccResult results)
    {
        var csv = new StringBuilder();

        csv.AppendLine("Schema;Table;Column;Type");
        foreach (var result in results.MissingTables)
        {
            csv.AppendLine($"{result.Schema};{result.Name};NA;NA");
        }

        foreach (var result in results.MissingColumns)
        {
            foreach (var column in result.Columns)
            {
                csv.AppendLine($"{result.Schema};{result.Name};{column.Name};{column.Type}");
            }
        }

        return csv.ToString();
    }
}
