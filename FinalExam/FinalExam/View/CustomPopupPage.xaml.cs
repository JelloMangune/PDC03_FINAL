using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalExam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPopupPage : ContentPage
    {
        public string SelectedOption { get; private set; }

        public CustomPopupPage()
        {
            InitializeComponent();
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            SelectedOption = "Show";
            ClosePopup();
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            SelectedOption = "Update";
            ClosePopup();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            SelectedOption = "Delete";
            ClosePopup();
        }
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            SelectedOption = "Cancel";
            ClosePopup();
        }

        private async void ClosePopup()
        {
            await Navigation.PopModalAsync();
            MessagingCenter.Send(this, "OptionSelected", SelectedOption);
        }
    }
}