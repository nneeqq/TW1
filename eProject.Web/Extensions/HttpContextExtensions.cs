using System.Web;
using eProject.Domain.Entities.User;

namespace eProject.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static UserMinimal GetMySessionObject(this HttpContext current)
        {
            return (UserMinimal) current?.Session["_SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
        {
            current.Session.Add("_SessionObject", profile);
        }
    }
}