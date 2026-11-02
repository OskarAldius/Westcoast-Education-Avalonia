using System;
using Avalonia.Metadata;
using Client.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    public MainWindowViewModel(PageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }
    public MainWindowViewModel()
    {
        _pageViewFactory = new PageViewFactory();
    }

    [RelayCommand]
    private void GoToHome() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.Home);
    [RelayCommand]
    private void GoToCourses() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.Courses);
    [RelayCommand]
    private void GoToStudents() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.Students);
    [RelayCommand]
    private void GoToTeachers() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.Teachers);
    [RelayCommand]
    private void GoToAddStudent() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.AddStudent);
    [RelayCommand]
    private void GoToAddTeacher() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.AddTeacher);
    [RelayCommand]
    private void GoToAddCourse() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.AddCourse);



    [RelayCommand]
    private void GoToEditTeacher(string id)
    {
        var vm = (EditTeacherViewModel)_pageViewFactory.LoadPageViewModel(Enums.PageViewEnum.EditTeacher);
        vm.Init(id);
        CurrentView = vm;
    }
}
