using DeadColumnsChecker.Reader;
using Microsoft.EntityFrameworkCore;

namespace DeadColumnsChecker;

public static class DeadChecker
{
    public static void CheckDeadColumns(this DbContext dbContext, string defaultSchema = "dbo")
    {
        var dbReader = new DbReader();
        var efReader = new EfReader();

        var cs = dbContext.Database.GetConnectionString();

        var sqlTables = dbReader.GetTables(cs);
        var efTables = efReader.GetTables(dbContext, defaultSchema);

        Console.WriteLine($"Table: {sqlTables.Count} tables found in your database");
        Console.WriteLine($"Table: {efTables.Count} tables found in your model {Environment.NewLine}");

        foreach (var sqlTable in sqlTables)
        {
            var efTable = efTables.FirstOrDefault(et => et.Name == sqlTable.Name && et.Schema == sqlTable.Schema);

            if (efTable is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Table: {sqlTable.Name} is not in your model");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"-- Table: {sqlTable.Name} --");
                foreach (var sqlColumn in sqlTable.Columns)
                {
                    var efColumn = efTable.Columns.FirstOrDefault(ec => ec.Name == sqlColumn.Name);
                    if (efColumn is null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Column: {sqlColumn.Name} is not in your model");
                    }
                }
            }
        }
    }
}
