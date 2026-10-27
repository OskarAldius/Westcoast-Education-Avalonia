using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;

namespace Client.Services;

public class StudentService : IStudentService
{
    public Task Add(Students students)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Students>> List()
    {
        throw new NotImplementedException();
    }
}
