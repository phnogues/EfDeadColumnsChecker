# EfDeadColumnsChecker
![Logo](/icon.png)

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

## Available as a nuget package Nuget
[![NuGet version (DeadColumnsChecker)](https://img.shields.io/nuget/v/DeadColumnsChecker.svg?style=flat-square)](https://www.nuget.org/packages/DeadColumnsChecker/)

