using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookwormWcfService.Model
{
    [DataContract]
    public class Beneficiary
    {
        [DataMember(Name = "Benf_Id")]
        public int Benf_Id { get; set; }

        [DataMember(Name = "Benf_name")]
        public string Benf_name { get; set; }

        [DataMember(Name = "Benf_acc_no")]
        public int Benf_acc_no { get; set; }

        [DataMember(Name = "Benf_contact_no")]
        public int Benf_contact_no { get; set; }

        [DataMember(Name = "Benf_email_id")]
        public string Benf_email_id { get; set; }

    }
}