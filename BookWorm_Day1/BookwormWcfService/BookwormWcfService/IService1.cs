using BookWorm_Test_1.Pocos;
using BookwormWcfService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookwormWcfService
{
        [ServiceContract]
        public interface IService1
        {

            //-------------------Already Present --------------------/


            [OperationContract]
            [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddUser")]
            Boolean AddUser(UserInfo user);
            
            [OperationContract]
            [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "/AddProduct")]
            Boolean AddProduct(Product product);
            

            [WebGet(UriTemplate = "/GetAllTypeList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<TypePoco> GetAllTypeList();

            [WebGet(UriTemplate = "/GetAllLanguageList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<Language> GetAllLanguageList();

            [WebGet(UriTemplate = "/GetAllCategoryList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<Category> GetAllCategoryList();

            [OperationContract]
            [WebGet(UriTemplate = "/GetBookList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<Product> GetBookList();


            //-------------------------- New Addedd................

            //Akshta

            [OperationContract]
            [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddBeneficiary")]
            Boolean AddBeneficiary(Beneficiary benf);

            [OperationContract]
            [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddProductBeneficiary")]
            Boolean AddProductBeneficiary(ProductBeneficiary prodbenf);

            [WebGet(UriTemplate = "/GetAllBeneficiaryList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<Beneficiary> GetAllBeneficiaryList();

            [WebGet(UriTemplate = "/GetAllProductList", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
            List<Product> GetAllProductList();


            //---------------------------------------------------------


            //***************ankita-------------------------

            [OperationContract]
            [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CategoryWiseGetList/{Type_Id}/{Lang_Id}/{Cat_Id}")]
            List<ProductParamJoin> CategoryWiseGetList(string Type_Id, string Lang_Id, string Cat_Id);


            [OperationContract]
            [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserDetail/{Email}/{Password}")]
            Int32 GetUserDetail(string Email, string Password);


            [OperationContract]
            [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetMyShelfProduct/{userid}")]
            List<MyshelfProduct> GetMyShelfProduct(string userid);

            [OperationContract]
            [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/AddInvoice")]
            Boolean AddInvoice(Invoice invoice);

            //---------------------------------------------------------



















            //**********************************************


        }
   
}
