using System.Net;

public static WebClient GetWebClient_UTF8() {
    WebClient client = new WebClient();
    client.Encoding = System.Text.Encoding.UTF8;
    client.UseDefaultCredentials = true;
    client.Headers.Add( "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36 Edge/12.0" );
    return client;
}

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("food: Get-Food-Product-By-Barcode-From-Chuci");

    // parse query parameter
    string code = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "code", true) == 0)
        .Value;

    if(string.IsNullOrWhiteSpace(code))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named code" );

    WebClient client = GetWebClient_UTF8();
    string result = await client.DownloadStringTaskAsync( "http://www.chuci.info/api/select-food-product?code=" + code );

    // cannot identify “text/turtle” here, so just write to text/plain
    return string.IsNullOrWhiteSpace(result)
        ? req.CreateResponse(HttpStatusCode.BadRequest, "No record found.")
        : req.CreateResponse(HttpStatusCode.OK, result, "text/plain");
}