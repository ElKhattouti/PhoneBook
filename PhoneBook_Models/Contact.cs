using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook_Models
{
    [Table("contact")]
    public class Contact
	{
        [Key]
        [Column("contact_id")]
        public int ContactId { get; set; }
		[Display(Name = "First name"), Required(ErrorMessage = "First name is required")]
        [Column("first_name")]
        public string FirstName { get; set; }
		[Display(Name = "Last name"), Required(ErrorMessage = "Last name is required")]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("telephone_number")]
        [Display(Name = "Telephone number"), Required(ErrorMessage = "Telephone number is required")]
        [RegularExpression("^([+][0-9]+) [0-9]+ [0-9]{6,}$", ErrorMessage = "Telephone number is invalid")]
        public string TelephoneNumber { get; set; }
    }
}