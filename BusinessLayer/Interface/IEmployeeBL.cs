using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        Task<bool> EmployeeRegister(Employees info);       
    }
}