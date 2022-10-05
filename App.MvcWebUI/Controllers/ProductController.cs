using App.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page = 1, int category = 0, string order = "AtoZ")
        {
            int pageSize = 10;
            var products = String.IsNullOrEmpty(category.ToString()) ?
                            _productService.GetAll() :
                            _productService.GetByCategory(category);


            switch (order)
            {
                case "AtoZ":
                    products = _productService.GetByAtoZ(products);
                    break;
                case "ZtoA":
                    products = _productService.GetByZtoA(products);
                    break;
                case "PriceLtoH":
                    products = _productService.GetByPriceLtoH(products);
                    break;
                case "PriceHtoL":
                    products = _productService.GetByPriceHtoL(products);
                    break;
            }

            var model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
                Order = order
            };
            return View(model);
        }


    }
}
