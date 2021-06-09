using Flurl.Http;
using NUnit.Framework;
using System;
using HW_8.Framework.Models;
using System.Text.Json;

namespace HW_8.Tests
{
    [TestFixture]
    public class PutPatchTest
    {
        [Test]
        public void PutTest()
        {
            PostModel postModelPut = new PostModel() { UserId = "1", Title = "2", Body = "3" };

            var response = "https://jsonplaceholder.typicode.com/posts/1".PutJsonAsync(postModelPut).Result;
            var responsebody = response.ResponseMessage.Content.ReadAsStringAsync().Result;



            var json = JsonSerializer.Serialize<PostModel>(postModelPut);

            PostModel putTest = JsonSerializer.Deserialize<PostModel>(responsebody);

            var serializejson = JsonSerializer.Serialize<PostModel>(putTest);


            Assert.AreEqual(json, serializejson);
            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]

        public void PatchTest()
        {
            PostModel postModelPatch = new PostModel() { Body = "I change this body" };


            var response = "https://jsonplaceholder.typicode.com/posts/1".PatchJsonAsync(postModelPatch).Result;
            var responsebody = response.ResponseMessage.Content.ReadAsStringAsync().Result;



            var json = JsonSerializer.Serialize<PostModel>(postModelPatch);

            PostModel patchTest = JsonSerializer.Deserialize<PostModel>(responsebody);

            var serializejson = JsonSerializer.Serialize<PostModel>(patchTest);


            Assert.AreEqual(json, serializejson);
            Assert.AreEqual(200, response.StatusCode);
        }
    }
}
