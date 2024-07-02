using System;
using System.Collections.Generic;

namespace AnimalShelter.Model.Votes
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime TimeLimit { get; set; }
        public int VotesFor { get; set; }
        public int VotesAgainst { get; set; }
        public List<int> Voters { get; set; }

        public Vote() 
        {
            TimeLimit = DateTime.Now.AddDays(7);
            VotesFor = 0;
            VotesAgainst = 0;
            Voters = new List<int>();
        }

        public Vote(int daysToVote)
        {
            TimeLimit = DateTime.Now.AddDays(daysToVote);
            VotesFor = 0;
            VotesAgainst = 0;
            Voters = new List<int>();
        }

        public Vote(int id, DateTime timeLimit, int votesFor, int votesAgainst, List<int> voters)
        {
            Id = id;
            TimeLimit = timeLimit;
            VotesFor = votesFor;
            VotesAgainst = votesAgainst;
            Voters = voters;
        }
    }
}
