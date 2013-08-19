using Forum.DataLayer;
using Forum.Models;
using Forum.Services.Attributes;
using Forum.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace Forum.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        // GET api/posts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/posts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/posts
        public HttpResponseMessage Post(PostModel value, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey 
                        && usr.Nickname == value.PostedBy);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }



                    Post newPost = new Post()
                    {
                        PostDate = DateTime.Now,
                        PostContent = value.Content,
                        Thread = context.Threads.FirstOrDefault(x => x.Id == value.ThreadId),
                        User = user
                    };

                    context.Posts.Add(newPost);
                    context.SaveChanges();

                    //newPost.User = null;

                    var responce = this.Request.CreateResponse(HttpStatusCode.Created);

                    return responce;

                }
            });

            return responceMsg;
        }

        // PUT api/posts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/posts/5
        public void Delete(int id)
        {
        }
    }
}
