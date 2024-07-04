using AnimalShelter.GUI.ViewModel;
using AnimalShelter.GUI.ViewModel.Helper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{

    public partial class Homepage : Page
    {
        public Likes Likes { get; set; }
        public Homepage(Model.Users.Member member)
        {
            InitializeComponent();
            PostBorders borders = new PostBorders(Border1, Border2, Border3, Border4, Border5, Border6, Border7, Border8, Border9);
            this.Likes = new Likes(like1, like2, like3, like4, like5, like6, like7, like8, like9);
            PostsVM postsVM = new PostsVM(borders, member, Likes);
            DataContext = postsVM;
        }
    }
}
