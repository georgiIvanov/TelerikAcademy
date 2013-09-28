using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tvvitter.Models;
using Tvvitter.ViewModels;

namespace Tvvitter.Utility
{
    public static class ModelsToViewModels
    {
        public static UserViewModel UserToViewModel(this ApplicationUser user)
        {
            var converted = new UserViewModel()
            {
                Id = user.Id,
                Name = user.UserName
            };

            return converted;
        }

        public static IQueryable<UserViewModel> UsersToViewModels(this IQueryable<ApplicationUser> users)
        {
            var converted = users.Select(u => new UserViewModel()
            {
                Id = u.Id,
                Name = u.UserName
            });

            return converted;
        }

        public static IQueryable<TagViewModel> TagsToViewModels(this IQueryable<Tag> tags)
        {
            var converted = tags.Select(u => new TagViewModel()
            {
                Name = u.Name
            });

            return converted;
        }

        public static IEnumerable<TweetViewModel> TweetsToViewModels(this ICollection<Tweet> tweets)
        {
            var converted = tweets.Select(u => new TweetViewModel()
            {
                Id = u.Id,
                DateCreated = u.DateCreated,
                Message = u.Message
               
            });

            return converted;
        }
    }
}