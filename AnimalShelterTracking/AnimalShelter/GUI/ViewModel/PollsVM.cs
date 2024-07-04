using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Users;
using AnimalShelter.Model.Votes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class PollsVM : INotifyPropertyChanged
    {
        private ObservableCollection<Poll> _polls;
        private PollService pollService;


        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public Volunteer Voter { get; set; }
        public ObservableCollection<Poll> Polls
        {
            get => _polls;
            set
            {
                _polls = value;
                OnPropertyChanged();
            }
        }

        public PollsVM(PostBorders borders, PollReasons reasons, Volunteer voter)
        {
            Voter = voter;
            pollService = new PollService();
            borders.HideAllBorders();
            Polls = new ObservableCollection<Poll>(pollService.GetAll());
            for (int i = 0;i< Polls.Count;i++)
            {
                borders.Show(i);
                if (Polls[i].IsBeingPromoted)
                {
                    reasons.IsBeingPromoted(i);
                }
                if (!Polls[i].IsBeingPromoted)
                {
                    reasons.IsBeingDegraded(i);
                }
            }

        }

        private void YesClick(object parameter)
        {

            int i = (int)parameter;
            Polls[i].VotesFor++;
            Polls[i].Voters.Add(Voter.Id);
            pollService.Update(Polls[i].Id, Polls[i]);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
