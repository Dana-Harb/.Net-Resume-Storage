using CV.Data;

namespace CV.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DoB { get; set; }   
        public string Email { get; set; }
        public string Profile { get; set; }

        public int Grade { get; set; }
        public bool Java { get; set; }
        public bool Javascript { get; set; }
        public bool C { get; set; }
        public bool Python { get; set; }

        public Nationality Nationality { get; set; }



    }

}
