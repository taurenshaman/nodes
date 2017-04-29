using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info( "Net: get client ip" );
    const string HttpContext = "MS_HttpContext";
    const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
    string ip = null;

     if (req.Properties.ContainsKey( HttpContext )) {
        dynamic ctx = req.Properties[HttpContext];
        if (ctx != null) {
          ip =  ctx.Request.UserHostAddress;
        }
      }

      if (req.Properties.ContainsKey( RemoteEndpointMessage )) {
        dynamic remoteEndpoint = req.Properties[RemoteEndpointMessage];
        if (remoteEndpoint != null) {
          ip =  remoteEndpoint.Address;
        }
      }

      return ip == null ?
        req.CreateResponse(HttpStatusCode.BadRequest, "unknown error")
        : req.CreateResponse(HttpStatusCode.OK, ip, "text/plain");
}