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

        public PersonViewModel GetInfo()
        {

            var pv = new PersonViewModel()
            {
                Name = "Bibby Chung",
                Age = 22,
                Birthday = DateTime.Now.AddDays(30)
            };

            return pv;

        }

    }
}
