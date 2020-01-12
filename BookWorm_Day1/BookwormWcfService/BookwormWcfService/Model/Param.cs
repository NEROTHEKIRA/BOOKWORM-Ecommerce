using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{
    [DataContract]
    public class Param
    {
        [DataMember]
        public int Param_Id { get; set; }

        [DataMember]
        public string Param_desc { get; set; }
    }
}