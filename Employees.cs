using EmployeeRegistration.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
	public class Employees
	{
		public Employees()
		{
		}

		[Required]
		public int EmployeeId { get; set; }

		[Required]
		public string EmployeeName { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public decimal Salary { get; set; }

		[Required]
		public DateTime AddedOn { get; set; }
	}
}
