using CommanLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        IEnumerable<Employees> GetAllemployee();

        Employees GetSpecificEmployeeDetails(int Id);

        Task<bool> AddEmployeeDetails(Employees info);

        int UpdateEmployeeDetails(int Id, Employees info);

        int DeleteEmployeeDetails(int Id);
    }
}

