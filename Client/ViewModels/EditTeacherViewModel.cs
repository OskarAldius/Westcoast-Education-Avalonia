using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService? _teacherService;
    private string _id = string.Empty;
    private string _objectId = string.Empty;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string FieldOfKnowledge { get; set; } = string.Empty;

    public EditTeacherViewModel() { }

    public EditTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Uppdatera lärare";
    }

    public async void Init(string id)
    {
        _id = id;
        await GetTeacher();
    }

    private async Task GetTeacher()
    {
        try
        {
            var teacher = await _teacherService!.Find(_id);
            _objectId = teacher._id;
            FirstName = teacher.FirstName ?? string.Empty;
            LastName = teacher.LastName ?? string.Empty;
            PhoneNumber = teacher.PhoneNumber ?? string.Empty;
            FieldOfKnowledge = teacher.FieldOfKnowledge ?? string.Empty;
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
            Teachers teachers = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                FieldOfKnowledge = FieldOfKnowledge
            };

            await _teacherService!.Update(teachers, _objectId);
            ClearData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        FieldOfKnowledge = string.Empty;

    }

}