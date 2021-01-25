using Microsoft.EntityFrameworkCore;
using StudentRecord.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace StudentRecord.Data
{ 
       public class SQLRegisterData : IRegisterData
        {
            private readonly RegisterDbContext db;
            public SQLRegisterData(RegisterDbContext db)
            {
                this.db = db;

            }
            public int Commit()
            {
                return db.SaveChanges();
            }

            public Register Delete(int id)
            {
                var register = GetById(id);

                if (register != null)
                {

                    db.Register.Remove(register);
                }
                return register;
            }

            public Register GetById(int id)
            {
                return db.Register.Find(id);
            }

            public IEnumerable<Register> GetStudentByFirstOrLastName(string name)
            {
                var query = from r in db.Register
                            where r.FirstName.StartsWith(name) || r.LastName.StartsWith(name) || string.IsNullOrEmpty(name)
                            orderby r.Id
                            select r;
                return query;
            }

            public Register Update(Register updatedRegister)
            {
                var entity = db.Register.Attach(updatedRegister);
                entity.State = EntityState.Modified;
                return updatedRegister;
            }

            public Register Add(Register newRegister)
            {
                db.Add(newRegister);
                return newRegister;
            }
        }
    }

