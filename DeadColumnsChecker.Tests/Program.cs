using DeadColumnsChecker;
using DeadColumnsChecker.Tests.Entities;

Console.WriteLine("Test DeadColumns checker");

using (var context = new EntitiesDb())
{
   var result = context.CheckDeadColumns();
}

Console.ReadKey();