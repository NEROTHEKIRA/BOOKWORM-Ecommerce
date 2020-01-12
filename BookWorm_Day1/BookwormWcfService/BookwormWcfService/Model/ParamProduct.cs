using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{
    [DataContract]
    public class ParamProduct
    {
        [DataMember]
        public int Param_Product_Id { get; set; }

        [DataMember]
        public int Prod_Id { get; set; }

        [DataMember]
        public int Param_Param_Id { get; set; }

        [DataMember]
        public string Param_Value { get; set; }
    }
}