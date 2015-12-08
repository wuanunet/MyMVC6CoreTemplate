using MyMVC6Template.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMVC6Template.Core.Interfaces.Services
{
    public interface IMyInfoService
    {
        PersonViewModel GetInfo();
    }
}


