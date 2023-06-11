using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalExam.ViewModel;

namespace FinalExam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAnimal : ContentPage
    {
        public ViewAnimal(Animal animal)
        {
            InitializeComponent();
            DisplayAnimal(animal);
        }
        private void DisplayAnimal(Animal animal)
        {
            lblAnimalCode.Text = animal.AnimalCode;
            lblCharacteristics.Text = animal.Characteristics;
            lblSpecies.Text = animal.Species;
            lblHabitat.Text = animal.Habitat;
            lblThreat.Text = animal.Threat;
            imgAnimal.Source = animal.Image;
        }
        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}