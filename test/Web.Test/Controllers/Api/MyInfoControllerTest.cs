using Microsoft.AspNet.TestHost;
using MyMVC6CoreTemplate.Core.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyMVC6CoreTemplate.Web.Test.Controllers.Api
{
    public class MyInfoControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public MyInfoControllerTest()
        {
            _server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Arrange
            var obj = new List<PersonViewModel>();
            var expected = JsonConvert.SerializeObject(obj);
            var path = "/Api/MyInfo";

            // Act
            var req = await _client.GetAsync(path);
            req.EnsureSuccessStatusCode();
            var actual = await req.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
