using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.School;

namespace Client.Interfaces;

public interface IStudentService
{
    Task<List<Students>> List();
    Task Add(Students students);
    Task Delete(string id);
}
