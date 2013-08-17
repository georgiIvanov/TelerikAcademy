using CodeJewels.DataLayer;
using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeJewels.Service.Controllers
{
    public class CategoryJewelsController : ApiController
    {
        CodeJewelsContext dbContext;

        public CategoryJewelsController(CodeJewelsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/categoryjewels
        public IEnumerable<JewelCategory> Get()
        {
            return this.dbContext.JewelCategories.AsEnumerable();
        }

        // GET api/categoryjewels/5
        public JewelCategory Get(int id)
        {
            return this.dbContext.JewelCategories.Find(id);
        }

        // POST api/categoryjewels
        public JewelCategory Post(JewelCategory value)
        {
            var added = this.dbContext.JewelCategories.Add(value);
            this.dbContext.SaveChanges();

            return added;
        }

        // PUT api/categoryjewels/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/categoryjewels/5
        public void Delete(int id)
        {
        }
    }
}
