using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class UpdateBinding
    {
        [Display(Name = "your First Name : ")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "your last Name : ")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Display(Name = "your Birthay : ")]
        [Required]
        [DataType(DataType.Date)]
        public string DoB { get; set; }

        [Display(Name = "Nationality : ")]
        public int Nationality { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "Java")]
        public bool Java { get; set; }
        [Display(Name = "Javascript")]
        public bool Javascript { get; set; }

        [Display(Name = "Python")]
        public bool Python { get; set; }

        [Display(Name = "C")]
        public bool C { get; set; }

    }
}
