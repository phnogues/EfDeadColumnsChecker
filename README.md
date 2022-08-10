# EfDeadColumnsChecker
Check sql columns not used in your project

## How to use it ?
From anywhere where you can access to your DbContext, call the extension method CheckDeadColumns

```
using (var context = new EntitiesDb())
{
   var result = context.CheckDeadColumns();
   var csv = result.ToCsv(); // can be exported to a csv
}
```
