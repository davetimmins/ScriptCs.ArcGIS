<img align="right" height="120" src="https://raw.githubusercontent.com/davetimmins/ScriptCs.ArcGIS/master/arcgispcl-scriptcs.png">

### ScriptCs.ArcGIS

[![Build status](https://ci.appveyor.com/api/projects/status/8x5it4k9oducbm7i)](https://ci.appveyor.com/project/davetimmins/scriptcs-arcgis)  [![NuGet Status](http://img.shields.io/nuget/v/ScriptCs.ArcGIS.svg?style=flat)](https://www.nuget.org/packages/ScriptCs.ArcGIS/)

A [scriptcs](https://github.com/scriptcs/scriptcs) [script pack](https://github.com/scriptcs/scriptcs/wiki/Script-Packs-master-list) for [ArcGIS.PCL](https://github.com/davetimmins/ArcGIS.PCL)

###Quick Start

```csharp
var arcgis = Require<ArcGISPack>();
var gateway = arcgis.CreateGateway("http://services.arcgisonline.com/arcgis");

// Now do whatever you want!
```

###Going further

The returned `gateway` supports the following as typed operations:

 * `Query<T>` - query a layer by attribute and / or spatial filters
 * `QueryForCount` - only return the number of results for the query operation
 * `QueryForIds` - only return the ObjectIds for the results of the query operation
 * `Find` - search across n layers and fields in a service
 * `ApplyEdits<T>` - post adds, updates and deletes to a feature service layer
 * `Geocode` - single line of input to perform a geocode using a custom locator or the Esri world locator
 * `Suggest` - lightweight geocode operation that only returns text results, commonly used for predictive searching
 * `ReverseGeocode` - find location candidates for a input point location
 * `Simplify<T>` - alter geometries to be topologically consistent
 * `Project<T>` - convert geometries to a different spatial reference
 * `Buffer<T>` - buffers geometries by the distance requested
 * `DescribeSite` - returns a url for every service discovered
 * `Ping` - verify that the server can be accessed
 * `PublicKey` - admin operation to get public key used for encryption of token requests
 * `ServiceStatus` - admin operation to get the configured and actual status of a service

In all cases above `T` is a geometry type of `Point`, `MultiPoint`, `Polyline`, `Polygon` or `Extent`

 If you need to call secure resources and your ArcGIS Server supports token based authentication then specify a `TokenProvider` in your call to `CreateGateway`

 ```csharp
 var arcgis = Require<ArcGISPack>();
 var gateway = arcgis.CreateGateway("http://localhost/arcgis", new TokenProvider("http://localhost/arcgis", "username", "password"));
 ```


Refer to the [ArcGIS.PCL](https://github.com/davetimmins/ArcGIS.PCL) project for more information on what you can call.
