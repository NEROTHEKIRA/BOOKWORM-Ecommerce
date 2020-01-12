using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService
{
    
    [DataContract]
    public class UserInfo
    {

        [DataMember(Name = "User_Id")]
        public int User_Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "House_no")]
        public int House_no { get; set; }

        [DataMember(Name = "Street")]
        public string Street { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "Pincode")]
        public int Pincode { get; set; }

        [DataMember(Name = "Landmark")]
        public string Landmark { get; set; }

        [DataMember(Name = "Date_of_birth")]
        public string Date_of_birth { get; set; }


    }
}