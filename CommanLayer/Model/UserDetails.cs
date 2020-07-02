//-----------------------------------------------------------------------
// <copyright file="UserDetails.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace CommanLayer
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// User Details class
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or sets of variable for user id field
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        ///  Gets or sets variable for user Name
        /// </summary>
        [Required(ErrorMessage = "Name Is Required")]
        [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "Employee Name is not valid")]
        public string Name { get; set; }

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

        /// <summary>
        ///  Gets or sets variable for Gender
        /// </summary>
        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }

        /// <summary>
        ///  Gets or sets variable for City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///  Gets or sets variable for Email
        /// </summary>
        [Required(ErrorMessage = "EmailID Is Required")]
        [RegularExpression("^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        /// <summary>
        ///  Gets or sets variable for Designation
        /// </summary>
        public string CreatedDate { get; set; }
    }
}
