using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using NUnit.Framework;

namespace API
{
    [TestClass]
    public class DropBox
    {
        public string token = "Bearer qbFIerytlJIAAAAAAAAAAZSzhoK8ScnOzMBcIdrY_KFQSGcNt9UmrLUOSIvCayp4";

        [TestMethod]
        public void Delete()
        {

            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "996bf2e8-edbb-6349-f7b2-01b026a8d59b");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddParameter("application/json", "{\n    \"path\":\"/Folder1/tomato.jpg\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string restResponse = response.Content;

            // Verifiying reponse
            /*if (!restResponse.Contains("Guntur"))

                Assert.Fail("Whether information is not displayed");*/

            NUnit.Framework.Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            NUnit.Framework.Assert.AreEqual(true, response.Content.Contains("tomato"));
        }

        [TestMethod]
        public void UpLoad()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "ad4b78e3-0577-1374-acac-b5d29325acb0");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/octet-stream");
            request.AddHeader("dropbox-api-arg", "{\"mode\":\"add\",\"autorename\":true,\"mute\":false,\"path\":\"/Folder1/tomato.jpg\"}");
            request.AddHeader("authorization", token);
            IRestResponse response = client.Execute(request);

            NUnit.Framework.Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            NUnit.Framework.Assert.AreEqual(true, response.Content.Contains("tomato"));
        }

        [TestMethod]
        public void GetFileMetadata()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "89e33e54-c720-5c13-bc8f-cd89a7c4ad79");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", token);
            request.AddParameter("application/json", "{\n\t\"path\": \"/flowers.jpg\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            NUnit.Framework.Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            NUnit.Framework.Assert.AreEqual(true, response.Content.Contains("flowers"));

        }
    }
}
