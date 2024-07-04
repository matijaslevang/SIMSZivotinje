using AnimalShelter.GUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
using AnimalShelter.Model.Posts;

namespace AnimalShelter.GUI.View
{
    public partial class AdoptionRequestWindow : Window
    {
        public AdoptionRequestWindow(Post post, Model.Users.Member member)
        {
            InitializeComponent();
            AdoptionRequestVM adoptionRequestVM = new AdoptionRequestVM(this, post.Pet, member);
            DataContext = adoptionRequestVM;
        }

    }
}
