using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService
{

    [DataContract]
    public class Product
    {
        /*
        [DataMember]
        public int  ProductMaster_Prod_Id{ get; set; }

         [DataMember]
           public int Prod_type_id { get; set; }

         [DataMember]
           public int      Prod_cat_id{ get; set; }
         [DataMember]
            public int     Prod_lang_id { get; set; }
        */

        [DataMember(Name = "Prod_title")]
        public string Prod_title{ get; set; }

        [DataMember(Name = "Prod_price")]
        public float Prod_price { get; set; }

        [DataMember(Name = "Prod_saleprice")]
        public float Prod_saleprice { get; set; }

        [DataMember(Name = "Prod_specialprice")]
        public float Prod_specialprice { get; set; }

        [DataMember(Name = "Prod_specialprice_fromdate")]
        public string Prod_specialprice_fromdate { get; set; }

        [DataMember(Name = "Prod_specialprice_todate")]
        public string Prod_specialprice_todate { get; set; }

        [DataMember(Name = "Prod_short_desc")]
        public string Prod_short_desc { get; set; }

        [DataMember(Name = "Prod_long_desc")]
        public string Prod_long_desc { get; set; }

        [DataMember(Name = "Prod_author")]
        public string Prod_author { get; set; }

        [DataMember(Name = "Prod_img")]
        public string Prod_img { get; set; }

        [DataMember(Name = "Prod_release_date")]
        public string Prod_release_date { get; set; }

        [DataMember(Name = "Prod_rent")]
        public Boolean Prod_rent { get; set; }

        [DataMember(Name = "Prod_lib")]
        public Boolean Prod_lib { get; set; }

        [DataMember(Name = "Prod_rent_amt")]
        public float Prod_rent_amt { get; set; }

        [DataMember(Name = "Prod_rent_mindays")]
        public int Prod_rent_mindays { get; set; }

        [DataMember(Name = "Prod_publisher")]
        public string Prod_publisher { get; set; }

        [DataMember(Name = "Type_Id")]
        public int Type_Id { get; set; }

        [DataMember(Name = "Lang_Id")]
        public int Lang_Id { get; set; }

        [DataMember(Name = "Cat_Id")]
        public int Cat_Id { get; set; }

        [DataMember(Name = "ProductMaster_Prod_Id")]
        public int ProductMaster_Prod_Id { get; set; }


       // *******************



    
    }
    
}
    /*
    [DataContract]
    public class TypeTable
    {
        [DataMember]
        public string Type_desc { get; set; }
    }

    */

    /*
    public class Products
    {

        public static List<Product> booklist = new List<Product>()
    {
            new Product(){   Prod_title="2state" , Prod_price=20.0f} ,
            new Product(){   Prod_title="3state" , Prod_price=20.0f} 
            
    };
     * */
