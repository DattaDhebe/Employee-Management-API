using CommanLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        //Interface method for Employee Registration
        Task<bool> EmployeeRegister(Employees info);
        IEnumerable<Employees> GetAllemployee();
    }
}
