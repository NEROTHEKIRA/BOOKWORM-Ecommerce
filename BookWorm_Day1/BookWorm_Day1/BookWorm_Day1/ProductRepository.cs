using BookWorm_Day1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookWorm_Day1.Repository
{
    public class ProductRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["BookwormConnectionString"].ToString();
            con = new SqlConnection(constr);
        }



        public bool AddProduct(Product product)
        {
            connection();
            SqlCommand com = new SqlCommand("Procedure_InserProductDetailMaster", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Prod_Title", product.Prod_Id);
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
            com.Parameters.AddWithValue("@Prod_DayOfSale", product.DayOfSale);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
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