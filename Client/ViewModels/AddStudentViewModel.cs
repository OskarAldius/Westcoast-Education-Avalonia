using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;
    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Address { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Postcode { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string City { get; set; } = string.Empty;

    public AddStudentViewModel()
    {
        _studentService = new StudentService();
        PageTitle = "Ny Student";
    }
    public AddStudentViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        PageTitle = "Ny Student";
    }

    [RelayCommand]

    private async Task Save()
    {
        try
        {
            Students students = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Postcode = Postcode,
                City = City
            };
            await _studentService.Add(students);
            ClearData();
        }
        catch (Exception ex)
        {

            System.Console.WriteLine(ex.Message); ;
        }

    }

    private void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        Postcode = string.Empty;
        City = string.Empty;
    }

}
