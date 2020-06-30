using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        Task<bool> UserRegister(UserDetails info);
        Task<int> UserLogin(Login info);
    }
}