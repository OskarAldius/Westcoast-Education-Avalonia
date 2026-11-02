using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Interfaces;
using Client.School;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;



    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string FieldOfKnowledge { get; set; } = string.Empty;

    public AddTeacherViewModel()
    {
        _teacherService = new TeacherService();
        PageTitle = "Ny Lärare";
    }

    public AddTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Ny Lärare";
    }


    [RelayCommand]

    private async Task Save()
    {
        Teachers teacher = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            FieldOfKnowledge = FieldOfKnowledge

        };
        await _teacherService.Add(teacher);
        ClearData();
    }

    private void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        FieldOfKnowledge = string.Empty;

    }

}
