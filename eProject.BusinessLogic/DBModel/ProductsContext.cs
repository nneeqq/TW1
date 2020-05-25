using eProject.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProject.BusinessLogic.DBModel
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("name=CristeaDB")
        {
        }

        public virtual DbSet<ProductsDatas> Products { get; set; }
    }
}
