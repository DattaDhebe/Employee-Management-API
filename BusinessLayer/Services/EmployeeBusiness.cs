using BusinessLayer.Interface;
using CommanLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusiness : IEmployeeBL
    {
        private IEmployeeRL _EmployeeRepository;

        public EmployeeBusiness(IEmployeeRL EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        /// <summary>
        ///  API for get all emplyee details
        /// </summary>
        public IEnumerable<Employees> GetAllemployee()
        {
            try
            {
                return _EmployeeRepository.GetAllemployee();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employees GetSpecificEmployeeDetails(int Id)
        {
            try
            {
                return _EmployeeRepository.GetSpecificEmployeeDetails(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Registration
        /// </summary>
        /// <param name="info"> store the Complete Employee information</param>
        /// <returns></returns>
        public async Task<bool> AddEmployeeDetails(Employees info)
        {
            try
            {
                var Result = await _EmployeeRepository.AddEmployeeDetails(info);
                //if result is not equal null then return true
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int UpdateEmployeeDetails(int Id, Employees info)
        {
            try
            {
                var result = _EmployeeRepository.UpdateEmployeeDetails(Id, info);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteEmployeeDetails(int Id)
        {
            try
            {
                var result = _EmployeeRepository.DeleteEmployeeDetails(Id);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}