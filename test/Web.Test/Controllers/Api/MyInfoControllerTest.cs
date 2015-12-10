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
                .UseStartup<StartupFake>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Arrange
            var age = 50;
            var name = "Bibby";
            var expectedObj = new List<PersonViewModel>() {
                new PersonViewModel() {
                    Name=name+"1",
                    Age=age-1
                },
                new PersonViewModel() {
                    Name=name+"2",
                    Age=age-2
                }
            };
            var path = "/Api/MyInfo";

            // Act
            var req = await _client.GetAsync(path);
            req.EnsureSuccessStatusCode();
            var actual = await req.Content.ReadAsStringAsync();
            var actualObj = JsonConvert.DeserializeObject<List<PersonViewModel>>(actual);

            // Assert
            Assert.Equal(expectedObj.First().Name, actualObj.First().Name);
            Assert.Equal(expectedObj.First().Age, actualObj.First().Age);
        }

    }
}
