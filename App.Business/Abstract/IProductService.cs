﻿using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
        List<Product> GetByAtoZ(List<Product> products);
        List<Product> GetByZtoA(List<Product> products);
        List<Product> GetByPriceHtoL(List<Product> products);
        List<Product> GetByPriceLtoH(List<Product> products);

    }
}
