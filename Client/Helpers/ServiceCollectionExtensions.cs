using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<IPageViewFactory, PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CourseViewModel>();
        collection.AddTransient<AddCourseViewModel>();
        collection.AddTransient<EditCourseViewModel>();
        collection.AddTransient<StudentViewModel>();
        collection.AddTransient<AddStudentViewModel>();
        collection.AddTransient<TeacherViewModel>();
        collection.AddTransient<AddTeacherViewModel>();
        collection.AddTransient<EditTeacherViewModel>();
        collection.AddTransient<ICourseService, CourseService>();
        collection.AddTransient<IStudentService, StudentService>();
        collection.AddTransient<ITeacherService, TeacherService>();
    }
}
