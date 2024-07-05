using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Requests;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class PollsVM : INotifyPropertyChanged
    {
        private const int PAGE_SIZE = 8;
        private int _totalPages;
        private int _currentPage = 1;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                    UpdateCollection();
                }
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            set
            {
                if (_totalPages != value)
                {
                    _totalPages = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Poll> _polls;
        private PollService pollService;

        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand PreviousPageCommand => new RelayCommand(PreviousPage);
        public ICommand NextPageCommand => new RelayCommand(NextPage);

        public Volunteer Voter { get; set; }
        public PostBorders Borders { get; set; }
        //public Likes Likes { get; set; }


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
            Borders = borders;
            YesCommand = new RelayCommand(YesClick);
            NoCommand = new RelayCommand(NoClick);

            Voter = voter;
            pollService = new PollService();
            borders.HideAllBorders();

            int startIndex = (CurrentPage - 1) * PAGE_SIZE;
            Polls = new ObservableCollection<Poll>(pollService.GetAll().Skip(startIndex).Take(PAGE_SIZE));
            int totalRequestsCount = pollService.GetAll().Count;
            TotalPages = (int)Math.Ceiling((double)totalRequestsCount / PAGE_SIZE);

            List<Poll> finishedPolls = new List<Poll>();

            for (int i = 0;i< Polls.Count;i++)
            {
                if (DateTime.Now < Polls[i].TimeLimit)
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
                else
                {
                    finishedPolls.Add(Polls[i]);
                }
            }
            if (finishedPolls.Count > 0)
                ShowPollResults(finishedPolls);
        }

        private void ShowPollResults(List<Poll> polls)
        {
            string content = "";
            UserService userService = new UserService();

            foreach (Poll poll in polls)
            {
                if (poll.IsBeingPromoted)
                {
                    if (poll.VotesFor > poll.VotesAgainst)
                    {
                        content += "Member " + poll.VotingFor.Name + " (number " + poll.VotingFor.Id + ") became a volunteer.";

                        Member exMember = poll.VotingFor;
                        userService.Delete(exMember.Id);
                        exMember.Account.Role = Model.Enums.Role.VOLUNTEER;
                        Volunteer newVol = new Volunteer(exMember.Account, exMember.Name, exMember.Surname, exMember.PhoneNumber, exMember.IdCardNumber, exMember.BirthDate, exMember.Gender);

                        userService.Add(newVol);
                    }
                    else
                        content += "Member " + poll.VotingFor.Name + " (number " + poll.VotingFor.Id + ") rejected as a volunteer.";
                    ;
                    content += "\n - Voted for: " + poll.VotesFor +
                            "\n - Voted against: " + poll.VotesAgainst + "\n";
                   
                    pollService.Delete(poll.Id);
                }
            }
            MessageBox.Show(content, "Poll results");
        }

        private void YesClick(object parameter)
        {
            int i = Convert.ToInt32(parameter);
            Poll poll = Polls[i];
            int id = poll.Id;

            if (!poll.VoterIdsFor.Contains(Voter.Id))
            {
                poll.VoterIdsFor.Add(Voter.Id);
                pollService.Update(id, poll);
            }

            if (poll.VoterIdsAgainst.Contains(Voter.Id))
            {
                poll.VoterIdsAgainst.Remove(Voter.Id);
                pollService.Update(id, poll);
            }
            UpdateCollection();
        }

        private void NoClick(object parameter)
        {
            int i = Convert.ToInt32(parameter);
            Poll poll = Polls[i];
            int id = poll.Id;

            if (!poll.VoterIdsAgainst.Contains(Voter.Id))
            {
                poll.VoterIdsAgainst.Add(Voter.Id);
                pollService.Update(id, poll);
            }

            if (poll.VoterIdsFor.Contains(Voter.Id))
            {
                poll.VoterIdsFor.Remove(Voter.Id);
                pollService.Update(id, poll);
            }
            UpdateCollection();
        }

        public void UpdateCollection()
        {
            Borders.HideAllBorders();
            int startIndex = (CurrentPage - 1) * PAGE_SIZE;
            Polls = new ObservableCollection<Poll>(pollService.GetAll().Skip(startIndex).Take(PAGE_SIZE));

            int totalRequestsCount = pollService.GetAll().Count;
            TotalPages = (int)Math.Ceiling((double)totalRequestsCount / PAGE_SIZE);

            for (int i = 0; i < Polls.Count; i++)
            {
                Borders.Show(i);
            } 
        }

        private void PreviousPage(object parameter)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        private void NextPage(object parameter)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
