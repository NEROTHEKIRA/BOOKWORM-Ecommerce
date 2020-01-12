using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class Category
    {
        [DataMember(Name = "Cat_Id")]
        public int Cat_Id { get; set; }

        [DataMember(Name = "Cat_desc")]
        public string Cat_desc { get; set; }
    }
}