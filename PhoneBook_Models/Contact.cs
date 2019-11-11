using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Models
{
	public class Contact
	{
		public int Id { get; set; }
		[Display(Name = "First name"), Required(ErrorMessage = "First name is required")]
		public string FirstName { get; set; }
		[Display(Name = "Last name"), Required(ErrorMessage = "Last name is required")]
		public string LastName { get; set; }
	}
}
