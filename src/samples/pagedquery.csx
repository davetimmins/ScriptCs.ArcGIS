var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://sampleserver6.arcgisonline.com/arcgis");
var endpoint = @"/Energy/Geology/MapServer/0".AsEndpoint();
var queryCount = new QueryForCount(endpoint);

var count = Task.Run(async () => {
    return await gateway.QueryForCount(queryCount);
}).Result.NumberOfResults;

var current = 0;
var pageSize = 10;
var resultCount = 0;
var cycles = 0;

while (current < count)
{
    var query = new Query(endpoint)
    {
        ResultOffset = current,
        ResultRecordCount = pageSize
    };
    
    var results = Task.Run(async () => {
        return await gateway.Query<Point>(query);
    }).Result;

    current += pageSize;
    cycles++;

    resultCount += results.Features.Count();
}

Console.WriteLine(string.Format("Downloaded {0} {1} in {2} {3}.", resultCount, resultCount == 1 ? "feature" : "features", cycles, cycles == 1 ? "cycle" : "cycles"));

    