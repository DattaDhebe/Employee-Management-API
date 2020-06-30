using System.ComponentModel.DataAnnotations;

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
	}
}
