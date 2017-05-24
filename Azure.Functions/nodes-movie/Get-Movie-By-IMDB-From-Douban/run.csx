using System.Net;

    public static WebClient GetWebClient_UTF8() {
      WebClient client = new WebClient();
      client.Encoding = System.Text.Encoding.UTF8;
      client.UseDefaultCredentials = true;
      client.Headers.Add( "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36 Edge/12.0" );
      return client;
    }

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "book: Get-Movie-By-IMDB-From-Douban" );

      // parse query parameter
      string imdb = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "imdb", true ) == 0 )
          .Value;

      WebClient client = GetWebClient_UTF8();
      string result = await client.DownloadStringTaskAsync( "https://api.douban.com/v2/movie/imdb/" + imdb );
      result = System.Text.RegularExpressions.Regex.Unescape( result );
      return req.CreateResponse( HttpStatusCode.OK, result, "application/json" );
    }