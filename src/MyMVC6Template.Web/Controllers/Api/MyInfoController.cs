using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMVC6Template.Core.Interfaces.Services;
using MyMVC6Template.Core.Models.DTOs;

namespace MyMVC6Template.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class MyInfoController : Controller
    {
        private IMyInfoService _myInfoService;

        public MyInfoController(IMyInfoService myInfoService)
        {
            this._myInfoService = myInfoService;
        }

        // GET: api/values
        [HttpGet]
        public PersonViewModel Get()
        {
            var info = this._myInfoService.GetInfo();
            return info;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
