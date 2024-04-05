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

## Enjoy !
<a href="https://www.buymeacoffee.com/phnogues" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>
