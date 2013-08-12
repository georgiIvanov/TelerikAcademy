using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDatabase.Controllers
{
    public class MarksController : ApiController
    {
        // GET api/marks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/marks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/marks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/marks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/marks/5
        public void Delete(int id)
        {
        }
    }
}
