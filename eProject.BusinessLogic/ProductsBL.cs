using eProject.BusinessLogic.Core;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProject.BusinessLogic
{
    public class ProductsBL : UserApi, IProduct
    {
        public List<string> GetProductsList()
        {
            return ProductListLogic();
        }

        public List<decimal> GetProductsList1()
        {
            return ProductListLogic1();
        }

        public List<string> GetProductsList2()
        {
            return ProductListLogic2();
        }

        public List<string> GetImageList()
        {
            return ImageListLogicURL();
        }

        public ProductsResp SetProductsList(ProductsDatas prod)
        {
            return AddProducts(prod);
        }
    }
}
