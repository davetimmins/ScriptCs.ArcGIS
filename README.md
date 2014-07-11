ScriptCs.ArcGIS
===============

[![Build status](https://ci.appveyor.com/api/projects/status/8x5it4k9oducbm7i)](https://ci.appveyor.com/project/davetimmins/scriptcs-arcgis)  [![NuGet Status](http://img.shields.io/nuget/v/ScriptCs.ArcGIS.svg?style=flat)](https://www.nuget.org/packages/ScriptCs.ArcGIS/)

A ScriptCs script pack for [ArcGIS.PCL](https://github.com/davetimmins/ArcGIS.PCL)

###Quick Start

```csharp
var arcgis = Require<ArcGISPack>();
var gateway = arcgis.CreateGateway("http://services.arcgisonline.com/arcgis");

// Now do whatever you want!
```

Refer to the [ArcGIS.PCL](https://github.com/davetimmins/ArcGIS.PCL) project for more information on what you can call.

