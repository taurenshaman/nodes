using System.Net;

    public static WebClient GetWebClient_UTF8() {
      WebClient client = new WebClient();
      client.Encoding = System.Text.Encoding.UTF8;
      client.UseDefaultCredentials = true;
      client.Headers.Add( "User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36 Edge/12.0" );
      return client;
    }

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "book: Get-Book-By-ISBN-From-Google" );

      // parse query parameter
      string isbn = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "isbn", true ) == 0 )
          .Value;

      WebClient client = GetWebClient_UTF8();
      string result = await client.DownloadStringTaskAsync( "https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn );

      return req.CreateResponse( HttpStatusCode.OK, result, "application/json" );
    }