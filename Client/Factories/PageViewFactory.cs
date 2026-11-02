using System;
using Client.Enums;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;

namespace Client.Factories;

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(PageViewEnum page)
    {
        return page switch
        {
            PageViewEnum.Home => new HomeViewModel(),
            PageViewEnum.Courses => new CourseViewModel(),
            PageViewEnum.Students => new StudentViewModel(new StudentService()),
            PageViewEnum.Teachers => new TeacherViewModel(new TeacherService()),
            PageViewEnum.AddStudent => new AddStudentViewModel(),
            PageViewEnum.AddTeacher => new AddTeacherViewModel(),
            PageViewEnum.EditTeacher => new EditTeacherViewModel(new TeacherService()),
            _ => throw new InvalidOperationException("Det fanns inte de du ville ha")
        };
    }
}
