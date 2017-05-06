using System.Net;

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "String: Generate GUID" );

      string format = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "format", true ) == 0 )
          .Value;

      string[] Formats = { "N", "D", "B", "P", "X" };
      var g = Guid.NewGuid();
      if (string.IsNullOrWhiteSpace( format ))
        format = "D";
      else {
        format = format.ToUpperInvariant();
        if (!Formats.Contains( format ))
          format = "D";
      }

      return req.CreateResponse( HttpStatusCode.OK, g.ToString( format ), "text/plain" );
    }