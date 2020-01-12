using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookWorm_Day1.Models
{


    [DataContract]
    public class Product
    {

        [DataMember]
        public int Prod_Id;

        [DataMember]
        public string Prod_title;

        [DataMember]
        public float Prod_price;

        [DataMember]
        public float Prod_saleprice;

        [DataMember]
        public float Prod_specialprice;

        [DataMember]
        public string Prod_specialprice_fromdate;

        [DataMember]
        public string Prod_specialprice_todate;

        [DataMember]
        public string Prod_short_desc;

        [DataMember]
        public string Prod_long_desc;

        [DataMember]
        public string Prod_author;

        [DataMember]
        public string Prod_img;

        [DataMember]
        public string Prod_release_date;

        [DataMember]
        public short Prod_rent;

        [DataMember]
        public short Prod_lib;

        [DataMember]
        public float Prod_rent_amt;

        [DataMember]
        public int Prod_rent_mindays;

        [DataMember]
        public string Prod_publisher;

        [DataMember]
        public short DayOfSale;


    }
}