using FluentAssertions;
using Flurl.Http;
using NUnit.Framework;
using HW_8.Framework.Models;


namespace HW_8.Tests
{
    [TestFixture]
    public class GetTest
    {
        [Test]
        public void Getter()
        {
            GetModel getModel = new GetModel() { UserId = "1" };

            var response = "https://jsonplaceholder.typicode.com/posts".GetAsync().Result;
            var responsebody = response.ResponseMessage.Content.ReadAsStringAsync().Result;

            Assert.AreEqual(200, response.StatusCode);

            responsebody.Should().Contain(getModel.UserId);
            
            



        } 
        
    }
}
