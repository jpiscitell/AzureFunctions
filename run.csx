#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];
    string title = req.Query["title"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    //dynamic data = JsonConvert.DeserializeObject(requestBody);
    //name = name ?? data?.name;

    string responseMessage = string.IsNullOrEmpty(name)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. Are you really a {title}? This HTTP triggered function executed successfully. There was some data in the body: {requestBody}. I updated this in VS Code 1919.";

            return new OkObjectResult(responseMessage);
}