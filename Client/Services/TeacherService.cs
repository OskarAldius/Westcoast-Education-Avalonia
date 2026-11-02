using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;

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

    public async Task<List<TeacherRestDb>> Find()
    {
        var httpService = new HttpService<TeacherRestDb>();
        return await httpService.Get("teachers");
    }

    public async Task<List<Teachers>> List()
    {
        var httpService = new HttpService<Teachers>();
        var teachers = await httpService.Get("teachers");

        return teachers;
    }

    public async Task Update(Teachers teachers, string _objectId)
    {
        var httpService = new HttpService<Teachers>();
        await httpService.Put("teachers", teachers, _objectId);
    }
}
