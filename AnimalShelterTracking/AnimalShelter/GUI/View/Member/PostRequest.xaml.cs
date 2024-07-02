using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View.Member
{
    public partial class PostRequest : Window
    {
        public PostRequest()
        {
            InitializeComponent();
            gender.Items.Add(Gender.MALE);
            gender.Items.Add(Gender.FEMALE);
            BreedService breedService = new BreedService();
            SpeciesService speciesService = new SpeciesService();

            foreach (Species species in speciesService.GetAll())
            {
                speciesList.Items.Add(species.Name);
            }
            foreach (Breed breed in breedService.GetAll())
            {
                breedList.Items.Add(breed.Name);
            }
            foreach (HealthStatus status in Enum.GetValues(typeof(HealthStatus)))
            {
                healthStatus.Items.Add(status);
            }
            this.Show();
        }

    }
}
