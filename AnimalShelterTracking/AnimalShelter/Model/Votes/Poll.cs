using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.GUI.View;
using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Votes
{
    public class Poll
    {
        public int Id { get; set; }
        public DateTime TimeLimit { get; set; }
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
        public Member VotingFor { get; set; }
        public bool IsBeingPromoted { get; set; }
        public List<int> Voters { get; set; }
        public Poll() { }

        public Poll(Member votingFor, bool isBeingPromoted) 
        {
            TimeLimit = DateTime.Now.AddDays(7);
            VotesFor = 0;
            VotesAgainst = 0;
            Voters = new List<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(Member votingFor, bool isBeingPromoted, int daysToVote)
        {
            TimeLimit = DateTime.Now.AddDays(daysToVote);
            VotesFor = 0;
            VotesAgainst = 0;
            Voters = new List<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(int id, DateTime timeLimit, int votesFor, int votesAgainst, List<int> voters, Member votingFor, bool isBeingPromoted)
        {
            Id = id;
            TimeLimit = timeLimit;
            VotesFor = votesFor;
            VotesAgainst = votesAgainst;
            Voters = voters;
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public bool HasVoted(int volunteerId)
        {
            return Voters.Any(v => v == volunteerId);
        }
    }
}
