using FinalExam.Model;
using FinalExam.ViewModel;
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
    public partial class ListAnimal : ContentPage
    {
        AnimalViewModel viewModel;
        public ListAnimal()
        {
            InitializeComponent();
            viewModel = new AnimalViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showAnimal();
        }

        private void showAnimal()
        {
            var res = viewModel.GetAllAnimal().Result;
            AnimalListView.ItemsSource = res;

        }

        private void btnAddRecord_Clicked(Object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddAnimal());
        }

        private async void AnimalListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Animal obj = (Animal)e.SelectedItem;


                var popupPage = new CustomPopupPage();
                await Navigation.PushModalAsync(popupPage);

                MessagingCenter.Subscribe<CustomPopupPage, string>(this, "OptionSelected", async (page, selectedOption) =>
                {
                    if (selectedOption == "Update")
                    {
                        await this.Navigation.PushAsync(new AddAnimal(obj));
                    }
                    else if (selectedOption == "Show")
                    {
                        await this.Navigation.PushAsync(new ViewAnimal(obj));
                    }
                    else if (selectedOption == "Delete")
                    {
                        viewModel.DeleteAnimal(obj);
                        showAnimal();
                    }
                    else if (selectedOption == "Cancel")
                    {
                        showAnimal();
                    }

                    AnimalListView.SelectedItem = null;
                    MessagingCenter.Unsubscribe<CustomPopupPage, string>(this, "OptionSelected");
                });


                if (e.SelectedItem == null)
                    return;

                // Deselect the item
                AnimalListView.SelectedItem = null;
            }

        }
    }
}