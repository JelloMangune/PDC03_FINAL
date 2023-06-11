using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalExam.ViewModel;
using Xamarin.Essentials;

using System.IO;

namespace FinalExam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnimal : ContentPage
    {
        AnimalViewModel _viewModel;
        bool _isUpdate;
        int animalID;
        string imageDirectory;


        public AddAnimal()
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            _isUpdate = false; 
        }

        public AddAnimal(Animal obj)
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            if (obj != null)
            {
                animalID = obj.Id;
                txtAnimalCode.Text = obj.AnimalCode;
                txtCharacteristics.Text = obj.Characteristics;
                txtSpecies.Text = obj.Species;
                txtHabitat.Text = obj.Habitat;
                txtThreat.Text = obj.Threat;
                _isUpdate = true;

                if (!string.IsNullOrEmpty(obj.Image))
                {
                    imageDirectory = obj.Image;
                    imgAnimal.Source = ImageSource.FromFile(Path.Combine(App.ImageFolderPath, obj.Image));
                }
            }
        }

        // Call Save and Update

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Animal obj = new Animal();
            obj.Id = animalID;
            obj.AnimalCode = txtAnimalCode.Text;
            obj.Characteristics = txtCharacteristics.Text;
            obj.Species = txtSpecies.Text;
            obj.Habitat = txtHabitat.Text;
            obj.Threat = txtThreat.Text;
            obj.Image = imageDirectory;

            if (_isUpdate)
            {
                obj.Id = animalID;
                await _viewModel.UpdateAnimal(obj);
            }
            else
            {
                _viewModel.InsertAnimal(obj);
            }

            await this.Navigation.PopAsync();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void BtnUploadImage_Clicked(object sender, EventArgs e)
        {
            try
            {
                var mediaOptions = new MediaPickerOptions
                {
                    Title = "Select Animal Image"
                };

                var selectedImageFile = await MediaPicker.PickPhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    // Set the image source of the Image control
                    imgAnimal.Source = ImageSource.FromStream(() => selectedImageFile.OpenReadAsync().Result);

                    // Save the image file to the app's local storage
                    string fileName = Path.GetFileName(selectedImageFile.FileName);
                    string destinationPath = Path.Combine(App.ImageFolderPath, fileName);

                    using (var stream = await selectedImageFile.OpenReadAsync())
                    {
                        using (var fileStream = File.Create(destinationPath))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }

                    // Save the image directory in the model
                    imageDirectory = Path.Combine(App.ImageFolderPath, fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}