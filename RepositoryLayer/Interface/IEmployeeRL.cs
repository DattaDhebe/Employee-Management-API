//-----------------------------------------------------------------------
// <copyright file="IEmployeeRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace RepositoryLayer.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CommanLayer;

    /// <summary>
    /// interface for Employee Repository
    /// </summary>
    public interface IEmployeeRL
    {
        /// <summary>
        /// Method for returning All Employee Details
        /// </summary>
        /// <returns>return all employee details</returns>
        IEnumerable<Employees> GetAllemployee();

        /// <summary>
        /// Method for returning specific Employee Details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return specific employee details</returns>
        Employees GetSpecificEmployeeDetails(int id);

        /// <summary>
        ///  Method for adding new Employee
        /// </summary>
        /// <param name="info"> stores the Complete Employee information</param>
        /// <returns>return extra employee details</returns>       
        Task<bool> AddEmployeeDetails(Employees info);

        /// <summary>
        /// Method for updating previous employee details
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <param name="info">for getting updatable details</param>
        /// <returns>returns updated details</returns>
        int UpdateEmployeeDetails(int id, Employees info);

        /// <summary>
        /// Method for Deleting specific Employee Details 
        /// </summary>
        /// <param name="id">for specifying employee</param>
        /// <returns>return deleted record</returns>
        int DeleteEmployeeDetails(int id);
    }
}