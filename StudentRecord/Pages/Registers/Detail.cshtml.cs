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
    public class DetailModel : PageModel
    {
        private readonly IRegisterData registerData;

        [TempData]
        public string Message { get; set; }
        public Register Register { get; set; }
        public DetailModel(IRegisterData registerData)
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
    }
}
