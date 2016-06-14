using Bibliotopia_4._5._2.DAL;
using Bibliotopia_4._5._2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bibliotopia_4._5._2.Controllers.API
{
    public class NookController : ApiController
    {

        private BibliotopiaRepository repo = new BibliotopiaRepository();
        
        // GET api/<controller>
        public ReadingNook Get()
        {
            var user_id = User.Identity.GetUserId();
            return repo.GetNookForGivenUser(user_id);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}