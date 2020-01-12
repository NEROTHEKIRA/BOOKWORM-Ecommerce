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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        ProductRepository products = new ProductRepository();

        Boolean IService1.AddProduct(Product product)
        {       
                return products.AddProduct(product);
           
        }

 
        List<TypePoco> IService1.GetAllTypeList()
        {
            return products.GetAllTypeList();
        }


        List<Language> IService1.GetAllLanguageList()
        {
            return products.GetAllLanguageList();
        }




        List<Category> IService1.GetAllCategoryList()
        {
            return products.GetAllCategoryList();
        }


       /* List<Product> IService1.CategoryWiseGetList(string Type_Id, string Lang_Id, string Cat_Id)
        {
            return products.CategoryWiseGetList( Type_Id,  Lang_Id,  Cat_Id);
        }*/

        List<Product> IService1.GetBookList()
        {
            return products.GetBookList();
        }




        ////////////////*****************akshta******************************************
        bool IService1.AddBeneficiary(Beneficiary benf)
        {
            return products.AddBeneficiary(benf);
        }

        bool IService1.AddProductBeneficiary(ProductBeneficiary prodbenf)
        {
            return products.AddProductBeneficiary(prodbenf);
        }


        //***********************------------------------------------------1ST CHECK-------------------------------
        bool IService1.AddUser(UserInfo user)
        {
            return products.AddUser(user);
        }
        //***********************-----------------------------------------------------------------------------------


        List<Beneficiary> IService1.GetAllBeneficiaryList()
        {
            return products.GetAllBeneficiaryList();
        }

        List<Product> IService1.GetAllProductList()
        {
            return products.GetAllProductList();
        }

        /////////--------------------------------------------------------------------------
        //ankita

        List<ProductParamJoin> IService1.CategoryWiseGetList(string Type_Id, string Lang_Id, string Cat_Id)
        {
            return products.CategoryWiseGetList(Type_Id, Lang_Id, Cat_Id);
        }


        int IService1.GetUserDetail(string Email, string Password)
        {
            return products.GetUserDetail(Email, Password);
        }


        Boolean IService1.AddInvoice(Invoice invoice)
        {
            return products.AddInvoice(invoice);

        }

        List<MyshelfProduct> IService1.GetMyShelfProduct(string userid)
        {
            return products.GetMyShelfProduct(userid);
        }






    }

    
} 
