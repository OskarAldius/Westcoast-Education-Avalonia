using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;

namespace Client.Services;

public class StudentService : IStudentService
{
    public async Task Add(Students students)
    {
        var httpService = new HttpService<Students>();
        await httpService.Post("students", students);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Students>();
        await httpService.Delete("students", id);
    }

    public async Task<List<Students>> List()
    {
        var httpService = new HttpService<Students>();
        var students = await httpService.Get("students");

        return students;

    }
}
