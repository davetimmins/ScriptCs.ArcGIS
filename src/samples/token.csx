var arcgis = Require<ArcGISPack>();

var serverUrl = "https://localhost/arcgis";
var username= "";
var password = "";
if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
{
  Console.WriteLine("Uh-oh spaghetti-o, looks like you forgot to set the user credentials.");
}
else
{
  var gateway = arcgis.CreateGateway(serverUrl, username, password);
  var token = gateway.TokenProvider.CheckGenerateToken(CancellationToken.None).Result;

  Console.WriteLine(String.Format("Token expires at {0:g}", token.Expiry.FromUnixTime().ToLocalTime()));
  Console.WriteLine(token.Value);
}
