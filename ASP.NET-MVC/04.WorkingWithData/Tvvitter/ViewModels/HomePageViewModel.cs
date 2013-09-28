using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tvvitter.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Tvvitter.ViewModels.UserViewModel> Users { get; set; }
        public IEnumerable<Tvvitter.ViewModels.TagViewModel> Tags { get; set; }
    }
}