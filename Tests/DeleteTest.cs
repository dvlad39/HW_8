using Flurl.Http;
using NUnit.Framework;


namespace HW_8.Tests
{
    [TestFixture]
    public class DeleteTest
    {
        [Test]
        public void Delete()
        {
            var response = "https://jsonplaceholder.typicode.com/posts/1".DeleteAsync().Result;
            Assert.AreEqual(200, response.StatusCode);

        }
    }
}
