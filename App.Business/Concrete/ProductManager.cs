using App.Business.Abstract;
using App.DataAccess.Abstract;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId==0);
        }

        public List<Product> GetByAtoZ(List<Product> products)
        {
            return products.OrderBy(p => p.ProductName).ToList();
        }

        public List<Product> GetByZtoA(List<Product> products)
        {
            return products.OrderByDescending(p => p.ProductName).ToList();
        }

        public List<Product> GetByPriceHtoL(List<Product> products)
        {
            return products.OrderByDescending(p => p.UnitPrice).ToList();
        }

        public List<Product> GetByPriceLtoH(List<Product> products)
        {
            return products.OrderBy(p => p.UnitPrice).ToList();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

    }
}
