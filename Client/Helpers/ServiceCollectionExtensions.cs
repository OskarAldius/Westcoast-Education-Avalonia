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
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<CourseViewModel>();
        collection.AddTransient<TeacherViewModel>();
        collection.AddTransient<StudentViewModel>();
        collection.AddTransient<IStudentService, StudentService>();
        collection.AddTransient<ITeacherService, TeacherService>();

    }
}
