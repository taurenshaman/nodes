using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("math: get Constant PI(20)");

    //string result = System.Math.PI.ToString();
    string result = "3.14159265358979323846";

    return req.CreateResponse(HttpStatusCode.OK, result, "text/plain");
}