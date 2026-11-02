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
            PageViewEnum.Courses => new CourseViewModel(new CourseService()),
            PageViewEnum.Students => new StudentViewModel(new StudentService()),
            PageViewEnum.Teachers => new TeacherViewModel(new TeacherService()),
            PageViewEnum.AddStudent => new AddStudentViewModel(),
            PageViewEnum.AddTeacher => new AddTeacherViewModel(),
            PageViewEnum.EditTeacher => new EditTeacherViewModel(new TeacherService()),
            PageViewEnum.AddCourse => new AddCourseViewModel(),
            PageViewEnum.EditCourse => new EditCourseViewModel(new CourseService()),
            _ => throw new InvalidOperationException("Det fanns inte de du ville ha")
        };
    }
}
