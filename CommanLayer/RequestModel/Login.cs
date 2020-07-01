//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace CommanLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// class for user login
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets variable for User Username
        /// </summary>
        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }

        /// <summary>
        ///  Gets or sets variable for User Password
        /// </summary>
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression("^.{8,15}$", ErrorMessage = "Password Length should be between 8 to 15")]
        public string Password { get; set; }
    }
}
