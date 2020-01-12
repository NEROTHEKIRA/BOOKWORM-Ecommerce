using BookWorm_Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookWorm_Day1
{
    [ServiceContract]
    public interface ProductService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddProduct", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Boolean AddProduct(Product product);


    }


}
