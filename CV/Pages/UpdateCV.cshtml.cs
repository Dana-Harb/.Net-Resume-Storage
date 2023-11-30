using CV.CvServices;
using CV.Data;
using CV.FileService;
using CV.Models;
using CV.Pages.Bind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CV.Pages
{
    public class UpdateCVModel : PageModel
    {
        private readonly CvService cv;

        [BindProperty]
        public UpdateBinding CVupdate { get; set; }

        public bool female { get; set; }
        public bool male { get; set; }


        public UpdateUserModel update { get; set; }
        private readonly IFileUploadService fileUploadService;


        public UpdateCVModel(CvService cv, IFileUploadService uploadService)
        {
            this.cv = cv;
            this.fileUploadService = uploadService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }


        public PersonalInfo user;

        public List<SelectListItem> Items { get; set; }

        public void OnGet()
        {

            user = cv.getCv(id);
            male = user.Gender == "male";
            female = user.Gender == "female";

            update = new UpdateUserModel();
            List<Nationality> nat= cv.GetNationalities();


            Items = new List<SelectListItem>();
            foreach (Nationality nationality in nat)
            {
                Items.Add(new SelectListItem
                {
                    Value = nationality.Id.ToString(),
                    Text = nationality.Country,
                    Selected = nationality.Id == user.Nationality.Id
                });
            }


            update.FirstName= user.FirstName;
            update.LastName = user.LastName;
            update.Date = user.DoB;
           
            update.Email = user.Email;
            update.Nationality = user.Nationality.Id;
            update.Image = user.Profile;
            
        }

        public async Task<IActionResult> OnPost()
        {
            user = cv.getCv(id);
            male = user.Gender == "male";
            female = user.Gender == "female";

            update = new UpdateUserModel();
            List<Nationality> nat = cv.GetNationalities();


            Items = new List<SelectListItem>();
            foreach (Nationality nationality in nat)
            {
                Items.Add(new SelectListItem
                {
                    Value = nationality.Id.ToString(),
                    Text = nationality.Country
                });
            }


            update.FirstName = user.FirstName;
            update.LastName = user.LastName;
            update.Date = user.DoB;
           
            update.Email = user.Email;
            update.Nationality = user.Nationality.Id;
            update.Image = user.Profile;
            if(ModelState.IsValid)
            {
                string filePath = await fileUploadService.UploadPhoto(CVupdate.Image);

                cv.update(id, CVupdate, filePath);
                return RedirectToPage("/CVBrowser");
            }
            return Page();
        }
    }
}
