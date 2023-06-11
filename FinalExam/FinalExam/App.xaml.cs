using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace FinalExam
{
    public partial class App : Application
    {
        public static string ImageFolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Images");
            Directory.CreateDirectory(folderPath);
            ImageFolderPath = DependencyService.Get<IFileSystemHelper>().GetAppDataFolderPath(folderPath);

            MainPage = new NavigationPage(new View.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
