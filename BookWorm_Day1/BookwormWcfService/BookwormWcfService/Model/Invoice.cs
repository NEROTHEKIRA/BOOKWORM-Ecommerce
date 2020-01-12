using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public int Invoice_Id;

        [DataMember]
        public int ProductMaster_Prod_Id;

        [DataMember]
        public float Prod_saleprice;

        [DataMember]
        public int UserId;

    }
}