using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;
    [ObservableProperty]
    public partial ObservableCollection<Students> Students { get; set; } = [];

    public StudentViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        PageTitle = "Våra Studenter";
        Init();

    }
    public StudentViewModel()
    {
        _studentService = new StudentService();
        PageTitle = "Våra Studenter";
        Init();
    }
    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            Students = new ObservableCollection<Students>(await _studentService.List());
        }
        catch (Exception ex)
        {

            System.Console.WriteLine(ex.Message);
        }
    }
}
