using DeadColumnsChecker;
using DeadColumnsChecker.Tests.Entities;
using DeadColumnsChecker.Utilities;

Console.WriteLine("Test DeadColumns checker");

using (var context = new EntitiesDb())
{
    var result = context.CheckDeadColumns();
    var csv = result.ToCsv();
}

Console.ReadKey();