using Foundation;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using UIKit;

namespace MvvmcrossDemo
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }

    public class Setup : MvxIosSetup<App>
    {
    }

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }

    
}