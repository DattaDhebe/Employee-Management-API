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

        Task<bool> AddEmployeeDetails(Employees info);   
        
        int UpdateEmployeeDetails(int Id, Employees info);

        int DeleteEmployeeDetails(int Id, Employees info);
    }
}