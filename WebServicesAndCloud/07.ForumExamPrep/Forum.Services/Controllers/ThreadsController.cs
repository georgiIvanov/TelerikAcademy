using Forum.DataLayer;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Forum.Services.Attributes;
using Forum.Services.Models;

namespace Forum.Services.Controllers
{
    public class ThreadsController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetThreadsByCategory(string category, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr =>
    usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }

                    var threadEntities = context.Threads
                        .Where((x) => x.Categories
                            .Any((y) => y.CategoryName.Contains(category)));

                    var models =
                        (from threadEntity in threadEntities
                         select new ThreadModel()
                         {
                             Id = threadEntity.Id,
                             Title = threadEntity.Title,
                             DateCreated = threadEntity.DateCreated,
                             Content = threadEntity.Content,
                             CreatedBy = threadEntity.User.Nickname,
                             Posts = (from postEntity in threadEntity.Posts
                                      select new PostModel()
                                      {
                                          Content = postEntity.PostContent,
                                          PostDate = postEntity.PostDate,
                                          PostedBy = postEntity.User.Nickname
                                      }),
                             Categories = (from categoryEntity in threadEntity.Categories
                                           select categoryEntity.CategoryName)
                         });
                    var ordered = models.OrderByDescending(thr => thr.DateCreated).ToList();

                    var responce = this.Request.CreateResponse(HttpStatusCode.OK, ordered);

                    return responce;

                }
            });

            return responceMsg;
        }

        // GET api/threads
        [HttpGet]
        public HttpResponseMessage Get([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr =>
    usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }

                    var threadEntities = context.Threads;
                    var models = (from threadEntity in threadEntities
                                  select new ThreadModel()
                                  {
                                      Id = threadEntity.Id,
                                      Title = threadEntity.Title,
                                      DateCreated = threadEntity.DateCreated,
                                      Content = threadEntity.Content,
                                      CreatedBy = threadEntity.User.Nickname,
                                      Posts = (from postEntity in threadEntity.Posts
                                               select new PostModel()
                                               {
                                                   Content = postEntity.PostContent,
                                                   PostDate = postEntity.PostDate,
                                                   PostedBy = postEntity.User.Nickname
                                               }),
                                      Categories = (from categoryEntity in threadEntity.Categories
                                                    select categoryEntity.CategoryName)
                                  });
                    var ordered = models.OrderByDescending(thr => thr.DateCreated).ToList();

                    var responce = this.Request.CreateResponse(HttpStatusCode.OK, ordered);

                    return responce;

                }
            });

            return responceMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetPage(int page, int count, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr =>
    usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }

                    var threadEntities = context.Threads.OrderBy(x => x.DateCreated).Skip(page * count).Take(count);
                    var models = (from threadEntity in threadEntities
                                  select new ThreadModel()
                                  {
                                      Id = threadEntity.Id,
                                      Title = threadEntity.Title,
                                      DateCreated = threadEntity.DateCreated,
                                      Content = threadEntity.Content,
                                      CreatedBy = threadEntity.User.Nickname,
                                      Posts = (from postEntity in threadEntity.Posts
                                               select new PostModel()
                                               {
                                                   Content = postEntity.PostContent,
                                                   PostDate = postEntity.PostDate,
                                                   PostedBy = postEntity.User.Nickname
                                               }),
                                      Categories = (from categoryEntity in threadEntity.Categories
                                                    select categoryEntity.CategoryName)
                                  });
                    var ordered = models.OrderByDescending(thr => thr.DateCreated).ToList();

                    var responce = this.Request.CreateResponse(HttpStatusCode.OK, ordered);

                    return responce;

                }
            });

            return responceMsg;
        }

        [HttpGet]
        public HttpResponseMessage Posts(int threadId, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr =>
    usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }

                    var threadEntity = context.Threads.FirstOrDefault(x => x.Id == threadId);

                    var posts = (from postEntity in threadEntity.Posts
                                 select new PostModel()
                                 {
                                     Content = postEntity.PostContent,
                                     PostDate = postEntity.PostDate,
                                     PostedBy = postEntity.User.Nickname
                                 }).ToList();

                    var responce = this.Request.CreateResponse(HttpStatusCode.OK, posts);

                    return responce;

                }
            });

            return responceMsg;
        }

        // POST api/threads
        public HttpResponseMessage Post(ThreadModel value, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responceMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new ForumDbContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(usr =>
    usr.Nickname == value.CreatedBy && usr.SessionKey == sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username and password.");
                    }

                    Thread newThread = new Thread()
                    {
                        Categories = new HashSet<Category>(SerializeCategories(context, value.Categories)),
                        DateCreated = DateTime.Now,
                        Content = value.Content,
                        Posts = null,
                        Title = value.Title,
                        User = user
                    };

                    context.Threads.Add(newThread);
                    context.SaveChanges();

                    newThread.User = null;

                    var responce = this.Request.CreateResponse(HttpStatusCode.Created, newThread);

                    return responce;

                }
            });

            return responceMsg;
        }

        [NonAction]
        public IEnumerable<Category> SerializeCategories(ForumDbContext context, IEnumerable<string> categories)
        {
            if (categories == null)
            {
                yield return null;
            }
            foreach (var category in categories)
            {
                var foundCat = (from c in context.Categories
                                where c.CategoryName == category
                                select c).FirstOrDefault();

                if (foundCat == null)
                {
                    continue;
                }
                yield return new Category()
                    {
                        CategoryName = foundCat.CategoryName
                    };
            }
        }

    }
}
