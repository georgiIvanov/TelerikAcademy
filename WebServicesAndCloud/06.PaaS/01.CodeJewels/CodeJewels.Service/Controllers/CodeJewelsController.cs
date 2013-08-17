using CodeJewels.DataLayer;
using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeJewels.Service.Controllers
{
    public class CodeJewelsController : ApiController
    {
        CodeJewelsContext dbContext;

        public CodeJewelsController(CodeJewelsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET api/codejewels
        public IEnumerable<CodeJewel> Get()
        {
            var found = this.dbContext.CodeJewels.AsEnumerable().ToList();

            return SerializeCodeJewel(found);
        }

        [NonAction]
        public IEnumerable<CodeJewel> SerializeCodeJewel(IEnumerable<CodeJewel> found)
        {
            foreach (var item in found)
            {
                yield return new CodeJewel()
                {
                    Id = item.Id,
                    AuthorEmail = item.AuthorEmail,
                    CategoryId = item.CategoryId,
                    Content = item.Content,
                    JewelCategory = item.JewelCategory,
                    Rating = item.Rating
                };
            }
        }

        // GET api/codejewels/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [ActionName("votedown")]
        public HttpResponseMessage VoteDown(int id)
        {
            var found = this.dbContext.CodeJewels.Find(id);
            HttpResponseMessage responce;

            if (found != null)
            {
                found.Rating -= 1;
                if (found.Rating < -10)
                {
                    this.dbContext.CodeJewels.Remove(found);
                }
                this.dbContext.SaveChanges();
                responce = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                responce = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return responce;
        }

        [HttpGet]
        [ActionName("voteup")]
        public HttpResponseMessage VoteUp(int id)
        {
            var found = this.dbContext.CodeJewels.Find(id);
            HttpResponseMessage responce;

            if (found != null)
            {
                found.Rating += 1;
                this.dbContext.SaveChanges();
                responce = Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                responce = Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return responce;
        }

        [HttpGet]
        [ActionName("searchbycontent")]
        public IEnumerable<CodeJewel> SearchByContent(string code)
        {
            var found = (from c in this.dbContext.CodeJewels
                        where c.Content.Contains(code)
                        select c);

            return SerializeCodeJewel(found);
        }

        [HttpGet]
        [ActionName("searchbycategory")]
        public IEnumerable<CodeJewel> SearchByCategory(int categoryId)
        {
            var found = (from c in this.dbContext.CodeJewels
                         where c.CategoryId == categoryId
                         select c).ToList();

            return SerializeCodeJewel(found);
        }

        // POST api/codejewels
        public HttpResponseMessage Post(CodeJewel value)
        {
            var added = this.dbContext.CodeJewels.Add(value);

            HttpResponseMessage responce;

            try
            {
                this.dbContext.SaveChanges();
                responce = Request.CreateResponse<CodeJewel>(HttpStatusCode.Created, added);
            }
            catch (Exception ex)
            {
                responce = Request.CreateResponse<CodeJewel>(HttpStatusCode.InternalServerError, added);
                this.dbContext.CodeJewels.Local.Clear();
            }

            
            var resourceLink = Url.Link("DefaultApi", new { id = added.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }



        // PUT api/codejewels/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/codejewels/5
        public void Delete(int id)
        {
        }
    }
}
