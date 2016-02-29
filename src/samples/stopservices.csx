var arcgis = Require<ArcGISPack>();

var serverUrl = "";
var username= "";
var password = "";
if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
{
  Console.WriteLine("Uh-oh spaghetti-o, looks like you forgot to set the user credentials.");
}
else
{
  // Uncomment this to encrypt the token generation requests
  // arcgis.EncryptTokenRequests = true;

  // set this to only use services from this folder
  var folder = "teched";
  var gateway = arcgis.CreateGateway(serverUrl, username, password);

  var site = gateway.SiteReport(folder).Result;

  var services = site.ServiceReports.Where(s => s.Type == "MapServer");

  foreach (var service in services)
  {
    var sd = service.AsServiceDescription();
    if (string.Equals("STARTED", service.Status.Actual, stringComparison.OrdinalIgnoreCase))
    {
      Console.WriteLine("Stopping " + sd.Name);
      var stoppedResult = gateway.StopService(sd).Result;
      Console.WriteLine(stoppedResult.Status);

      Console.WriteLine("Starting " + sd.Name);
      var startedResult = gateway.StartService(sd).Result;
      Console.WriteLine(startedResult.Status);
    }
    else
    {
      Console.WriteLine("Starting " + sd.Name);
      var startedResult = gateway.StartService(sd).Result;
      Console.WriteLine(startedResult.Status);

      Console.WriteLine("Stopping " + sd.Name);
      var stoppedResult = gateway.StopService(sd).Result;
      Console.WriteLine(stoppedResult.Status);
    }
  }
}
