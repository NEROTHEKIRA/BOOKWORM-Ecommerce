using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService
{
    [DataContract]
    public class TypePoco
    {
        [DataMember(Name = "Type_Id")]
        public int Type_Id { get; set; }

        [DataMember(Name = "Type_desc")]
        public string Type_desc { get; set; }
    }
}