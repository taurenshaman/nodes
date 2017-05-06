using System.Net;
using System.Text;

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "String: Decode from Hex" );

      string data = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
          .Value;
      if(string.IsNullOrWhiteSpace(data))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

      var bytes = new byte[data.Length / 2];
      for (var i = 0; i < bytes.Length; i++) {
        bytes[i] = Convert.ToByte( data.Substring( i * 2, 2 ), 16 );
      }
      string result = Encoding.UTF8.GetString( bytes );

      return req.CreateResponse( HttpStatusCode.OK, result, "text/plain" );
    }