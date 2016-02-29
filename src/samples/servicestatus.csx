var arcgis = Require<ArcGISPack>();

var serverUrl = "https://localhost/arcgis";
var username= "";
var password = "";
if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
{
  Console.WriteLine("Uh-oh spaghetti-o, looks like you forgot to set the user credentials.");
}
else
{
  var gateway = arcgis.CreateGateway(serverUrl, new TokenProvider(serverUrl, username, password));
  var response = gateway.DescribeSite().Result;

  Console.WriteLine(string.Format("Checking service statuses for {0}", gateway.RootUrl));
  foreach (var resource in response.Services)
  {
    // requires access to the admin site
    var status = gateway.ServiceStatus(resource).Result;
    if (!string.Equals(status.Actual, status.Expected, stringComparison.OrdinalIgnoreCase))
      Console.WriteLine(string.Format("NOT {2} : {0} ({1})", resource.Name, resource.Type, status.Expected));
    else
      Console.WriteLine(string.Format("{2} : {0} ({1})", resource.Name, resource.Type, status.Actual));
  }
}
