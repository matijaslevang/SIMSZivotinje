﻿using AnimalShelter.GUI.ViewModel;
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
        public LoginViewModel ViewModel { get; set; }
        public UserService UserService { get; set; }
        public User LoggedUser { get; set; }

        public LoginWindow()
        {
            InitializeComponent();

            ViewModel = new LoginViewModel();
            UserService = new UserService();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.IsValid)
            {
                LoggedUser = UserService.Login(ViewModel.Email, ViewModel.Password);

                if (LoggedUser != null)
                {
                    if (LoggedUser.Account.Role == Role.MEMBER)
                    {
                        MemberWindow memberWindow = new MemberWindow((Model.Users.Member) LoggedUser);
                        memberWindow.Show();
                    }

                    else if (LoggedUser.Account.Role == Role.VOLUNTEER)
                    {
                        VolunteerWindow volunteerWindow = new VolunteerWindow((Volunteer) LoggedUser);
                        volunteerWindow.Show();
                    }

                    else if (LoggedUser.Account.Role == Role.ADMINISTRATOR)
                    {
                        AdminWindow adminWindow = new AdminWindow((Administrator) LoggedUser);
                        adminWindow.Show();
                    }
                    Close();
                }

                else
                {
                    ViewModel.Error = "Invalid email or password.";
                }
            }
        }
    }
}
