using System;
using System.Windows;

namespace SonicaWebAdmin.SonicaAdmin.P
{
    public class PageViewModelBase
    {
        //private WindowState _mainWindowState;
        //private Thickness _hackAdditionalThickness;
        //private ResizeMode _mainWindowResizeMode;

        //protected PageViewModelBase()
        //{
        //    MainWindowHeight = 540;
        //    MainWindowWidth  = 880;
        //    HackAdditionalThickness = new Thickness(1);
        //    MainWindowResizeMode = ResizeMode.CanResizeWithGrip;
        //}

        //private void Exit()
        //{
        //    if (this is IDisposable disposable)
        //        disposable.Dispose();

        //    //Если использовали сонику, то нужно прибить лоадер, так как он в другом STA потоке
        //    ApplicationScope.TheApp?.LoadingBoxManager.Release();

        //    App.Current.Shutdown(0);
        //}

        //protected void OpenPage(PageViewModelBase nextStep)
        //{
        //    NextPage = nextStep;
        //    NextPageChanged?.Invoke(this, nextStep);
        //}

        //public event Action<object, PageViewModelBase> NextPageChanged;
        //public PageViewModelBase NextPage { get; private set; }

        //private void Maximize()
        //{
        //    if (MainWindowState == WindowState.Maximized)
        //        MainWindowState = WindowState.Normal;
        //    else
        //        MainWindowState = WindowState.Maximized;
        //}

        //private void Minimize()
        //{
        //    MainWindowState = WindowState.Minimized;
        //}

        //public Thickness HackAdditionalThickness
        //{
        //    get => _hackAdditionalThickness;
        //    set
        //    {
        //        _hackAdditionalThickness = value;
        //        SendPropertyChanged();
        //    }
        //}

        //public ResizeMode MainWindowResizeMode
        //{
        //    get => _mainWindowResizeMode;
        //    set
        //    {
        //        _mainWindowResizeMode = value;
        //        SendPropertyChanged();
        //    }
        //}

        //public WindowState MainWindowState
        //{
        //    get => _mainWindowState;
        //    set
        //    {
        //        _mainWindowState = value;
        //        //Хак нужен, что бы при максимайзе окно не съедалось границами экрана.
        //        if (value == WindowState.Maximized)
        //            HackAdditionalThickness = new Thickness(6);
        //        else
        //            HackAdditionalThickness = new Thickness(0);
        //        SendPropertyChanged();
        //    }
        //}

        //public int MainWindowHeight
        //{
        //    get => _mainWindowHeight;
        //    set
        //    {
        //        _mainWindowHeight = value; 
        //        SendPropertyChanged();
        //    }
        //}
        
        //public int MainWindowWidth
        //{
        //    get => _mainWindowWidth;
        //    set
        //    {
        //        _mainWindowWidth = value; 
        //        SendPropertyChanged();
        //    }
        //}
    }
}
