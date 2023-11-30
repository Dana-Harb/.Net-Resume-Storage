using CV.CvServices;
using CV.Models;
using CV.Pages.Bind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CV.Pages
{
    [BindProperties(SupportsGet =true)]
    public class DetailsModel : PageModel
    {
        public CVDetailsBinding CVDetail { get; set; }
        public int id { get; set; }

        private readonly CvService cv;
        public DetailsModel(CvService cv)
        {
            this .cv = cv;
        }

        public void OnGet()
        {
            PersonalInfo user = cv.getCv(id);
            CVDetail.FirstName = user.FirstName;
            CVDetail.LastName = user.LastName;
            CVDetail.Grade = user.Grade;
            CVDetail.Image = user.Profile;
            CVDetail.Email = user.Email;
            CVDetail.DoB = user.DoB;
            CVDetail.Nationality = user.Nationality;
            CVDetail.Gender = user.Gender;
            CVDetail.Java = user.Java;
            CVDetail.Javascript = user.Javascript;
            CVDetail.C = user.C;
            CVDetail.Python = user.Python;


        }
    }
}
