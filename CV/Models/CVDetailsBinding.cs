using CV.Data;

namespace CV.Models
{
    public class CVDetailsBinding
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Image { get; set; }

        public string DoB { get; set; }
        public int Grade { get; set; }   

        public Nationality Nationality { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public bool Java { get; set; }
        public bool Javascript { get; set; }

        public bool Python { get; set; }
        public bool C { get; set; }

    }
}
