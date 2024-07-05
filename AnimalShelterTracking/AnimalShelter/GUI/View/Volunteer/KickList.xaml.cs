using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;
using AnimalShelter.Model.Posts;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Votes;
using VolunteerNamespace = AnimalShelter.Model.Users;

namespace AnimalShelter.GUI.View.Volunteer
{
    /// <summary>
    /// Interaction logic for KickList.xaml
    /// </summary>
    public partial class KickList : Window, INotifyPropertyChanged
    {
        private VolunteerNamespace.Volunteer _kickedVolunteer;
        private ObservableCollection<VolunteerNamespace.Volunteer> _volunteers;
        private UserService userService;

        public VolunteerNamespace.Volunteer KickedVolunteer
        {
            get => _kickedVolunteer;
            set
            {
                _kickedVolunteer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<VolunteerNamespace.Volunteer> NotKickedVolunteers
        {
            get => _volunteers;
            set
            {
                _volunteers = value;
                OnPropertyChanged();
            }
        }

        public KickList()
        {
            userService = new UserService();
            NotKickedVolunteers = new ObservableCollection<VolunteerNamespace.Volunteer>();
            KickedVolunteer = new VolunteerNamespace.Volunteer();
            foreach (VolunteerNamespace.Volunteer volunteer in userService.GetAllVolunteers()) {
                if (!volunteer.IsBlacklisted)
                {
                    NotKickedVolunteers.Add(volunteer);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AcceptKick_Click(object sender, RoutedEventArgs e)
        {
            if (KickedVolunteer != null)
            {
                Poll poll = new Poll(KickedVolunteer, false);
                PollService pollService = new PollService();
                pollService.Add(poll);

                KickedVolunteer.IsBlacklisted = true;
                userService.Update(KickedVolunteer.Id, KickedVolunteer);
                NotKickedVolunteers.Remove(KickedVolunteer);

                MessageBox.Show("The volunteer successfully chosen to be kicked.", "Announcement");
            }
            Close();
        }
    }
}
