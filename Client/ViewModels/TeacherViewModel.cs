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
    private readonly ITeacherService _teacherService;
    [ObservableProperty]
    public partial ObservableCollection<Teachers> Teachers { get; set; } = [];

    public TeacherViewModel()
    {
        _teacherService = new TeacherService();
        PageTitle = "Våra Lärare";
        Init();
    }
    public TeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Våra Lärare";
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

            TeacherRestDb teachers = await _teacherService.Find(id);
            if (teachers is not null)
            {
                await _teacherService.Delete(teachers._id);
                await LoadTeachers();
            }
        }
        catch (Exception ex)
        {

            System.Console.WriteLine(ex.Message);
        }
    }

    private async Task LoadTeachers()
    {
        try
        {
            Teachers = new ObservableCollection<Teachers>(await _teacherService.List());
        }
        catch (Exception ex)
        {

            System.Console.WriteLine(ex.Message);
        }
    }
}
