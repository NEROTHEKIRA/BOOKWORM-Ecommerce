using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{
    [DataContract]
    public class ProductBeneficiary
    {
        [DataMember(Name = "Prod_Benf_Id")]
        public int Prod_Benf_Id { get; set; }

        [DataMember(Name = "ProductMaster_Prod_Id")]
        public int Prod_Id { get; set; }

        [DataMember(Name = "Benf_Id")]
        public int Benf_Id { get; set; }

        [DataMember(Name = "Royalty_perc")]
        public int Royalty_perc { get; set; }

    }
   

}