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
            var repMock = new MockContext<IMyInfoRepository>();
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var dd = DateTime.Now;
            var age = 50;
            var name = "Bibby";
            repMock.Arrange(a => a.GetPersons())
                .Returns(() =>
                {
                    return new[] {
                        new Person {
                            Id=guid1,
                            Name=name+"1",
                            Age=age-1,
                            Birthday=dd.AddYears(-1),
                            Created=dd.AddDays(-1)
                        },
                        new Person {
                            Id=guid2,
                            Name=name+2,
                            Age=age-2,
                            Birthday=dd.AddYears(-2),
                            Created=dd.AddDays(-2)
                        }

                    }.ToList();
                });

            //act
            var ser = new MyInfoService(new MyInfoRepositoryMock(repMock));
            var actual = ser.GetInfo();

            //assert
            Assert.Equal(2, actual.Count);
            repMock.Assert(a => a.GetPersons(), Invoked.Once);
            var item = actual.First();
            Assert.Equal(name + "1", item.Name);
            Assert.Equal(age - 1, item.Age);

        }



    }
}
