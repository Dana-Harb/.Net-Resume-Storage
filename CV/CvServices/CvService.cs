using CV.Data;
using CV.Models;
using CV.Pages.Bind;

namespace CV.CvServices
{
    public class CvService
    {
        private readonly ApplicationDbContext _context;

        public CvService(ApplicationDbContext context)
        {
            _context = context;
        }


        public PersonalInfo createCv(CVFormBinding cv, string filepath)
        {
            
            int grade = 0;
            if(cv.Gender == "female")
                grade += 10;
            else
                grade += 5;
            
            if (cv.Java) grade += 10;
            if (cv.Javascript) grade += 10;
            if (cv.C) grade += 10;
            if (cv.Python) grade += 10;

            PersonalInfo userInfo = new PersonalInfo
            {
                FirstName= cv.FirstName,
                LastName = cv.LastName,
                DoB = cv.DoB,
                Email = cv.Email,
                Profile = filepath,
                Grade = grade,
                Gender = cv.Gender,
                Nationality = _context.Nationality.Where(n => n.Id == cv.Nationality).Select(n => n).Single(),
                C = cv.C,
                Java = cv.Java,
                Javascript = cv.Javascript,
                Python = cv.Python
            };
            _context.PersonalInfo.Add(userInfo);
            _context.SaveChanges();
            return userInfo;
        }
        
        public  List<PersonalInfo> getAll()
        {
            return _context.PersonalInfo.Select(n => new PersonalInfo
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Email = n.Email,
                Gender = n.Gender,
                Grade = n.Grade,
              


            }).ToList();

        }
        public PersonalInfo getCv( int id )
        {

            return _context.PersonalInfo.Where(n=> n.Id == id).Select(n => new PersonalInfo
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Email = n.Email,
                Gender = n.Gender,
                Grade = n.Grade,
                Python = n.Python,
                Java = n.Java,
                Javascript= n.Javascript,
                C = n.C,
                Nationality = n.Nationality,
                DoB= n.DoB,
                Profile = n.Profile
            }).Single();

        }

        public PersonalInfo update(int id,UpdateBinding cv, string file)
        {
            int grade = 0;
            if (cv.Gender == "female")
                grade += 10;
            else
                grade += 5;

            if (cv.Java) grade += 10;
            if (cv.Javascript) grade += 10;
            if (cv.C) grade += 10;
            if (cv.Python) grade += 10;

            PersonalInfo user = _context.PersonalInfo.Find(id);
            user.FirstName = cv.FirstName;
            user.LastName = cv.LastName;
            user.Email = cv.Email;
            user.DoB = cv.DoB;
            user.Profile = file;
            user.Grade = grade;
            user.Java = cv.Java;
            user.Javascript = cv.Javascript;
            user.C = cv.C;
            user.Python = cv.Python;
            user.Gender = cv.Gender;
            user.Nationality = _context.Nationality.Where(n => n.Id == cv.Nationality).Select(n => n).Single();

            _context.SaveChanges();
            return user;
        }


        public List<Nationality> GetNationalities()
        {
            return _context.Nationality.Select(n => new Nationality
            {
                Id = n.Id,
                Country = n.Country,
                

            }).ToList();
        }

        
        public void DeleteCv(int id )
        {
            PersonalInfo user = _context.PersonalInfo.Find(id);
            if(user != null)
            {
                _context.PersonalInfo.Remove(user);
                _context.SaveChanges();
            }
            
        }
    }
    
}
