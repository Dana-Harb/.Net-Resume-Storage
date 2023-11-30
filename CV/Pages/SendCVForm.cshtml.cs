using CV.FileService;
using CV.Pages.Bind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using CV.Data;
using CV.CvServices;
using CV.Models;

namespace CV.Pages
{
   
    public class SendCVFormModel : PageModel
    {
        [BindProperty]
        public CVFormBinding input { get; set; }


       
        
        public int num1 { get; set; }   
        public int num2 { get; set; }

        

        private readonly ILogger<SendCVFormModel> _logger;

        private readonly IFileUploadService fileUploadService;
        private readonly CvService cv;

        public  SendCVFormModel(ILogger<SendCVFormModel> logger, IFileUploadService uploadService, CvService cv )
        {
            _logger = logger;
            this.fileUploadService = uploadService;
            this.cv = cv;
        }



        public List<SelectListItem> Items { get; set; }


        public void OnGet()
        {

            List<Nationality> nat = cv.GetNationalities();
           

                Items = new List<SelectListItem>();
            foreach (Nationality nationality in nat)
            {
                Items.Add( new SelectListItem
                {

                    Value = nationality.Id.ToString(),
                    Text = nationality.Country

                });
            }


            


            Random rnd = new Random();
            num1 = rnd.Next(1, 20);
            num2 = rnd.Next(20, 50);

            
            
        }
   

        public async Task<IActionResult> OnPost()
        {

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



            Random rnd = new Random();
            num1 = rnd.Next(1, 20);
            num2 = rnd.Next(20, 50);
            if (ModelState.IsValid)
            {
                if(input.verification != input.X + input.Y)
                {
                    ModelState.AddModelError(String.Empty, "Sum is incorrect");
                    return Page();
                }
                string filePath = await fileUploadService.UploadPhoto(input.Image); 
                PersonalInfo user = cv.createCv(input, filePath);
                return RedirectToPage("Details", new { user.Id });
            }
            return Page();
        }
    }
}
