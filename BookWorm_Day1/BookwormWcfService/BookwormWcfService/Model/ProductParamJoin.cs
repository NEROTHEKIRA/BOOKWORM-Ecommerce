using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookwormWcfService.Model
{

    public class ProductParamJoin
    {
        public Product p { get; set; }
        public Param param { get; set; }
        public ParamProduct paramProduct { get; set; }

    }
}