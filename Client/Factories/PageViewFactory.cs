using System;
using Client.Enums;
using Client.Interfaces;
using Client.ViewModels;

namespace Client.Factories;

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(PageViewEnum page)
    {
        return page switch
        {
            PageViewEnum.Home => new HomeViewModel(),
            PageViewEnum.Courses => new CourseViewModel(),
            _ => throw new InvalidOperationException("Det fanns inte de du ville ha")
        };
    }
}
