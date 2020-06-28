using BusinessLayer.Interface;
using CommanLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeBusinessLayer
{
    public class EmployeeBusiness : IEmployeeBL
    {
        private IEmployeeRL _EmployeeRepository;

        public EmployeeBusiness(IEmployeeRL EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        /// <summary>
        ///  API for Registration
        /// </summary>
        /// <param name="info"> store the Complete Employee information</param>
        /// <returns></returns>
        public async Task<bool> EmployeeRegister(Employees info)
        {
            try
            {
                var Result = await _EmployeeRepository.EmployeeRegister(info);
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
    }
}