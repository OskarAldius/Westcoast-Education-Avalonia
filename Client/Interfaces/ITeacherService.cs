using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.School;

namespace Client.Interfaces;

public interface ITeacherService
{
    Task Add(Teachers teachers);
    Task Delete(string id);
    Task<TeacherRestDb> Find(string id);
    Task<List<TeacherRestDb>> List();
    Task Update(Teachers teachers, string _objectId);
}