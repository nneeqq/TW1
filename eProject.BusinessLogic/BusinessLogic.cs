using eProject.BusinessLogic.Interfaces;

namespace eProject.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

        public IRegister GetRegisterBL()
        {
            return new UserRegisterBL();
        }

        public IProduct GetProductsBL()
        {
            return new ProductsBL();
        }
    }
}