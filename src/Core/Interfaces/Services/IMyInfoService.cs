using MyMVC6CoreTemplate.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6CoreTemplate.Core.Interfaces.Services
{
    public interface IMyInfoService
    {
        IList<PersonViewModel> GetInfo();
    }
}


