using CV.CvServices;
using CV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace CV.Pages
{
    public class CVBrowserModel : PageModel
    {
        public List<PersonalInfo> all;
        private readonly CvService cv;

        [BindProperty]
        [HiddenInput]
        public int id { get; set; }
        public CVBrowserModel( CvService cv)
        {
            this.cv = cv;
        }
        public void OnGet()
        {
            all = cv.getAll();
        }

        public IActionResult OnPost()
        {
            cv.DeleteCv(id);
            return RedirectToPage("CVBrowser");

        }

       
    }
}
