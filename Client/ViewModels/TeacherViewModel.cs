using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.School;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{
    public string Id { get; set; }
    private readonly ITeacherService _teacherService;

    [ObservableProperty]
    public partial ObservableCollection<TeacherRestDb> Teachers { get; set; } = [];
    public TeacherViewModel()
    {
        _teacherService = new TeacherService();
        PageTitle = "Våra Lärare";
        Id = "";
        Init();
    }
    public TeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Våra Lärare";
        Id = "";
        Init();
    }
    private async void Init()
    {
        await LoadTeachers();
    }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            await _teacherService.Delete(id);
            await LoadTeachers();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task LoadTeachers()
    {
        try
        {
            Teachers = new ObservableCollection<TeacherRestDb>(await _teacherService.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
