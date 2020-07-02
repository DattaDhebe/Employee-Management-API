//-----------------------------------------------------------------------
// <copyright file="IUserBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer.Interface
{
    using System.Threading.Tasks;
    using CommanLayer;

    /// <summary>
    /// interface for User Business Layer
    /// </summary>
    public interface IUserBL
    {
        /// <summary>
        /// Method for registering new Users
        /// </summary>
        /// <param name="info">new data form user</param>
        /// <returns>added record to the database</returns>
        Task<bool> UserRegister(UserDetails info);

        /// <summary>
        /// Method for Login User
        /// </summary>
        /// <param name="info">username and password from user</param>
        /// <returns>check if User is Present return result</returns>
        Login UserLogin(Login info);
    }
}