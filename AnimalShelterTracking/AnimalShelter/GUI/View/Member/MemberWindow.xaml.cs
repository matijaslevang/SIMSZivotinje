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
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{
    public partial class MemberWindow : Window
    {
        public MemberWindow(Model.Users.Member member)
        {
            InitializeComponent();
            Homepage homepage = new Homepage(member);
            frame.Navigate(homepage);
            PostBorders borders = new PostBorders(homepage.Border1, homepage.Border2, homepage.Border3, homepage.Border4,
                homepage.Border5, homepage.Border6, homepage.Border7, homepage.Border8, homepage.Border9);
            Likes likes = new Likes(homepage.like1, homepage.like2, homepage.like3, homepage.like4, homepage.like5, homepage.like6, homepage.like7, homepage.like8, homepage.like9);
            PostsVM postsVM = new PostsVM(borders, member, likes);
            homepage.delete1.Visibility = Visibility.Collapsed;
            homepage.update1.Visibility = Visibility.Collapsed;

            homepage.delete2.Visibility = Visibility.Collapsed;
            homepage.update2.Visibility = Visibility.Collapsed;

            homepage.delete3.Visibility = Visibility.Collapsed;
            homepage.update3.Visibility = Visibility.Collapsed;

            homepage.delete4.Visibility = Visibility.Collapsed;
            homepage.update4.Visibility = Visibility.Collapsed;

            homepage.delete5.Visibility = Visibility.Collapsed;
            homepage.update5.Visibility = Visibility.Collapsed;

            homepage.delete6.Visibility = Visibility.Collapsed;
            homepage.update6.Visibility = Visibility.Collapsed;

            homepage.delete7.Visibility = Visibility.Collapsed;
            homepage.update7.Visibility = Visibility.Collapsed;

            homepage.delete8.Visibility = Visibility.Collapsed;
            homepage.update8.Visibility = Visibility.Collapsed;

            homepage.delete9.Visibility = Visibility.Collapsed;
            homepage.update9.Visibility = Visibility.Collapsed;
            DataContext = postsVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
