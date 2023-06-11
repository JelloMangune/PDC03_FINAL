using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace FinalExam.Droid
{
    public class FileSystemHelper : IFileSystemHelper
    {
        public string GetAppDataFolderPath(string folderName)
        {
            string appDataFolderPath = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath, folderName);
            Directory.CreateDirectory(appDataFolderPath);
            return appDataFolderPath;
        }
    }
}