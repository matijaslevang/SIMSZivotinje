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
        public List<int> VoterIdsFor { get; set; }
        public List<int> VoterIdsAgainst { get; set; }

        public Poll() { }

        public Poll(Member votingFor, bool isBeingPromoted) 
        {
            TimeLimit = DateTime.Now.AddDays(7);
            VotesFor = 0;
            VotesAgainst = 0;
            VoterIdsFor = new List<int>();
            VoterIdsAgainst = new List<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(Member votingFor, bool isBeingPromoted, int daysToVote)
        {
            TimeLimit = DateTime.Now.AddDays(daysToVote);
            VotesFor = 0;
            VotesAgainst = 0;
            VoterIdsFor = new List<int>();
            VoterIdsAgainst = new List<int>();
            VotingFor = votingFor;
            IsBeingPromoted = isBeingPromoted;
        }

        public Poll(int id, DateTime timeLimit, int votesFor, int votesAgainst, List<int> voterIdsFor, List<int> voterIdsAgainst, Member votingFor, bool isBeingPromoted)
        {
            Id = id;
            TimeLimit = timeLimit;
            VotesFor = votesFor;
            VotesAgainst = votesAgainst;
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
