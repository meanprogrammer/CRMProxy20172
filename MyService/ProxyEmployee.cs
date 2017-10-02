using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyService
{
    [DataContract]
    public class ProxyEmployee
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}