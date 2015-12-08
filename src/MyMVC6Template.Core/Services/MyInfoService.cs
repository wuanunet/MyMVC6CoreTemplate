using MyMVC6Template.Core.Interfaces.Repositories;
using MyMVC6Template.Core.Interfaces.Services;
using MyMVC6Template.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6Template.Core.Services
{
    public class MyInfoService : IMyInfoService
    {
        private IMyInfoRepository _myInfoRepository;

        public MyInfoService(IMyInfoRepository myInfoRepository)
        {
            this._myInfoRepository = myInfoRepository;
        }

        public IList<PersonViewModel> GetInfo()
        {
            var data = _myInfoRepository.GetPersons();
       
            return data.Select(a =>
             {
                 var newP = new PersonViewModel();
                 newP.Name = a.Name;
                 newP.Age = a.Age;
                 newP.Birthday = a.Birthday;
                 return newP;

             }).ToList();
           
        }

    }
}
