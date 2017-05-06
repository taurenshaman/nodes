using System.Net;

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "String: Encode using Base64" );

      string data = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
          .Value;
      if(string.IsNullOrWhiteSpace(data))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

      var plainTextBytes = System.Text.Encoding.UTF8.GetBytes( data );
      string result = System.Convert.ToBase64String( plainTextBytes );

      return req.CreateResponse( HttpStatusCode.OK, result, "text/plain" );
    }