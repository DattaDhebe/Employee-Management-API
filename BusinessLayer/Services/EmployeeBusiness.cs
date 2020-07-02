//-----------------------------------------------------------------------
// <copyright file="EmployeeBusiness.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommanLayer;
    using RepositoryLayer.Interface;
    
    /// <summary>
    /// class for Employee Business
    /// </summary>
    public class EmployeeBusiness : IEmployeeBL
    {
        /// <summary>
        /// Employee instance of Employee Interface 
        /// </summary>
        private IEmployeeRL employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBusiness" /> class.
        /// </summary>
        /// <param name="employeeRepository">interface instance</param>
        public EmployeeBusiness(IEmployeeRL employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Method for returning All Employee Details
        /// </summary>
        /// <returns>return all employee details</returns>
        public IEnumerable<Employees> GetAllemployee()
        {
            try
            {
                return this.employeeRepository.GetAllemployee();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for returning specific Employee Details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return specific employee details</returns>
        public Employees GetSpecificEmployeeDetails(int id)
        {
            try
            {
                return this.employeeRepository.GetSpecificEmployeeDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  Method for adding new Employee
        /// </summary>
        /// <param name="info"> stores the Complete Employee information</param>
        /// <returns>return extra employee details</returns> 
        public async Task<bool> AddEmployeeDetails(Employees info)
        {
            try
            {
                return await this.employeeRepository.AddEmployeeDetails(info);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for updating previous employee details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <param name="info">for getting updatable details</param>
        /// <returns>returns updated details</returns>
        public int UpdateEmployeeDetails(int id, Employees info)
        {
            try
            {
                return this.employeeRepository.UpdateEmployeeDetails(id, info);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for Deleting specific Employee Details 
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return deleted record</returns>
        public int DeleteEmployeeDetails(int id)
        {
            try
            {
                return this.employeeRepository.DeleteEmployeeDetails(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}