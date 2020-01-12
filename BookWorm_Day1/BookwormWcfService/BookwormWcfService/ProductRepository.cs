using BookWorm_Test_1.Pocos;
using BookwormWcfService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookwormWcfService
{
    public class ProductRepository
    {

        // THIS FUNCTION FOR SQL Connection.......
        private SqlConnection getConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection();

                string constr = ConfigurationManager.ConnectionStrings["BookwormConnectionString"].ConnectionString;
                connection.ConnectionString = constr;
                return connection;
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.StackTrace);
                return connection;
            }
        }

        public Boolean AddProduct(Product p)
        {
            int result = 0;

            SqlConnection con = getConnection();

            {

                String insertStr = "INSERT INTO ProductMaster " +
                  " (Prod_type_id, Prod_lang_id, Prod_cat_id, Prod_title, Prod_price, Prod_saleprice, Prod_specialprice, Prod_specialprice_fromdate ,"+
                  "Prod_specialprice_todate," +
                "Prod_short_desc, Prod_long_desc, Prod_author, Prod_release_date, Prod_rent,"+
                "Prod_lib, Prod_rent_amt, Prod_rent_mindays, Prod_publisher, Prod_img)" +
                "values (@typeId, @langID, @catID, @title, @price, @sell, @splPrice, @fromDate, @toDate, @shortDesc, @longDesc, @author, @releaseDate, @isRentable, @isInLib, @rentAmount, @minRentDays, @publisher, @imagePath)";

                SqlCommand cmd = new SqlCommand(insertStr, con);

                cmd.Parameters.AddWithValue("@typeId", p.Type_Id);
                cmd.Parameters.AddWithValue("@langID", p.Lang_Id);
                cmd.Parameters.AddWithValue("@catID", p.Cat_Id);
                cmd.Parameters.AddWithValue("@title", p.Prod_title);
                cmd.Parameters.AddWithValue("@price", p.Prod_price);
                cmd.Parameters.AddWithValue("@sell", p.Prod_saleprice);
                cmd.Parameters.AddWithValue("@splPrice", p.Prod_specialprice);
                cmd.Parameters.AddWithValue("@fromDate", DateTime.Parse(p.Prod_specialprice_fromdate));
                cmd.Parameters.AddWithValue("@toDate", DateTime.Parse(p.Prod_specialprice_todate));
                cmd.Parameters.AddWithValue("@shortDesc", p.Prod_short_desc);
                cmd.Parameters.AddWithValue("@longDesc", p.Prod_long_desc);
                cmd.Parameters.AddWithValue("@author", p.Prod_author);
                cmd.Parameters.AddWithValue("@releaseDate", DateTime.Parse(p.Prod_release_date));
                cmd.Parameters.AddWithValue("@isRentable", p.Prod_rent);
                cmd.Parameters.AddWithValue("@isInLib", p.Prod_lib);
                cmd.Parameters.AddWithValue("@rentAmount", p.Prod_rent_amt);
                cmd.Parameters.AddWithValue("@minRentDays", p.Prod_rent_mindays);
                cmd.Parameters.AddWithValue("@publisher", p.Prod_publisher);
                cmd.Parameters.AddWithValue("@imagePath", p.Prod_img);

                try
                {

                    con.Open();

                    result = cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException se)
                {
                    Console.Write(se.Message);
                }
            }

            return result > 0 ? true : false;
        }
        /*
        public Boolean AddProduct(Product product)
        {
            int i = 0;
            SqlConnection con = null;
            try
            {
                con = getConnection();
                SqlCommand com = new SqlCommand("Procedure_InserProductDetailMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Prod_Title", product.Prod_title);
                com.Parameters.AddWithValue("@Prod_price", product.Prod_price);
                com.Parameters.AddWithValue("@Prod_saleprice", product.Prod_saleprice);
                com.Parameters.AddWithValue("@Prod_specialprice", product.Prod_specialprice);
                com.Parameters.AddWithValue("@Prod_specialprice_fromdate  ", product.Prod_specialprice_fromdate);
                com.Parameters.AddWithValue("@Prod_specialprice_todate", product.Prod_specialprice_todate);
                com.Parameters.AddWithValue("@Prod_short_desc ", product.Prod_short_desc);
                com.Parameters.AddWithValue("@Prod_long_desc ", product.Prod_long_desc);
                com.Parameters.AddWithValue("@Prod_author", product.Prod_author);
                com.Parameters.AddWithValue("@Prod_img ", product.Prod_img);
                com.Parameters.AddWithValue("@Prod_release_date", product.Prod_release_date);
                com.Parameters.AddWithValue("@Prod_rent ", product.Prod_rent);
                com.Parameters.AddWithValue("@Prod_lib", product.Prod_lib);
                com.Parameters.AddWithValue("@Prod_rent_amt", product.Prod_rent_amt);
                com.Parameters.AddWithValue("@Prod_rent_mindays", product.Prod_rent_mindays);
                com.Parameters.AddWithValue("@Prod_publisher ", product.Prod_publisher);
               // com.Parameters.AddWithValue("@Prod_DayOfSale", product.DayOfSale);
                con.Open();
                i = com.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Hello..........");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.StackTrace);
                return false;
            }
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         * */


        public  List<Language> GetAllLanguageList()
        {
            List<Language> allLanguages = new List<Language>();

            SqlConnection con =   getConnection();
            {
                String selectAllStr = "Select * from Language";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Language language = new Language();
                    language.Lang_Id = Convert.ToInt32(reader["Lang_Id"]);
                    language.Lang_desc = Convert.ToString(reader["Lang_desc"]);
                    allLanguages.Add(language);
                }
            }

            return allLanguages;
        }



        public List<TypePoco> GetAllTypeList()
        {
            List<TypePoco> allTypes = new List<TypePoco>();
                
                SqlConnection con = null;
            {
                String selectAllStr = "SELECT * FROM  Type";
                con = getConnection();
                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TypePoco p = new TypePoco();
                    p.Type_Id = Convert.ToInt32(reader["Type_Id"]);
                    p.Type_desc = Convert.ToString(reader["Type_desc"]);
                    allTypes.Add(p);
                }
            }

            return allTypes;
        }




        public List<Category> GetAllCategoryList()
        {
            List<Category> allCategories = new List<Category>();

            SqlConnection con = null;
            {

                con = getConnection();

                String selectAllStr = "SELECT * FROM Category";

                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category p = new Category();
                    p.Cat_Id = Convert.ToInt32(reader["Cat_Id"]);
                    p.Cat_desc = Convert.ToString(reader["Cat_desc"]);
                    allCategories.Add(p);
                }
            }

            return allCategories;
        }




        /*
        public List<Product> CategoryWiseGetList(string Type_Id, string Lang_Id, string Cat_Id)
        {
            List<Product> templist = new List<Product>();

            SqlConnection sqlconnection = getConnection();
            sqlconnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from ProductMaster where  Prod_type_id=@PQType_Id   AND  Prod_lang_id=@PQLang_Id AND Prod_cat_id=@PQCat_Id   ", sqlconnection);


            cmd.Parameters.AddWithValue("@PQType_Id", SqlDbType.Int).Value = Convert.ToInt16(Type_Id);
            cmd.Parameters.AddWithValue("@PQLang_Id", SqlDbType.Int).Value = Convert.ToInt16(Lang_Id);
            cmd.Parameters.AddWithValue("@PQCat_Id", SqlDbType.Int).Value = Convert.ToInt16(Cat_Id);

            SqlDataReader rd = cmd.ExecuteReader();
           // List<ProductMaster> list = new List<ProductMaster>();
            while (rd.Read())
            {
                Product pro = new Product();
                pro.ProductMaster_Prod_Id = Convert.ToInt32(rd["ProductMaster_Prod_Id"]);
                pro.Prod_title = rd["Prod_title"].ToString();
              
                pro.Prod_price = Convert.ToSingle(rd["Prod_price"]);
                pro.Type_Id = Convert.ToInt32(rd["Prod_type_id"]);
                pro.Cat_Id = Convert.ToInt32(rd["Prod_cat_id"]);
                pro.Lang_Id = Convert.ToInt32(rd["Prod_lang_id"]);
                pro.Prod_saleprice = Convert.ToSingle(rd["Prod_saleprice"]);
                pro.Prod_specialprice = Convert.ToSingle(rd["Prod_specialprice"]);         
                pro.Prod_specialprice_fromdate = (rd["Prod_specialprice_fromdate"]).ToString();
                pro.Prod_specialprice_todate = (rd["Prod_specialprice_todate"]).ToString();
                pro.Prod_short_desc = rd["Prod_short_desc"].ToString();
                pro.Prod_long_desc = rd["Prod_long_desc"].ToString();
                pro.Prod_author = rd["Prod_author"].ToString();
                pro.Prod_img = rd["Prod_img"].ToString();
                pro.Prod_release_date = rd["Prod_release_date"].ToString();
                pro.Prod_rent = Convert.ToBoolean(rd["Prod_rent"]);
                pro.Prod_lib = Convert.ToBoolean(rd["Prod_lib"]);
                pro.Prod_rent_amt = Convert.ToSingle(rd["Prod_rent_amt"]);
                pro.Prod_rent_mindays = Convert.ToInt32(rd["Prod_rent_mindays"]);
                pro.Prod_publisher = (rd["Prod_publisher"]).ToString();

                templist.Add(pro);
            }
            //Console.WriteLine(templist.ToString());
          //  return list;





            return templist;
        }*/



        public Boolean AddUser(UserInfo userdetails)
        {

            int result = 0;
            SqlConnection con = getConnection();
            {
                
                try
                {
                    string QUERY = "INSERT INTO UserInfo(Name,Password,Email,House_no,Street,City,Pincode,Landmark,Date_of_birth) VALUES (@nm,@pssd,@eml,@hsn,@strt,@ct,@pncd,@lndmrk,@Dtfbrth)";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QUERY, con);
                    cmd.Parameters.AddWithValue("@nm", userdetails.Name);
                    cmd.Parameters.AddWithValue("@pssd", userdetails.Password);
                    cmd.Parameters.AddWithValue("@eml", userdetails.Email);
                    cmd.Parameters.AddWithValue("@hsn", userdetails.House_no);
                    cmd.Parameters.AddWithValue("@strt", userdetails.Street);
                    cmd.Parameters.AddWithValue("@ct", userdetails.City);
                    cmd.Parameters.AddWithValue("@pncd", userdetails.Pincode);
                    cmd.Parameters.AddWithValue("@lndmrk", userdetails.Landmark);
                    cmd.Parameters.AddWithValue("@Dtfbrth", userdetails.Date_of_birth);
                     result = cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException se)
                {
                    Console.Write(se.Message);
                }
            }
            return result > 0 ? true : false;
        }


        public List<Product> GetBookList()
        {
             List<Product> templist = new List<Product>();

            SqlConnection sqlconnection = getConnection();
            sqlconnection.Open();
           
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTMASTER", sqlconnection);
            
            //cmd.Parameters.AddWithValue("@PQType_Id", SqlDbType.Int).Value = Convert.ToInt16(Type_Id);
            ///cmd.Parameters.AddWithValue("@PQLang_Id", SqlDbType.Int).Value = Convert.ToInt16(Lang_Id);
           // cmd.Parameters.AddWithValue("@PQCat_Id", SqlDbType.Int).Value = Convert.ToInt16(Cat_Id);

            SqlDataReader rd = cmd.ExecuteReader();
           // List<ProductMaster> list = new List<ProductMaster>();
            while (rd.Read())
            {
                Product pro = new Product();
                //pro.ProductMaster_Prod_Id = Convert.ToInt32(rd["ProductMaster_Prod_Id"]);        
              //  pro.Prod_title = rd["Prod_title"].ToString();         
               // pro.Prod_price = Convert.ToSingle(rd["Prod_price"]);
               // pro.Type_Id = Convert.ToInt32(rd["Prod_type_id"]);
               // pro.Cat_Id = Convert.ToInt32(rd["Prod_cat_id"]);
               // pro.Lang_Id = Convert.ToInt32(rd["Prod_lang_id"]);
              //  pro.Prod_saleprice = Convert.ToSingle(rd["Prod_saleprice"]);
              //  pro.Prod_specialprice = Convert.ToSingle(rd["Prod_specialprice"]);         
              //  pro.Prod_specialprice_fromdate = (rd["Prod_specialprice_fromdate"]).ToString();
              //  pro.Prod_specialprice_todate = (rd["Prod_specialprice_todate"]).ToString();
                pro.Prod_title = rd["Prod_title"].ToString();  
                pro.Prod_short_desc = rd["Prod_short_desc"].ToString();
                pro.Prod_long_desc = rd["Prod_long_desc"].ToString();
              //  pro.Prod_author = rd["Prod_author"].ToString();
                pro.Prod_img = rd["Prod_img"].ToString();
               pro.Prod_release_date = rd["Prod_release_date"].ToString();
             //   pro.Prod_rent = Convert.ToBoolean(rd["Prod_rent"]);
             //   pro.Prod_lib = Convert.ToBoolean(rd["Prod_lib"]);
            //    pro.Prod_rent_amt = Convert.ToSingle(rd["Prod_rent_amt"]);
            //    pro.Prod_rent_mindays = Convert.ToInt32(rd["Prod_rent_mindays"]);
             //   pro.Prod_publisher = (rd["Prod_publisher"]).ToString();

                templist.Add(pro);
            }
            return templist;
        }



        //akshta------------------------------------------------------------------------------------------------------------
        public Boolean AddBeneficiary(Beneficiary benf)
        {
            int result = 0;
            SqlConnection con = getConnection();
            {

                try
                {
                    string QUERY = "INSERT INTO Beneficiary(Benf_name,Benf_acc_no,Benf_contact_no,Benf_email_id) VALUES (@Benf_name,@Benf_acc_no,@Benf_contact_no,@Benf_email_id)";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QUERY, con);
                    cmd.Parameters.AddWithValue("@Benf_name", benf.Benf_name);
                    cmd.Parameters.AddWithValue("@Benf_acc_no", benf.Benf_acc_no);
                    cmd.Parameters.AddWithValue("@Benf_contact_no", benf.Benf_contact_no);
                    cmd.Parameters.AddWithValue("@Benf_email_id", benf.Benf_email_id);

                    result = cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException se)
                {
                    Console.Write(se.Message);
                }
            }
            return result > 0 ? true : false;
        }

        public Boolean AddProductBeneficiary(ProductBeneficiary prodbenf)
        {
            int result = 0;
            SqlConnection con = getConnection();
            {

                try
                {
                    string QUERY = "INSERT INTO ProductBeneficiary(Prod_Id,Benf_Id,Royalty_perc) VALUES (@Prod_Id,@Benf_Id,@Royalty_perc)";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(QUERY, con);
                    cmd.Parameters.AddWithValue("@Prod_Id", prodbenf.Prod_Id);
                    cmd.Parameters.AddWithValue("@Benf_Id", prodbenf.Benf_Id);
                    cmd.Parameters.AddWithValue("@Royalty_perc", prodbenf.Royalty_perc);


                    result = cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (SqlException se)
                {
                    Console.Write(se.Message);
                }
            }
            return result > 0 ? true : false;
        }

        public List<Beneficiary> GetAllBeneficiaryList()
        {
            List<Beneficiary> allTypes = new List<Beneficiary>();

            SqlConnection con = null;
            {
                String selectAllStr = "SELECT * FROM  Beneficiary";
                con = getConnection();
                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Beneficiary p = new Beneficiary();
                    p.Benf_Id = Convert.ToInt32(reader["Benf_Id"]);
                    //  p.Type_desc = Convert.ToString(reader["Type_desc"]);
                    allTypes.Add(p);
                }
            }

            return allTypes;
        }

        public List<Product> GetAllProductList()
        {
            List<Product> allTypes = new List<Product>();

            SqlConnection con = null;
            {
                String selectAllStr = "SELECT * FROM  ProductMaster";
                con = getConnection();
                SqlCommand cmd = new SqlCommand(selectAllStr, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductMaster_Prod_Id = Convert.ToInt32(reader["ProductMaster_Prod_Id"]);
                    //  p.Type_desc = Convert.ToString(reader["Type_desc"]);
                    allTypes.Add(p);
                }
            }

            return allTypes;
        }

        //*****************************************************************************************------------------------
       //---------------------ankita


        public List<MyshelfProduct> GetMyShelfProduct(string userid)
        {

            List<MyshelfProduct> tempList = new List<MyshelfProduct>();

            SqlConnection con = getConnection();

            //     String selectAllStr = "Select * from Language";


            String QUERY = "SELECT Myshelf.Shelf_user_id,Myshelf.Shelf_prod_id,ProductMaster.Prod_img " +
",ProductMaster.Prod_short_desc,ProductMaster.pROD_TITLE , ProductMaster.Prod_long_desc FROM " +
"Myshelf,ProductMaster,UserInfo WHERE UserInfo.User_Id=Myshelf.Shelf_user_id AND " +
"Myshelf.Shelf_prod_id=ProductMaster.ProductMaster_Prod_Id and Myshelf.Shelf_user_id=@PARAM;";


            SqlCommand cmd = new SqlCommand(QUERY, con);
            cmd.Parameters.AddWithValue("@PARAM", userid);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MyshelfProduct tempMyshelfProduct = new MyshelfProduct();

                tempMyshelfProduct.Shelf_user_id = Convert.ToInt32(reader["Shelf_user_id"]);
                tempMyshelfProduct.Shelf_prod_id = Convert.ToInt32(reader["Shelf_prod_id"]);
                tempMyshelfProduct.Prod_img = reader["Prod_img"].ToString().Trim();
                tempMyshelfProduct.Prod_short_desc = reader["Prod_short_desc"].ToString().Trim();
                tempMyshelfProduct.Prod_long_desc = reader["Prod_long_desc"].ToString().Trim();
                tempMyshelfProduct.Prod_title = reader["Prod_title"].ToString().Trim();


                //  language.Lang_Id = Convert.ToInt32(reader["Lang_Id"]);
                // language.Lang_desc = Convert.ToString(reader["Lang_desc"]);
                tempList.Add(tempMyshelfProduct);
            }


            return tempList;

        }




        public List<ProductParamJoin> CategoryWiseGetList(string Type_Id, string Lang_Id, string Cat_Id)
        {
            List<ProductParamJoin> templist = new List<ProductParamJoin>();

            SqlConnection sqlconnection = getConnection();
            SqlDataReader rd = null;

            sqlconnection.Open();
            if (Lang_Id == "undefined" && Cat_Id == "undefined")
            {
                SqlCommand cmd = new SqlCommand("Select ProductMaster.ProductMaster_Prod_Id,ProductMaster.Prod_type_id,ProductMaster.Prod_lang_id,ProductMaster.Prod_cat_id,ProductMaster.Prod_title,ProductMaster.Prod_price,ProductMaster.Prod_saleprice,ProductMaster.Prod_specialprice,ProductMaster.Prod_specialprice_fromdate,ProductMaster.Prod_specialprice_todate,ProductMaster.Prod_short_desc,ProductMaster.Prod_long_desc,ProductMaster.Prod_author,ProductMaster.Prod_img,ProductMaster.Prod_release_date,ProductMaster.Prod_rent,ProductMaster.Prod_lib,ProductMaster.Prod_rent_amt,ProductMaster.Prod_rent_mindays,ProductMaster.Prod_publisher,Param.Param_Id,Param.Param_desc,ParamProduct.Param_Param_Id,ParamProduct.Param_Product_Id,ParamProduct.Param_Value,ParamProduct.Prod_Id from ProductMaster,ParamProduct,Param where Param.Param_Id = ParamProduct.Param_Param_Id and ParamProduct.Prod_Id = ProductMaster.ProductMaster_Prod_Id and ProductMaster.Prod_type_id= @Type_Id", sqlconnection);
                //"Select * from ProductMaster where  Prod_type_id=@PQType_Id   AND  Prod_lang_id=@PQLang_Id AND Prod_cat_id=@PQCat_Id   ",

                cmd.Parameters.AddWithValue("@Type_Id", SqlDbType.Int).Value = Convert.ToInt16(Type_Id);
                //cmd.Parameters.AddWithValue("@Lang_Id", SqlDbType.Int).Value = Convert.ToInt16(Lang_Id);
                // cmd.Parameters.AddWithValue("@Cat_Id", SqlDbType.Int).Value = Convert.ToInt16(Cat_Id);
                rd = cmd.ExecuteReader();
            }

            else if (Type_Id != "undefined" && Lang_Id != "undefined" && Cat_Id == "undefined")
            {
                SqlCommand cmd = new SqlCommand("Select ProductMaster.ProductMaster_Prod_Id,ProductMaster.Prod_type_id,ProductMaster.Prod_lang_id,ProductMaster.Prod_cat_id,ProductMaster.Prod_title,ProductMaster.Prod_price,ProductMaster.Prod_saleprice,ProductMaster.Prod_specialprice,ProductMaster.Prod_specialprice_fromdate,ProductMaster.Prod_specialprice_todate,ProductMaster.Prod_short_desc,ProductMaster.Prod_long_desc,ProductMaster.Prod_author,ProductMaster.Prod_img,ProductMaster.Prod_release_date,ProductMaster.Prod_rent,ProductMaster.Prod_lib,ProductMaster.Prod_rent_amt,ProductMaster.Prod_rent_mindays,ProductMaster.Prod_publisher,Param.Param_Id,Param.Param_desc,ParamProduct.Param_Param_Id,ParamProduct.Param_Product_Id,ParamProduct.Param_Value,ParamProduct.Prod_Id from ProductMaster,ParamProduct,Param where Param.Param_Id = ParamProduct.Param_Param_Id and ParamProduct.Prod_Id = ProductMaster.ProductMaster_Prod_Id and ProductMaster.Prod_type_id= @Type_Id and ProductMaster.Prod_lang_id=@Lang_Id", sqlconnection);
                //"Select * from ProductMaster where  Prod_type_id=@PQType_Id   AND  Prod_lang_id=@PQLang_Id AND Prod_cat_id=@PQCat_Id   ",

                cmd.Parameters.AddWithValue("@Type_Id", SqlDbType.Int).Value = Convert.ToInt16(Type_Id);
                cmd.Parameters.AddWithValue("@Lang_Id", SqlDbType.Int).Value = Convert.ToInt16(Lang_Id);
                // cmd.Parameters.AddWithValue("@Cat_Id", SqlDbType.Int).Value = Convert.ToInt16(Cat_Id);
                rd = cmd.ExecuteReader();
            }

            else if (Type_Id != "undefined" && Lang_Id != "undefined" && Cat_Id != "undefined")
            {
                SqlCommand cmd = new SqlCommand("Select ProductMaster.ProductMaster_Prod_Id,ProductMaster.Prod_type_id,ProductMaster.Prod_lang_id,ProductMaster.Prod_cat_id,ProductMaster.Prod_title,ProductMaster.Prod_price,ProductMaster.Prod_saleprice,ProductMaster.Prod_specialprice,ProductMaster.Prod_specialprice_fromdate,ProductMaster.Prod_specialprice_todate,ProductMaster.Prod_short_desc,ProductMaster.Prod_long_desc,ProductMaster.Prod_author,ProductMaster.Prod_img,ProductMaster.Prod_release_date,ProductMaster.Prod_rent,ProductMaster.Prod_lib,ProductMaster.Prod_rent_amt,ProductMaster.Prod_rent_mindays,ProductMaster.Prod_publisher,Param.Param_Id,Param.Param_desc,ParamProduct.Param_Param_Id,ParamProduct.Param_Product_Id,ParamProduct.Param_Value,ParamProduct.Prod_Id from ProductMaster,ParamProduct,Param where Param.Param_Id = ParamProduct.Param_Param_Id and ParamProduct.Prod_Id = ProductMaster.ProductMaster_Prod_Id and ProductMaster.Prod_type_id= @Type_Id and ProductMaster.Prod_lang_id=@Lang_Id and ProductMaster.Prod_cat_id=@Cat_Id", sqlconnection);
                //"Select * from ProductMaster where  Prod_type_id=@PQType_Id   AND  Prod_lang_id=@PQLang_Id AND Prod_cat_id=@PQCat_Id   ",

                cmd.Parameters.AddWithValue("@Type_Id", SqlDbType.Int).Value = Convert.ToInt16(Type_Id);
                cmd.Parameters.AddWithValue("@Lang_Id", SqlDbType.Int).Value = Convert.ToInt16(Lang_Id);
                cmd.Parameters.AddWithValue("@Cat_Id", SqlDbType.Int).Value = Convert.ToInt16(Cat_Id);
                rd = cmd.ExecuteReader();
            }


            // List<ProductMaster> list = new List<ProductMaster>();
            while (rd.Read())
            {
                ProductParamJoin pro = new ProductParamJoin();
                pro.p = new Product();
                pro.param = new Param();
                pro.paramProduct = new ParamProduct();

                pro.p.ProductMaster_Prod_Id = Convert.ToInt32(rd["ProductMaster_Prod_Id"]);
                pro.p.Prod_title = rd["Prod_title"].ToString();

                pro.p.Prod_price = Convert.ToSingle(rd["Prod_price"]);
                pro.p.Type_Id = Convert.ToInt32(rd["Prod_type_id"]);
                pro.p.Cat_Id = Convert.ToInt32(rd["Prod_cat_id"]);
                pro.p.Lang_Id = Convert.ToInt32(rd["Prod_lang_id"]);
                pro.p.Prod_saleprice = Convert.ToSingle(rd["Prod_saleprice"]);
                pro.p.Prod_specialprice = Convert.ToSingle(rd["Prod_specialprice"]);
                pro.p.Prod_specialprice_fromdate = (rd["Prod_specialprice_fromdate"]).ToString();
                pro.p.Prod_specialprice_todate = (rd["Prod_specialprice_todate"]).ToString();
                pro.p.Prod_short_desc = rd["Prod_short_desc"].ToString();
                pro.p.Prod_long_desc = rd["Prod_long_desc"].ToString();
                pro.p.Prod_author = rd["Prod_author"].ToString();
                pro.p.Prod_img = rd["Prod_img"].ToString();
                pro.p.Prod_release_date = rd["Prod_release_date"].ToString();
             //   pro.p.Prod_rent = Convert.ToInt16(rd["Prod_rent"]);
               
              //  pro.p.Prod_lib = Convert.ToInt16(rd["Prod_lib"]);


                pro.p.Prod_rent = Convert.ToBoolean(rd["Prod_rent"]);
                pro.p.Prod_lib = Convert.ToBoolean(rd["Prod_lib"]);        
                pro.p.Prod_rent_amt = Convert.ToSingle(rd["Prod_rent_amt"]);
                pro.p.Prod_rent_mindays = Convert.ToInt32(rd["Prod_rent_mindays"]);
                pro.p.Prod_publisher = (rd["Prod_publisher"]).ToString();
               pro.param.Param_Id = Convert.ToInt32(rd["Param_Id"]);
                pro.param.Param_desc = (rd["Param_desc"]).ToString();
                pro.paramProduct.Param_Param_Id = Convert.ToInt32(rd["Param_Param_Id"]);
                pro.paramProduct.Param_Product_Id = Convert.ToInt32(rd["Param_Product_Id"]);
                pro.paramProduct.Param_Param_Id = Convert.ToInt32(rd["Param_Param_Id"]);
                pro.paramProduct.Param_Value = (rd["Param_Value"]).ToString();

                templist.Add(pro);
            }
            //Console.WriteLine(templist.ToString());
            //  return list;





            return templist;
        }


        public Int32 GetUserDetail(string Email, string Password)
        {
            int i = 0;
            //List<UserInfo> list = new List<UserInfo>();
            SqlConnection sqlconnection = getConnection();
            sqlconnection.Open();
            SqlCommand cmd = new SqlCommand("select User_Id from UserInfo where Email Like @Email and Password Like @Password", sqlconnection);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);

            UserInfo u = new UserInfo();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    i = Convert.ToInt32(rd["User_Id"]);
                }
            }

            /* while (rd.Read())
             {
                 u.Name = (rd["Name"]).ToString();
                 u.Password = (rd["Password"]).ToString();
                 u.Email = (rd["Email"]).ToString();
                 u.House_no = Convert.ToInt32(rd["House_no"]);
                 u.Street = (rd["Street"]).ToString();
                 u.City = (rd["City"]).ToString();
                 u.Pincode = Convert.ToInt32(rd["Pincode"]);
                 u.Landmark = (rd["Landmark"]).ToString();
                 u.Date_of_birth = (rd["Date_of_birth"]).ToString();
             }
             list.Add(u);*/

            Console.Write(i);

            if (i > 0)
            {
                return i;
            }
            else
            {
                return 0;
            }

        }


        public Boolean AddInvoice(Invoice invoice)
        {
            int i = 0;
            SqlConnection con = null;
            try
            {
                con = getConnection();
                SqlCommand com = new SqlCommand("insert into Invoice values(@PRProd_id,@PRProd_price,@PRUser_Id)", con);
                //com.Parameters.AddWithValue("@PRInvoice_Id", SqlDbType.Int).Value = Invoice_Id;
                com.Parameters.AddWithValue("@PRProd_id", invoice.ProductMaster_Prod_Id);
                com.Parameters.AddWithValue("@PRProd_price", invoice.Prod_saleprice);
                com.Parameters.AddWithValue("@PRUser_Id", invoice.UserId);
                con.Open();
                i = com.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                return false;
            }
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}