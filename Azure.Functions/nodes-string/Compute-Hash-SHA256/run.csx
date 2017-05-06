using System.Net;
using System.Text;
using PCLCrypto;
using static PCLCrypto.WinRTCrypto;

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "String: Compute_Hash_SHA256" );

      string data = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
          .Value;
      string format = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "format", true ) == 0 )
          .Value;
      if (string.IsNullOrWhiteSpace( data ))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

      byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes( data );
      var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm( HashAlgorithm.Sha256 );
      byte[] hashBytes = hasher.HashData( dataBytes );

      string result = null;
      if (string.Compare( format, "base64", true ) == 0)
        result = System.Convert.ToBase64String( hashBytes );
      else {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in hashBytes)
          sb.Append( b.ToString( "x2" ) );
        result = sb.ToString();
      }

      return req.CreateResponse( HttpStatusCode.OK, result, "text/plain" );
    }