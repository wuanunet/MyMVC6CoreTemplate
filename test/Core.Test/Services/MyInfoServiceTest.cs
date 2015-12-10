using LightMock;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;
using MyMVC6CoreTemplate.Core.Models.Entities;
using MyMVC6CoreTemplate.Core.Services;
using MyMVC6CoreTemplate.Core.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyMVC6CoreTemplate.Core.Test.Services
{
    //https://github.com/neil-119/LightMock
    //https://xunit.github.io/docs/getting-started-dnx.html
    public class MyInfoServiceTest
    {
        //GetInfo
        [Fact]
        void TestGetInfo()
        {
            //arrage
            var age = 50;
            var name = "Bibby";
            var repFake = new MyInfoRepositoryMock();
            var mock = repFake.Mock;

            //act
            var ser = new MyInfoService(repFake);
            var actual = ser.GetInfo();

            //assert
            Assert.Equal(2, actual.Count);
            mock.Assert(a => a.GetPersons(), Invoked.Once);

            var item1 = actual.First();
            Assert.Equal(name + "1", item1.Name);
            Assert.Equal(age - 1, item1.Age);

            var item2 = actual.Skip(1).First();
            Assert.Equal(name + "2", item2.Name);
            Assert.Equal(age - 2, item2.Age);

        }



    }
}
