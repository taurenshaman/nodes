using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info( "String: Encode using Hex" );

    string data = req.GetQueryNameValuePairs()
        .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
        .Value;
    if(string.IsNullOrWhiteSpace(data))
      return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes( data );
    var hexString = BitConverter.ToString( plainTextBytes );
    string result = hexString.Replace( "-", "" );

    return req.CreateResponse( HttpStatusCode.OK, result, "text/plain" );
}