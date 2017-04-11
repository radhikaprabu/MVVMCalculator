using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;


namespace MVVMCalculator
{
    public class App : Application
    {
        AdderViewModel adderViewModel;
        public App()
        {
            adderViewModel = new AdderViewModel();
            adderViewModel.RestoreState(Current.Properties);
            MainPage = new MVVMCalculatorPage(adderViewModel);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
