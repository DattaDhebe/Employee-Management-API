using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        IEnumerable<Employees> GetAllemployee();

        Employees GetSpecificEmployeeDetails(int Id);

        Task<bool> AddEmployeeDetails(Employees info);   
        
        int UpdateEmployeeDetails(int Id, Employees info);

        int DeleteEmployeeDetails(int Id);
    }
}