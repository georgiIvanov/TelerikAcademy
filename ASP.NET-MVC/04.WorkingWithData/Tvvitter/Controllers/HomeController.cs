using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvvitter.Data;
using Tvvitter.Models;
using Tvvitter.Utility;
using Tvvitter.ViewModels;

namespace Tvvitter.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ITvvitterData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var users = this.Data.Users.All();
            var tags = this.Data.Tags.All();

            HomePageViewModel vm = new HomePageViewModel()
            {
                Tags = tags.TagsToViewModels(),
                Users = users.UsersToViewModels()
            };

            return View(vm);
        }

        public ActionResult UserPage(string Id)
        {
            var appUser = this.Data.Users.GetById(Id);

            UserPageViewModel vm = CreateUserViewModel(appUser);

            return View(vm);
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            var id = User.Identity.GetUserId();

            if (id != null)
            {
                var appUser = this.Data.Users.GetById(id);

                UserPageViewModel vm = CreateUserViewModel(appUser);

                return View("UserPage", vm);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
        }

        private static UserPageViewModel CreateUserViewModel(ApplicationUser appUser)
        {
            UserPageViewModel vm = new UserPageViewModel()
            {
                Username = appUser.UserName,
                Tweets = appUser.Tweets.OrderByDescending(x => x.DateCreated).ToList(),
                Tweet = new Tweet()
            };
            return vm;
        }

        [HttpPost]
        public ActionResult UserPage(string Id, [Bind(Exclude = "Id")] Tweet postedTweet)
        {
            var appUser = this.Data.Users.GetById(Id);
            if (ModelState.IsValid)
            {

                postedTweet.User = appUser;
                postedTweet.DateCreated = DateTime.Now;
                appUser.Tweets.Add(postedTweet);
                //this.Data.Tweets.Add(postedTweet);
                this.Data.SaveChanges();

                var words = postedTweet.Message.Split();
                postedTweet.Tags = new HashSet<Tag>();
                foreach (var word in words)
                {
                    if (word[0] == '#')
                    {
                        var newTag = new Tag()
                        {
                            Name = word
                        };
                        var tag = this.Data.Tags.All().FirstOrDefault(x => x.Name == word);
                        if (tag != null)
                        {
                            postedTweet.Tags.Add(tag);
                        }
                        else
                        {
                            postedTweet.Tags.Add(newTag);
                        }

                    }
                }

                this.Data.SaveChanges();
            }

            UserPageViewModel vm = CreateUserViewModel(appUser);

            return View(vm);

        }

        [OutputCacheAttribute(VaryByParam = "name", Duration = 900)]
        public ActionResult TweetsByTag(string name)
        {
            var tag = this.Data.Tags.GetById(name);
            var tweets = tag.Tweets.TweetsToViewModels();

            return View(tweets);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}