using System.Data.Entity;
using eProject.Domain.Entities.User;

namespace eProject.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=CristeaDB")
        {
        }

        public virtual DbSet<UserDatas> Users { get; set; }

    }
}