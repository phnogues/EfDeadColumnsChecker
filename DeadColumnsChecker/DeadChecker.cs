using DeadColumnsChecker.Model;
using DeadColumnsChecker.Reader;
using DeadColumnsChecker.Utilities;
using Microsoft.EntityFrameworkCore;

namespace DeadColumnsChecker;

public static class DeadChecker
{
    public static DccResult CheckDeadColumns(this DbContext dbContext, string defaultSchema = "dbo", string[] schemasToExclude = null)
    {
        var result = new DccResult();

        var dbReader = new DbReader();
        var efReader = new EfReader();

        var cs = dbContext.Database.GetConnectionString();

        var sqlTables = dbReader.GetTables(cs).FilterSchemas(schemasToExclude);
        var efTables = efReader.GetTables(dbContext, defaultSchema).FilterSchemas(schemasToExclude);

        Console.WriteLine($"Table: {sqlTables.Count} tables found in your database");
        Console.WriteLine($"Table: {efTables.Count} tables found in your model {Environment.NewLine}");

        foreach (var sqlTable in sqlTables)
        {
            var efTable = efTables.FirstOrDefault(et => et.Name.Equals(sqlTable.Name, StringComparison.InvariantCultureIgnoreCase)
                                                     && et.Schema.Equals(sqlTable.Schema, StringComparison.InvariantCultureIgnoreCase));

            if (efTable is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Table: {sqlTable.Name} is not in your model");
                result.MissingTables.Add(sqlTable);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"-- Table: {sqlTable.Name} --");
                foreach (var sqlColumn in sqlTable.Columns)
                {
                    var efColumn = efTable.Columns.FirstOrDefault(ec => ec.Name.Equals(sqlColumn.Name, StringComparison.OrdinalIgnoreCase));
                    if (efColumn is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Column: {sqlColumn.Name} is not in your model");
                        AddMissingColumnToResult(sqlTable, sqlColumn, result);
                    }
                }
            }
        }

        return result;
    }

    private static void AddMissingColumnToResult(DccTable table, DccColumn column, DccResult result)
    {
        var resultTable = result.FindTable(table);
        if (resultTable is null)
        {
            result.MissingColumns.Add(new DccTable() { Name = table.Name, Schema = table.Schema });
        }

        resultTable = result.FindTable(table);
        resultTable.Columns.Add(column);
    }
}
