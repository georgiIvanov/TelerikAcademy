using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.Models
{
    [DataContract]
    public class MarkModel
    {
        [DataMember(Name="subject")]
        public string Subject { get; set; }
        [DataMember(Name="score")]
        public double Score { get; set; }
    }
}