using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;

namespace Client.Services;

public class CourseService : ICourseService
{

    public async Task Add(Courses courses)
    {
        var httpService = new HttpService<Courses>();
        await httpService.Post("courses", courses);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Courses>();
        await httpService.Delete("courses", id);
    }
    public async Task<List<CoursesRestDb>> List()
    {
        var httpService = new HttpService<CoursesRestDb>();
        return await httpService.Get("courses");
    }

    public async Task<CoursesRestDb> Find(string id)
    {
        var httpService = new HttpService<CoursesRestDb>();
        var searchCriteria = "{\"_id\":\"" + id + "\"}";
        return await httpService.Get("courses", searchCriteria);
    }


    public async Task Update(Courses courses, string _objectId)
    {
        var httpService = new HttpService<Courses>();
        await httpService.Put("courses", courses, _objectId);
    }
}
