using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using AnimalShelter.GUI.View;
using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Votes
{
    public class Poll : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public DateTime TimeLimit { get; set; }
        
        public bool IsBeingPromoted { get; set; }
        public ObservableCollection<int> VoterIdsFor { get; set; }
        public ObservableCollection<int> VoterIdsAgainst { get; set; }
        public int VotesFor => VoterIdsFor.Count;
        public int VotesAgainst => VoterIdsAgainst.Count;
        public Member VotingFor { get; set; }

        public Poll() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Poll(Member votingFor, bool isBeingPromoted) 
        {
            TimeLimit = DateTime.Now.AddDays(7);
            VoterIdsFor = new ObservableCollection<int>();
            VoterIdsAgainst = new ObservableCollection<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(Member votingFor, bool isBeingPromoted, int daysToVote)
        {
            TimeLimit = DateTime.Now.AddDays(daysToVote);
            VoterIdsFor = new ObservableCollection<int>();
            VoterIdsAgainst = new ObservableCollection<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(int id, DateTime timeLimit, ObservableCollection<int> voterIdsFor, ObservableCollection<int> voterIdsAgainst, Member votingFor, bool isBeingPromoted)
        {
            Id = id;
            TimeLimit = timeLimit;
            VoterIdsFor = voterIdsFor;
            VoterIdsAgainst = voterIdsAgainst;
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public bool HasVoted(int volunteerId)
        {
            return VoterIdsFor.Any(v => v == volunteerId) || VoterIdsAgainst.Any(v => v == volunteerId);
        }
    }
}
