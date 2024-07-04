using AnimalShelter.GUI.ViewModel;
using AnimalShelter.Model.Posts;
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

namespace AnimalShelter.GUI.View
{
    /// <summary>
    /// Interaction logic for TemporaryCareRequestWindow.xaml
    /// </summary>
    public partial class TemporaryCareRequestWindow : Window
    {
        public TemporaryCareRequestWindow(Post post, Model.Users.Member member)
        {
            InitializeComponent();
            TemporaryCareRequestVM temporaryCareRequestVM = new TemporaryCareRequestVM(this, post.Pet, member);
            DataContext = temporaryCareRequestVM;
        }
    }
}
