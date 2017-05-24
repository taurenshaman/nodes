using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("math: get Constant E(19)");

    //string result = System.Math.E.ToString();
    string result = "2.7182818284590452354";

    return req.CreateResponse(HttpStatusCode.OK, result, "text/plain");
}