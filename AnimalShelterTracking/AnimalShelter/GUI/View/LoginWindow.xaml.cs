using AnimalShelter.GUI.ViewModel;
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
using AnimalShelter.Model.Enums;

namespace AnimalShelter.GUI.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel viewModel { get; set; }
        public UserService userService { get; set; }
        public User loggedUser { get; set; }

        public LoginWindow()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            userService = new UserService();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (viewModel.IsValid)
            {
                loggedUser = userService.Login(viewModel.Email, viewModel.Password);

                if (loggedUser != null)
                {
                    if (loggedUser.Account.Role == Role.MEMBER)
                    {
                        MemberWindow memberWindow = new MemberWindow();
                        memberWindow.Show();
                    }

                    else if (loggedUser.Account.Role == Role.VOLUNTEER)
                    {
                        VolunteerWindow volunteerWindow = new VolunteerWindow();
                        volunteerWindow.Show();
                    }

                    else if (loggedUser.Account.Role == Role.ADMINISTRATOR)
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                    }
                    Close();
                }

                else
                {
                    viewModel.Error = "Invalid email or password.";
                }
            }
        }
    }
}
