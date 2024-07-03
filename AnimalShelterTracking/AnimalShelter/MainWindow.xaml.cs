using System.Collections.Generic;
using System;
using System.Windows;
using AnimalShelter.GUI.View;
using AnimalShelter.GUI.View.Member;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Posts;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Utilities;
using AnimalShelter.Model.Requests;

namespace AnimalShelter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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

            //RegistrationRequest regReq = new RegistrationRequest();
            //regReq.Show();
            //PostRequest postReq = new PostRequest();
            //postReq.Show();
            //GuestWindow window = new GuestWindow();
            //window.Show();
            //GuestWindow guestWindow = new GuestWindow();
            //guestWindow.Show();
            VolunteerWindow volunteerWindow = new VolunteerWindow();
            volunteerWindow.Show();
            //MemberWindow memberWindow = new MemberWindow();
            //memberWindow.Show();
            //Address address = new Address("USA", "Springfield", "123 Main St", "1A", "62704");
            //RegistrationRequest rr = new RegistrationRequest("John", "Doe", "123456789", "john.doe@example.com", "password123", "ID123456", address);
            ////Account account = new Account("jane.doe@example.com", "password456", Role.MEMBER);
            //Account account1 = new Account("john.doe@example.com", "password456", Role.MEMBER);
            ////Member author = new Member(account, "Jane", "Doe", "987654321", "ID123456", DateTime.Parse("01-01-2000"), Gender.FEMALE);
            //Member requester = new Member(account1, "John", "Doe", "987654321", "ID123457", DateTime.Parse("01-01-2000"), Gender.MALE);
            //UserService userService = new UserService();
            ////userService.Add(author);
            //userService.Add(requester);
            //Species species = new Species("Dog");
            //Breed breed = new Breed(1, "Chihuahua");
            //Pet pet = new Pet("Buddy", HealthStatus.DISABLED, "missing a leg", 2, false, "blue", "ftn", species, breed, null);
            //Post post = new Post(1, author, pet);
            //PostService postService = new PostService();
            ////postService.Add(post);
            //PostRequest pr = new PostRequest(requester, post);
            //RegistrationRequestService rss = new RegistrationRequestService();
            //rss.Add(rr);
            //PostRequestService postRequestService = new PostRequestService();
            //postRequestService.Add(pr);
            //PostRequestWindow postRequestWindow = new PostRequestWindow();
            //postRequestWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.DataContext = loginWindow;
            loginWindow.Show();
        }
    }
}
