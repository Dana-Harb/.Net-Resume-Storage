using System.ComponentModel.DataAnnotations;

namespace CV.Models
{
    public class UpdateUserModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Nationality { get; set; }
        public string Gender { get; set; }
        public int Grade { get; set; }
        public string Email { get; set; }
        
        public string Image { get; set; }

        public string Date { get; set; }
        public string DoB { get; set; }
        public bool Java { get; set; }
        public bool Javascript { get; set; }
        public bool C { get; set; }
        public bool Python { get; set; }



    }
}
