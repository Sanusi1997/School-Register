using Microsoft.EntityFrameworkCore;
using StudentRecord.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRecord.Data
{
   
        public class RegisterDbContext : DbContext
        {
            public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
            {

            }
            public DbSet<Register> Register { get; set; }
        }
    }

