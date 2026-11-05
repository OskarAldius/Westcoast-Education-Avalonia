using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CourseViewModel : ViewModelBase
{
    public string Id { get; set; }
    private readonly ICourseService _courseService;

    [ObservableProperty]
    public partial ObservableCollection<CoursesRestDb> Courses { get; set; } = [];
    public CourseViewModel()
    {
        _courseService = new CourseService();
        PageTitle = "Våra Ämnen";
        Id = "";
        Init();
    }
    public CourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Våra Ämnen";
        Id = "";
        Init();
    }
    private async void Init()
    {
        await LoadCourses();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            await _courseService.Delete(id);
            await LoadCourses();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task LoadCourses()
    {
        try
        {
            Courses = new ObservableCollection<CoursesRestDb>(await _courseService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
