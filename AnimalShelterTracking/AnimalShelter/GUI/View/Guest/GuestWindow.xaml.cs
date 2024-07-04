using AnimalShelter.GUI.ViewModel;
using AnimalShelter.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AnimalShelter.GUI.ViewModel.Helper;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{
    public partial class GuestWindow : Window
    {

        public GuestWindow()
        {
            InitializeComponent();
            Homepage homepage = new Homepage();
            frame.Navigate(homepage);
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

            homepage.adopt1.Visibility = Visibility.Collapsed;
            homepage.temporaryCare1.Visibility = Visibility.Collapsed;

            homepage.adopt2.Visibility = Visibility.Collapsed;
            homepage.temporaryCare2.Visibility = Visibility.Collapsed;

            homepage.adopt3.Visibility = Visibility.Collapsed;
            homepage.adopt4.Visibility = Visibility.Collapsed;
            homepage.adopt5.Visibility = Visibility.Collapsed;
            homepage.adopt6.Visibility = Visibility.Collapsed;
            homepage.adopt7.Visibility = Visibility.Collapsed;
            homepage.adopt8.Visibility = Visibility.Collapsed;
            homepage.adopt9.Visibility = Visibility.Collapsed;
            homepage.adopt2.Visibility = Visibility.Collapsed;

            homepage.temporaryCare3.Visibility = Visibility.Collapsed;
            homepage.temporaryCare4.Visibility = Visibility.Collapsed;
            homepage.temporaryCare5.Visibility = Visibility.Collapsed;
            homepage.temporaryCare6.Visibility = Visibility.Collapsed;
            homepage.temporaryCare7.Visibility = Visibility.Collapsed;
            homepage.temporaryCare8.Visibility = Visibility.Collapsed;
            homepage.temporaryCare9.Visibility = Visibility.Collapsed;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(null, this);
            loginWindow.DataContext = loginWindow;
            loginWindow.Show();
        }
    }
}
