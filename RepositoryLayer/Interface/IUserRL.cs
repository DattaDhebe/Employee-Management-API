using CommanLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        Task<bool> UserRegister(UserDetails info);
        Task<bool> UserLogin(UserDetails info);
    }
}
