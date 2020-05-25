using eProject.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProject.BusinessLogic.Interfaces
{
    public interface IProduct
    {
        List<string> GetProductsList();
        List<decimal> GetProductsList1();
        List<string> GetProductsList2();
        List<string> GetImageList();
        ProductsResp SetProductsList(ProductsDatas prod);
    }
}
