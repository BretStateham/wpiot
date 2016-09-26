using System.Net;
using Microsoft.Azure.Devices;
using System.Text;

//In the portal, open up the IoT Hub, then "Shared Access Policies" and copy the primary connection string
//for the "service" access policy and paste it in below
static string connectionString = "HostName=wpiothub.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=fVL/bAYkIwGnx4eGDcHaKscHlw5RhFZQJqUOBr5OOcE=";

static ServiceClient serviceClient;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");

    serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

    //Replace the string in the "GetBytes()" method call with your own message that you want to send 
    //to your device
    var commandMessage = new Message(Encoding.ASCII.GetBytes("{\"Name\":\"DanceMonkey\",\"Parameters\":\"\"}"));
    
    //Replace "commentMonkey" below with the deviceID for the device you want to send the message to.  
    await serviceClient.SendAsync("commentmonkey", commandMessage);

    return req.CreateResponse(HttpStatusCode.OK);
}

