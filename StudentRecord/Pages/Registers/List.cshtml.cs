using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StudentRecord.Data;
using StudentRecord.Core;

namespace StudentRecord.Pages.Registers
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRegisterData registerData;
        public string Message {get; set;}
        public IEnumerable<Register> Registers { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRegisterData registerData)
        {
            this.config = config;
            this.registerData = registerData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Registers = registerData.GetStudentByFirstOrLastName(SearchTerm);
        }
    }
}
