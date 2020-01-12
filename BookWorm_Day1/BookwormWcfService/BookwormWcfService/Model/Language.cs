using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BookWorm_Test_1.Pocos
{
    [DataContract]
    public class Language
    {
        [DataMember(Name = "Lang_Id")]
        public int Lang_Id { get; set; }

        [DataMember(Name = "Lang_desc")]
        public string Lang_desc { get; set; }

    }
}