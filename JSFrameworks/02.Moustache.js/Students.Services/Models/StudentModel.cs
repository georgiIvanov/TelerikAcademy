using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.Models
{
    [DataContract]
    public class StudentModel
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<MarkModel> Marks { get; set; }

        [DataMember(Name = "fullname")]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

    }
}