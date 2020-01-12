using BookWorm_Day1.Models;
using BookWorm_Day1.Repository;
//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace BookWorm_Day1
{
    public class ProductServiceImplementaion : ProductService
    {

        ProductRepository products = new ProductRepository();


        bool ProductService.AddProduct(Product product)
        {
            return products.AddProduct(product);
        }
       
    }
}
