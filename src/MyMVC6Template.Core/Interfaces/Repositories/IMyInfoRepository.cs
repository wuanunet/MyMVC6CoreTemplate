using System.Collections.Generic;
using MyMVC6Template.Core.Models.Entities;

namespace MyMVC6Template.Core.Interfaces.Repositories
{
    public interface IMyInfoRepository
    {
        IList<Person> GetPersons();
    }
}