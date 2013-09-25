using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class Movie
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Director { get; set; }
        public virtual string Studio { get; set; }
        public virtual string StudioAddress { get; set; }
        public virtual int Year { get; set; }
        public virtual Actor LeadMaleActor { get; set; }
        public virtual Actor LeadFemaleActor { get; set; }
    }
}