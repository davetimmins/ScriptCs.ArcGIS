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
  // Uncomment this to encrypt the token generation requests
  // arcgis.EncryptTokenRequests = true;

  // first way
  var gateway = arcgis.CreateGateway(serverUrl, username, password);
  var token = gateway.TokenProvider.CheckGenerateToken(CancellationToken.None).Result;

  Console.WriteLine(string.Format("Token expires at {0:g}", token.Expiry.FromUnixTime().ToLocalTime()));
  Console.WriteLine(token.Value);

  // second way
  var otherToken = new TokenProvider(serverUrl, username, password).CheckGenerateToken(CancellationToken.None).Result;
  Console.WriteLine(string.Format("Token expires at {0:g}", otherToken.Expiry.FromUnixTime().ToLocalTime()));
  Console.WriteLine(otherToken.Value);
}
