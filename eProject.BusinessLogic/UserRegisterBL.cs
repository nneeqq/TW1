using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eProject.BusinessLogic.Core;
using eProject.BusinessLogic.Interfaces;
using eProject.Domain.Entities.User;

namespace eProject.BusinessLogic
{
    class UserRegisterBL : UserApi, IRegister
    {
        public URegisterResp UserRegisterAction(UserDatas user)
        {
            return RegisterState(user);
        }
    }
}
