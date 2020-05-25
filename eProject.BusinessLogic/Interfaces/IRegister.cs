using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eProject.Domain.Entities.User;

namespace eProject.BusinessLogic.Interfaces
{
    public interface IRegister
    {
        URegisterResp UserRegisterAction(UserDatas user);
    }
}
