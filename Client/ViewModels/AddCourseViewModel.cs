using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;



    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string CoursLength { get; set; } = string.Empty;

    public AddCourseViewModel()
    {
        _courseService = new CourseService();
        PageTitle = "Ny Kurs";
    }

    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Ny Kurs";
    }


    [RelayCommand]

    private async Task Save()
    {
        try
        {
            Courses courses = new()
            {
                Title = Title,
                StartDate = StartDate,
                EndDate = EndDate,
                CoursLength = CoursLength

            };
            await _courseService.Add(courses);
            ClearData();
        }
        catch (Exception ex)
        {

            System.Console.WriteLine(ex.Message);
        }

    }

    private void ClearData()
    {
        Title = string.Empty;
        StartDate = string.Empty;
        EndDate = string.Empty;
        CoursLength = string.Empty;

    }

}

