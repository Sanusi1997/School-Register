using StudentRecord.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRecord.Data
{
    public interface IRegisterData
    {
        IEnumerable<Register> GetStudentByFirstOrLastName(string name);
        Register GetById(int id);
        Register Add(Register register);
        Register Update(Register updatedRegister);
        int Commit();
        Register Delete(int id);

    }
}
