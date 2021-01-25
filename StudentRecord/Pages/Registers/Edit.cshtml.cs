using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentRecord.Core;
using StudentRecord.Data;

namespace StudentRecord.Pages.Registers
{
    public class EditModel : PageModel
    {
        private readonly IRegisterData registerData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Register Register { get; set; }
        public IEnumerable<SelectListItem> Department { get; set; }
        public IEnumerable<SelectListItem> Year { get; set; }

        public EditModel(IRegisterData registerData, IHtmlHelper htmlHelper)
        {
            this.registerData = registerData;
            this.htmlHelper = htmlHelper;

        }
        public IActionResult OnGet(int? registerId)
        {
            Department = htmlHelper.GetEnumSelectList<Department>();
            Year = htmlHelper.GetEnumSelectList<Year>();
            if (registerId.HasValue)
            {
                Register = registerData.GetById(registerId.Value);
            }
            else
            {
                Register = new Register();
            }
            if (Register == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Department = htmlHelper.GetEnumSelectList<Department>();
                Year = htmlHelper.GetEnumSelectList<Year>();
                return Page();
            }

            if (Register.Id > 0)
            {
                registerData.Update(Register);
            }
            else
            {
                registerData.Add(Register);
            }
            registerData.Commit();
            TempData["Message"] = "Student record saved!";
            return RedirectToPage("./Detail", new { registerId = Register.Id });
        }
    }
}
