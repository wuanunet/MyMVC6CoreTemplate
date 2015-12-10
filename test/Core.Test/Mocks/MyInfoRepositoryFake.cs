using LightMock;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;
using MyMVC6CoreTemplate.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6CoreTemplate.Core.Test.Mocks
{
    public class MyInfoRepositoryMock : IMyInfoRepository
    {
        private IInvocationContext<IMyInfoRepository> _contextMock;

        public MyInfoRepositoryMock()
        {
            this._contextMock = new MockContext<IMyInfoRepository>();
            SetData();
        }

        public MockContext<IMyInfoRepository> Mock
        {
            get
            {
                return this._contextMock as MockContext<IMyInfoRepository>;
            }
        }

        public IList<Person> GetPersons()
        {
            return this._contextMock.Invoke(a => a.GetPersons());
        }

        private void SetData()
        {
            var repMock = this.Mock;
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
                            Name=name+"2",
                            Age=age-2,
                            Birthday=dd.AddYears(-2),
                            Created=dd.AddDays(-2)
                        }

                    }.ToList();
                });
        }

    }
}
