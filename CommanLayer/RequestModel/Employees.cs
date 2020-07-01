//-----------------------------------------------------------------------
// <copyright file="Employees.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace CommanLayer.RequestModel
{
	using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// class for Employee Details
	/// </summary>
	public class Employees
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Employees" /> class.
		/// </summary>
		public Employees()
		{
		}

		/// <summary>
		/// Gets or sets of variable for Employee id field
		/// </summary>
		[Required]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee First Name field
		/// </summary>
		[Required]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee Last Name field
		/// </summary>
		[Required]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee Email field
		/// </summary>
		[Required]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee Contact Number field
		/// </summary>
		[Required]
		public string ContactNumber { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee City field
		/// </summary>
		[Required]
		public string City { get; set; }

		/// <summary>
		/// Gets or sets of variable for Employee Salary field
		/// </summary>
		[Required]
		public string Salary { get; set; }
	}
}