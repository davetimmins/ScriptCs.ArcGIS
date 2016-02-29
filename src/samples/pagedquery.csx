var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://sampleserver6.arcgisonline.com/arcgis");
var endpoint = @"/Energy/Geology/MapServer/0".AsEndpoint();
var queryCount = new QueryForCount(endpoint);

var count = gateway.QueryForCount(queryCount).Result.NumberOfResults;
var current = 0;
var pageSize = 10;

var resultCount = 0;

while (current < count)
{
    var query = new Query(endpoint)
    {
        ResultOffset = current,
        ResultRecordCount = pageSize
    };

    var results = gateway.Query(query).Result;

    current += pageSize;

    resultCount += results.features.Count();
}

Console.WriteLine(string.Format("Downloaded {0} {1}.", resultCount, resultCount == 1 ? "feature" : "features"));

    