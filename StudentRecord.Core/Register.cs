using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentRecord.Core
{
   public class Register
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string FirstName { get; set; }
        [Required, StringLength(30)]
        public string LastName { get; set; }
        public Department Department { get; set; }
        public Year Year { get; set; }

    }
}
