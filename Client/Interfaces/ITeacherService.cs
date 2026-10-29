using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.School;

namespace Client.Interfaces;

public interface ITeacherService
{
    Task Add(Teachers teachers);
    Task Delete(string id);
    Task<TeacherRestDb> Find(string fieldOfKnowledge);
    Task<List<Teachers>> List();
    Task Update(Teachers teachers, string _objectId);
}
