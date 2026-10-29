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
            PageViewEnum.Teachers => new TeacherViewModel(),
            PageViewEnum.AddStudent => new AddStudentViewModel(),
            _ => throw new InvalidOperationException("Det fanns inte de du ville ha")
        };
    }
}
