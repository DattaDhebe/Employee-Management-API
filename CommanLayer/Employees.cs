using EmployeeRegistration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration
{
	public class Employees
	{
		public Employees()
		{
		}

		[Required]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string ContactNumber { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public decimal Salary { get; set; }

		[Required]
		public DateTime JoiningDate { get; set; }
	}
}
