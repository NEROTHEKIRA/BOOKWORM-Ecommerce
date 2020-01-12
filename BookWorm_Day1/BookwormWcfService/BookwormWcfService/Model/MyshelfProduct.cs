using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{

    [DataContract]
    public class MyshelfProduct
    {

        [DataMember]
        public int Shelf_user_id { get; set; }

        [DataMember]
        public int Shelf_prod_id { get; set; }

        [DataMember]
        public string Prod_img { get; set; }

        [DataMember]
        public string Prod_short_desc { get; set; }

        [DataMember]
        public string Prod_long_desc { get; set; }


        [DataMember]
        public string Prod_title { get; set; }


    }
}