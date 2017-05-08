using System.Net;

// ref: https://helloacm.com/c-coding-exercise-convert-integer-to-english-words/

    /// <summary>
    /// 10^6
    /// </summary>
    const long Million = 1000000;
    /// <summary>
    /// 10^9
    /// </summary>
    const long Billion = 1000000000;
    /// <summary>
    /// 10^12
    /// </summary>
    const long Trillion = 1000000000000;
    /// <summary>
    /// 10^15
    /// </summary>
    const long Quadrillion = 1000000000000000;
    /// <summary>
    /// 10^18
    /// </summary>
    const long Quintillion = 1000000000000000000;

    // 9,223,372,036,854,775,808-9,223,372,036,854,775,807
    static string LongToEnglish(long x) {
      if (x < 0)
        return "Negative " + LongToEnglish( x * -1L );

      switch (x) {
        case 0: return "Zero";
        case 1: return "One";
        case 2: return "Two";
        case 3: return "Three";
        case 4: return "Four";
        case 5: return "Five";
        case 6: return "Six";
        case 7: return "Seven";
        case 8: return "Eight";
        case 9: return "Nine";
        case 10: return "Ten";
        case 11: return "Eleven";
        case 12: return "Twelve";
        case 13: return "Thirteen";
        case 14: return "Fourteen";
        case 15: return "Fifteen";
        case 16: return "Sixteen";
        case 17: return "Seventeen";
        case 18: return "Eighteen";
        case 19: return "Nineteen";
        case 20: return "Twenty";
        case 30: return "Thirty";
        case 40: return "Forty";
        case 50: return "Fifty";
        case 60: return "Sixty";
        case 70: return "Seventy";
        case 80: return "Eighty";
        case 90: return "Ninety";
        case 100: return "One Hundred";
        case 1000: return "One Thousand";
        case Million: return "One Million";
        case Billion: return "One Billion";
        case Trillion: return "One Trillion";
        case Quadrillion: return "One Quadrillion";
        case Quintillion: return "One Quintillion";
      }
      // less than 100
      for (long i = 1; i <= 9; i++) {
        long j = i * 10;
        if (( x >= j ) && ( x < j + 10 )) {
          long r = x - j;
          return LongToEnglish( j ) + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // less than 1000
      for (long i = 1; i <= 9; i++) {
        long j = i * 100;
        if (( x >= j ) && ( x < j + 100 )) {
          long r = x - j;
          return LongToEnglish( i ) + " Hundred" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // less than 10000
      for (long i = 1; i <= 9; i++) {
        long j = i * 1000;
        if (( x >= j ) && ( x < j + 1000 )) {
          long r = x - j;
          return LongToEnglish( i ) + " Thousand" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Million
      for (long i = 1; i <= 9; i++) {
        long j = i * Million;
        if (( x >= j ) && ( x < j + Million )) {
          long r = x - j;
          return LongToEnglish( i ) + " Million" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Billion
      for (long i = 1; i <= 9; i++) {
        long j = i * Billion;
        if (( x >= j ) && ( x < j + Billion )) {
          long r = x - j;
          return LongToEnglish( i ) + " Billion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Trillion: 10^12
      for (long i = 1; i <= 9; i++) {
        long j = i * Trillion;
        if (( x >= j ) && ( x < j + Trillion )) {
          long r = x - j;
          return LongToEnglish( i ) + " Trillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Quadrillion: 10^15
      for (long i = 1; i <= 9; i++) {
        long j = i * Quadrillion;
        if (( x >= j ) && ( x < j + Quadrillion )) {
          long r = x - j;
          return LongToEnglish( i ) + " Quadrillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Quintillion: 10^18
      for (long i = 1; i <= 9; i++) {
        long j = i * Quintillion;
        if (( x >= j ) && ( x < j + Quintillion )) {
          long r = x - j;
          return LongToEnglish( i ) + " Quintillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Divide the number into 3-digit groups from left to right
      string output = "";
      long cnt = 0;
      while (x > 0) {
        long y = x % 1000;
        x /= 1000;
        if (y > 0) { // skip middle-chunk zero
          string t = "";
          if (cnt == 1) t = " Thousand ";
          if (cnt == 2) t = " Million ";
          if (cnt == 3) t = " Billion ";
          if (cnt == 4) t = " Trillion ";
          if (cnt == 5) t = " Quadrillion ";
          if (cnt == 6) t = " Quintillion ";
          output = LongToEnglish( y ) + t + output;
        }
        cnt++;
      }
      return ( output.Trim() );
    }

    // 0-18,446,744,073,709,551,615
    static string LongToEnglish(ulong x) {
      switch (x) {
        case 0: return "Zero";
        case 1: return "One";
        case 2: return "Two";
        case 3: return "Three";
        case 4: return "Four";
        case 5: return "Five";
        case 6: return "Six";
        case 7: return "Seven";
        case 8: return "Eight";
        case 9: return "Nine";
        case 10: return "Ten";
        case 11: return "Eleven";
        case 12: return "Twelve";
        case 13: return "Thirteen";
        case 14: return "Fourteen";
        case 15: return "Fifteen";
        case 16: return "Sixteen";
        case 17: return "Seventeen";
        case 18: return "Eighteen";
        case 19: return "Nineteen";
        case 20: return "Twenty";
        case 30: return "Thirty";
        case 40: return "Forty";
        case 50: return "Fifty";
        case 60: return "Sixty";
        case 70: return "Seventy";
        case 80: return "Eighty";
        case 90: return "Ninety";
        case 100: return "One Hundred";
        case 1000: return "One Thousand";
        case Million: return "One Million";
        case Billion: return "One Billion";
        case Trillion: return "One Trillion";
        case Quadrillion: return "One Quadrillion";
        case Quintillion: return "One Quintillion";
      }
      // less than 100
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * 10;
        if (( x >= j ) && ( x < j + 10 )) {
          ulong r = x - j;
          return LongToEnglish( j ) + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // less than 1000
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * 100;
        if (( x >= j ) && ( x < j + 100 )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Hundred" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // less than 10000: 10^4
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * 1000;
        if (( x >= j ) && ( x < j + 1000 )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Thousand" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Million: 10^6
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * Million;
        if (( x >= j ) && ( x < j + Million )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Million" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Billion: 10^9
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * Billion;
        if (( x >= j ) && ( x < j + Billion )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Billion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Trillion: 10^12
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * Trillion;
        if (( x >= j ) && ( x < j + Trillion )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Trillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Quadrillion: 10^15
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * Quadrillion;
        if (( x >= j ) && ( x < j + Quadrillion )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Quadrillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Quintillion: 10^18
      for (ulong i = 1; i <= 9; i++) {
        ulong j = i * Quintillion;
        if (( x >= j ) && ( x < j + Quintillion )) {
          ulong r = x - j;
          return LongToEnglish( i ) + " Quintillion" + ( r > 0 ? ( " " + LongToEnglish( r ) ) : "" );
        }
      }
      // Divide the number into 3-digit groups from left to right
      string output = "";
      long cnt = 0;
      while (x > 0) {
        ulong y = x % 1000;
        x /= 1000;
        if (y > 0) { // skip middle-chunk zero
          string t = "";
          if (cnt == 1) t = " Thousand ";
          if (cnt == 2) t = " Million ";
          if (cnt == 3) t = " Billion ";
          if (cnt == 4) t = " Trillion ";
          if (cnt == 5) t = " Quadrillion ";
          if (cnt == 6) t = " Quintillion ";
          output = LongToEnglish( y ) + t + output;
        }
        cnt++;
      }
      return ( output.Trim() );
    }

    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log) {
      log.Info( "Math: Arabic-Numerals-To-English-Words" );

      string data = req.GetQueryNameValuePairs()
          .FirstOrDefault( q => string.Compare( q.Key, "data", true ) == 0 )
          .Value;
      if (string.IsNullOrWhiteSpace( data ))
        return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter named data" );

      //bool match = System.Text.RegularExpressions.Regex.IsMatch( data, "" );
      //if (!match)
      //  return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter that is Abrabic numerals" );

      string result = null;
      if (data.StartsWith( "-" )) {
        long v = 0;
        try {
          v = long.Parse( data.Trim() );
          result = LongToEnglish( v );
        }
        catch (Exception ex) {
          return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter that is Abrabic numerals: " + ex.Message );
        }
      }
      else {
        ulong v = 0;
        try {
          v = ulong.Parse( data.Trim() );
          result = LongToEnglish( v );
        }
        catch (Exception ex) {
          return req.CreateResponse( HttpStatusCode.BadRequest, "need a parameter that is Abrabic numerals: " + ex.Message );
        }
      }
      
      return req.CreateResponse( HttpStatusCode.OK, result, "text/plain" );
    }
