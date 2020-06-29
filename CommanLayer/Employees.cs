using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommanLayer
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
		public string Email { get; set; }

		[Required]
		public string ContactNumber { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Salary { get; set; }

		[Required]
		public string JoiningDate { get; set; }
	}
}
