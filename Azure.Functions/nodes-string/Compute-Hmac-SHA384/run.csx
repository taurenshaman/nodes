using System.Net;
using System.Text;
using PCLCrypto;
using static PCLCrypto.WinRTCrypto;

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "String: Compute_HMAC_SHA384" );

      string key = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "key", true ) == 0 )
          .Value;
      string data = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
          .Value;
      string format = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "format", true ) == 0 )
          .Value;
      if (string.IsNullOrWhiteSpace( key ))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named key" );
      if (string.IsNullOrWhiteSpace( data ))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

      var mac = MacAlgorithmProvider.OpenAlgorithm( MacAlgorithm.HmacSha384 );
      var keyMaterial = CryptographicBuffer.ConvertStringToBinary( key, Encoding.UTF8 );
      var cryptoKey = mac.CreateKey( keyMaterial );

      var dataMaterial = CryptographicBuffer.ConvertStringToBinary( data, Encoding.UTF8 );

      var hashBytes = CryptographicEngine.Sign( cryptoKey, dataMaterial );

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