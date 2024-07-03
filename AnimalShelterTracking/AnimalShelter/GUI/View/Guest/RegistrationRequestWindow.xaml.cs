using AnimalShelter.GUI.ViewModel;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Users;
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
    public partial class RegistrationRequestWindow : Window
    {
        public RegistrationVM ViewModel { get; set; }
        public UserService UserService { get; set; }
        public RegistrationRequestWindow()
        {
            InitializeComponent();
            ViewModel = new RegistrationVM();
            UserService = new UserService();

            foreach (Gender gen in Enum.GetValues(typeof(Gender)))
            {
                gender.Items.Add((Gender)gen);
            }
        }

        private void SendRequest_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Error = "";
            if (ViewModel.IsValid)
            {
                MessageBox.Show(ViewModel.FirstName);
            }
            else
            {

            }
        }
    }
}
