using MyMVC6CoreTemplate.Core.Common;
using MyMVC6CoreTemplate.Core.Interfaces.Repositories;
using MyMVC6CoreTemplate.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6CoreTemplate.Core.Repositories
{

    public class MyInfoRepository : IMyInfoRepository
    {
        private MyDbContext _myDbContext;

        public MyInfoRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public IList<Person> GetPersons()
        {
            return this._myDbContext.Persons.ToList();
        }
    }
}
