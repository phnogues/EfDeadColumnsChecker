using DeadColumnsChecker.Model;
using System.Data;
using System.Data.SqlClient;

namespace DeadColumnsChecker.Reader;

public class DbReader
{
    public List<DccTable> GetTables(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var columnsTable = connection.GetSchema("Columns");
            var selectedRows = from info in columnsTable.AsEnumerable()
                               select new
                               {
                                   TableCatalog = info["TABLE_CATALOG"].ToString(),
                                   TableSchema = info["TABLE_SCHEMA"].ToString(),
                                   TableName = info["TABLE_NAME"].ToString(),
                                   ColumnName = info["COLUMN_NAME"].ToString(),
                                   DataType = info["DATA_TYPE"].ToString()
                               };

            var tables = selectedRows.GroupBy(t => new
            {
                t.TableName,
                t.TableSchema,
                t.TableCatalog
            }).Select(r => new DccTable()
            {
                Name = r.Key.TableName.ToString(),
                Schema = r.Key.TableSchema,
                Catalog = r.Key.TableCatalog,
                Columns = r.Select(f => new DccColumn()
                {
                    Name = f.ColumnName,
                    Type = f.DataType
                }).ToList()
            }).ToList();

            return tables;
        }
    }
}
