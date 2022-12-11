using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

// Build request to acquire managed identities for Azure resources token
HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/&mi_res_id=/subscriptions/cec7d974-3bb5-409a-97fe-187dc2843eeb/resourceGroups/mb-rg-centralus/providers/Microsoft.ManagedIdentity/userAssignedIdentities/2108090050002145");
request.Headers["Metadata"] = "true";
request.Method = "GET";

// Call /token endpoint
HttpWebResponse response = (HttpWebResponse)request.GetResponse();


// Pipe response Stream to a StreamReader, and extract access token
StreamReader streamResponse = new StreamReader(response.GetResponseStream()); 
string stringResponse = streamResponse.ReadToEnd();
var stringResponseToJson = JsonConvert.DeserializeObject(stringResponse);
Console.WriteLine(stringResponseToJson);

