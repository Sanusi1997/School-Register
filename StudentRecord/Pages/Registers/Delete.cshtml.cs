using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRecord.Core;
using StudentRecord.Data;

namespace StudentRecord.Pages.Registers
{
    public class DeleteModel : PageModel
    {
        private readonly IRegisterData registerData;
        public Register Register { get; set; }

        public DeleteModel(IRegisterData registerData)
        {
            this.registerData = registerData;
        }
        public IActionResult OnGet(int registerId)
        {
            Register = registerData.GetById(registerId);

            if (Register == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int registerId)
        {

            var register = registerData.Delete(registerId);
            registerData.Commit();
            if (Register == null)
            {
                return RedirectToPage("./List");
            }
            TempData["Message"] = $"{register.FirstName} , {register.LastName} deleted!";
            return RedirectToPage("./List");
        }
    }
}
