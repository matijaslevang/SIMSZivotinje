using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Votes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.GUI.ViewModel
{
    public class PollsVM : INotifyPropertyChanged
    {
        private ObservableCollection<Poll> _polls;
        public ObservableCollection<Poll> Polls
        {
            get => _polls;
            set
            {
                _polls = value;
                OnPropertyChanged();
            }
        }

        public PollsVM(PostBorders borders, PollReasons reasons)
        {
            borders.HideAllBorders();
            PollService ps = new PollService();
            Polls = new ObservableCollection<Poll>(ps.GetAll());
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
