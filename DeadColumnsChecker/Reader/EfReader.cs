using DeadColumnsChecker.Model;
using Microsoft.EntityFrameworkCore;

namespace DeadColumnsChecker.Reader;

public class EfReader
{
    public List<DccTable> GetTables(DbContext dbContext, string defaultSchema)
    {
        return dbContext.Model.GetEntityTypes().Select(e => new DccTable()
        {
            Name = e.GetTableName(),
            Schema = e.GetSchema() ?? defaultSchema,
            Columns = e.GetProperties().Select(p => new DccColumn()
            {
                Name = p.GetColumnBaseName()
            }).ToList()
        }).ToList();
    }
}
