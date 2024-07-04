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
using System.Security.Principal;
using AnimalShelter.Model.Votes;

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

            
            homepage.adopt1.Visibility = Visibility.Collapsed;
            homepage.adopt2.Visibility = Visibility.Collapsed;
            homepage.adopt3.Visibility = Visibility.Collapsed;
            homepage.adopt4.Visibility = Visibility.Collapsed;
            homepage.adopt5.Visibility = Visibility.Collapsed;
            homepage.adopt6.Visibility = Visibility.Collapsed;
            homepage.adopt7.Visibility = Visibility.Collapsed;
            homepage.adopt8.Visibility = Visibility.Collapsed;
            homepage.adopt9.Visibility = Visibility.Collapsed;
            homepage.adopt2.Visibility = Visibility.Collapsed;

            homepage.temporaryCare1.Visibility = Visibility.Collapsed;
            homepage.temporaryCare2.Visibility = Visibility.Collapsed;
            homepage.temporaryCare3.Visibility = Visibility.Collapsed;
            homepage.temporaryCare4.Visibility = Visibility.Collapsed;
            homepage.temporaryCare5.Visibility = Visibility.Collapsed;
            homepage.temporaryCare6.Visibility = Visibility.Collapsed;
            homepage.temporaryCare7.Visibility = Visibility.Collapsed;
            homepage.temporaryCare8.Visibility = Visibility.Collapsed;
            homepage.temporaryCare9.Visibility = Visibility.Collapsed;

            homepage.like1.Visibility = Visibility.Collapsed;
            homepage.like2.Visibility = Visibility.Collapsed;
            homepage.like3.Visibility = Visibility.Collapsed;
            homepage.like4.Visibility = Visibility.Collapsed;
            homepage.like5.Visibility = Visibility.Collapsed;
            homepage.like6.Visibility = Visibility.Collapsed;
            homepage.like7.Visibility = Visibility.Collapsed;
            homepage.like8.Visibility = Visibility.Collapsed;
            homepage.like9.Visibility = Visibility.Collapsed;

            homepage.comment1.Visibility = Visibility.Collapsed;
            homepage.comment2.Visibility = Visibility.Collapsed;
            homepage.comment3.Visibility = Visibility.Collapsed;
            homepage.comment4.Visibility = Visibility.Collapsed;
            homepage.comment5.Visibility = Visibility.Collapsed;
            homepage.comment6.Visibility = Visibility.Collapsed;
            homepage.comment7.Visibility = Visibility.Collapsed;
            homepage.comment8.Visibility = Visibility.Collapsed;
            homepage.comment9.Visibility = Visibility.Collapsed;


            //RegistrationRequest regReq = new RegistrationRequest();
            //regReq.Show();
            //PostRequest postReq = new PostRequest();
            //postReq.Show();
            //GuestWindow window = new GuestWindow();
            //window.Show();
            //GuestWindow guestWindow = new GuestWindow();
            //guestWindow.Show();
            //VolunteerWindow volunteerWindow = new VolunteerWindow();
            //VolunteerWindow volunteerWindow = new VolunteerWindow(volunteer);
            //volunteerWindow.Show();
            //MemberWindow memberWindow = new MemberWindow();
            //memberWindow.Show();
            //Address address = new Address("USA", "Springfield", "123 Main St", "1A", "62704");
            //RegistrationRequest rr = new RegistrationRequest("John", "Doe", "123456789", "john.doe@example.com", "password123", "ID123456", address);
            //Account account1 = new Account("john.doe@example.com", "password456", Role.MEMBER);
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

            //Account account = new Account("jane.doe@example.com", "password", Role.VOLUNTEER);
            //Volunteer volunteer = new Volunteer(account, "Jane", "Doe", "987654321", "ID123456", DateTime.Parse("01-01-2000"), Gender.FEMALE);
            //Member author = new Member(account, "Jane", "Doe", "987654321", "ID123456", DateTime.Parse("01-01-2000"), Gender.FEMALE);
            //Poll poll = new Poll(author, true);
            //Poll poll2 = new Poll(volunteer, false);
            //PollService ps = new PollService();
            //ps.Add(poll);
            //ps.Add(poll2);
            //Comment comment = new Comment(1, volunteer, "Poor thing!");
            //CommentService cs = new CommentService(); 
            //cs.Add(comment);    
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(this);
            loginWindow.DataContext = loginWindow;
            loginWindow.Show();
        }

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            RegistrationRequestWindow window = new RegistrationRequestWindow();
            window.DataContext = window;
            window.Show();
        }
    }
}
