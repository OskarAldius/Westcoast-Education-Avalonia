using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class TeacherService : ITeacherService
{
    public async Task Add(Teachers teachers)
    {
        var httpService = new HttpService<Teachers>();
        await httpService.Post("teachers", teachers);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Teachers>();
        await httpService.Delete("teachers", id);
    }
    public async Task<List<TeacherRestDb>> List()
    {
        var httpService = new HttpService<TeacherRestDb>();
        return await httpService.Get("teachers");
    }

    public async Task<TeacherRestDb> Find(string id)
    {
        var httpService = new HttpService<TeacherRestDb>();
        var searchCriteria = "{\"_id\":\"" + id + "\"}";
        return await httpService.Get("teachers", searchCriteria);
    }


    public async Task Update(Teachers teachers, string _objectId)
    {
        var httpService = new HttpService<Teachers>();
        await httpService.Put("teachers", teachers, _objectId);
    }
}
