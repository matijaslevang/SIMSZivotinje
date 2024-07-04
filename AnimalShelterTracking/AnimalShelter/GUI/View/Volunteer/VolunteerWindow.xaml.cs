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

namespace AnimalShelter.GUI.View
{
    public partial class VolunteerWindow : Window
    {
        public MemberListPage MemberListPage {  get; set; }
        public RequestsPage RequestsPage { get; set; }
        public VotingPage VotingPage { get; set; }
        public Homepage Homepage { get; set; }
        public SolidColorBrush HighlightBrush { get; set; }
        public SolidColorBrush NormalBrush { get; set; }

        public Volunteer Volunteer { get; set; }
        
        public VolunteerWindow(Volunteer volunteer)
        {
            InitializeComponent();
            this.MemberListPage = new MemberListPage();
            this.RequestsPage = new RequestsPage();
            this.VotingPage = new VotingPage(volunteer);
            this.Homepage = new Homepage(volunteer);
            frame.Navigate(Homepage);
            this.HighlightBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#faedcd"));
            this.NormalBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#edb580"));
            homeButton.Foreground = HighlightBrush;
            this.Volunteer = volunteer;
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            frame.Navigate(Homepage);
            homeButton.Foreground = HighlightBrush;
            votingButton.Foreground = NormalBrush;
            requestsButton.Foreground = NormalBrush;
            membersButton.Foreground = NormalBrush;
        }

        private void Button_Requests(object sender, RoutedEventArgs e)
        {
            frame.Navigate(RequestsPage);
            homeButton.Foreground = NormalBrush;
            votingButton.Foreground = NormalBrush;
            requestsButton.Foreground = HighlightBrush;
            membersButton.Foreground = NormalBrush;
        }

        private void Button_Voting(object sender, RoutedEventArgs e)
        {
            frame.Navigate(VotingPage);
            homeButton.Foreground = NormalBrush;
            votingButton.Foreground = HighlightBrush;
            requestsButton.Foreground = NormalBrush;
            membersButton.Foreground = NormalBrush;
        }

        private void Button_Members(object sender, RoutedEventArgs e)
        {
            MemberListPage.DataContext = new MembersVM();
            frame.Navigate(MemberListPage);
            homeButton.Foreground = NormalBrush;
            votingButton.Foreground = NormalBrush;
            requestsButton.Foreground = NormalBrush;
            membersButton.Foreground = HighlightBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
