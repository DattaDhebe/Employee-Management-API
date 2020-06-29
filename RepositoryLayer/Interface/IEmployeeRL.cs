using CommanLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        IEnumerable<Employees> GetAllemployee();

        Task<bool> AddEmployeeDetails(Employees info);

        int UpdateEmployeeDetails(int ID, Employees info);

        int DeleteEmployeeDetails(int ID, Employees info);
    }
}

