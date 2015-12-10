using System.Collections.Generic;
using MyMVC6CoreTemplate.Core.Models.Entities;

namespace MyMVC6CoreTemplate.Core.Interfaces.Repositories
{
    public interface IMyInfoRepository
    {
        IList<Person> GetPersons();
    }
}