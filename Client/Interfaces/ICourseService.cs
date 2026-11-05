using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface ICourseService
{
    Task Add(Courses courses);
    Task Delete(string id);
    Task<CoursesRestDb> Find(string id);
    Task<List<CoursesRestDb>> List();
    Task Update(Courses courses, string _objectId);
}
