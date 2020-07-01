//-----------------------------------------------------------------------
// <copyright file="UserBusiness.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommanLayer;
    using RepositoryLayer.Interface;

    /// <summary>
    /// class for User Business
    /// </summary>
    public class UserBusiness : IUserBL
    {
        /// <summary>
        /// Employee instance of User Interface 
        /// </summary>
        private readonly IUserRL userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBusiness" /> class.
        /// </summary>
        /// <param name="userRepository">interface instance</param>
        public UserBusiness(IUserRL userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Method for registering new Users
        /// </summary>
        /// <param name="info">new data form user</param>
        /// <returns>added record to the database</returns>
        public async Task<bool> UserRegister(UserDetails info)
        {
            try
            {
                var result = await this.userRepository.UserRegister(info);

                // if result is not equal null then return true
                if (!result.Equals(null))
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
        /// Method for Login User
        /// </summary>
        /// <param name="info">username and password from user</param>
        /// <returns>check if User is Present return result</returns>
        public async Task<int> UserLogin(Login info)
        {
            try
            {
                int result = await this.userRepository.UserLogin(info);

                // if result is not equal null then return true
                if (result != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
