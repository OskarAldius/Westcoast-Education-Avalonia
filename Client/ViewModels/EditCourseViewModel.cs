using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    private readonly ICourseService? _courseService;
    private string _id = string.Empty;
    private string _objectId = string.Empty;

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string CoursLength { get; set; } = string.Empty;

    public EditCourseViewModel() { }

    public EditCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        PageTitle = "Uppdatera Kurs";
    }

    public async void Init(string id)
    {
        _id = id;
        await GetCourse();
    }

    private async Task GetCourse()
    {
        try
        {
            var teacher = await _courseService!.Find(_id);
            _objectId = teacher._id;
            Title = teacher.Title ?? string.Empty;
            StartDate = teacher.StartDate ?? string.Empty;
            EndDate = teacher.EndDate ?? string.Empty;
            CoursLength = teacher.CoursLength ?? string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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

            await _courseService!.Update(courses, _objectId);
            ClearData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
