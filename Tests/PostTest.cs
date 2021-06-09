using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using NUnit.Framework;
using HW_8.Framework.Models;
using System.Text.Json;
using FluentAssertions;

namespace HW_8.Tests
{
    [TestFixture]
    public class PostTest
    {
        [Test]
        public void PostTest1()
        {
            PostModel postModel = new PostModel()
            {
                Title = "1",
                Body = "2",
                UserId = "3"
            };
            //string json = JsonSerializer.Serialize<PostModel>(postModel);
            var response = "https://jsonplaceholder.typicode.com/posts".PostJsonAsync(postModel).Result;
            var responsebody = response.ResponseMessage.Content.ReadAsStringAsync().Result;

            var json = JsonSerializer.Serialize<PostModel>(postModel);
            

            PostModel postTest = JsonSerializer.Deserialize<PostModel>(responsebody);

            var serializejson = JsonSerializer.Serialize<PostModel>(postTest);

            Assert.AreEqual(201, response.StatusCode);
            Assert.AreEqual(json, serializejson);

           // response.Should().Contain(json);

        }


    }
}
