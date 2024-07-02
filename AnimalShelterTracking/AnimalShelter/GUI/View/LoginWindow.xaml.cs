using AnimalShelter.GUI.ViewModel;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Users;
using System.Windows;

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
                        MemberWindow memberWindow = new MemberWindow((Model.Users.Member) loggedUser);
                        memberWindow.Show();
                    }

                    else if (loggedUser.Account.Role == Role.VOLUNTEER)
                    {
                        VolunteerWindow volunteerWindow = new VolunteerWindow((Volunteer) loggedUser);
                        volunteerWindow.Show();
                    }

                    else if (loggedUser.Account.Role == Role.ADMINISTRATOR)
                    {
                        AdminWindow adminWindow = new AdminWindow((Administrator) loggedUser);
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
