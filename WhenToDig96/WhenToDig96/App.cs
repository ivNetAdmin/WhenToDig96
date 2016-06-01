using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhenToDig96.Pages;
using Xamarin.Forms;

namespace WhenToDig96
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = GetMainPage();            
        }

        private static Page GetMainPage()
        {
            return new Calendar();
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
