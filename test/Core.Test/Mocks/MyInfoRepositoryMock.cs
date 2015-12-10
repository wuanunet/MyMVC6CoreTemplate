using LightMock;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;
using MyMVC6CoreTemplate.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6CoreTemplate.Core.Test.Mocks
{
    internal class MyInfoRepositoryMock : IMyInfoRepository
    {
        private IInvocationContext<IMyInfoRepository> _contextMock;

        public MyInfoRepositoryMock(IInvocationContext<IMyInfoRepository> context)
        {
            this._contextMock = context;
        }
        public IList<Person> GetPersons()
        {
            return this._contextMock.Invoke(a => a.GetPersons());
        }
    }
}
