using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Users;
using System;

namespace AnimalShelter.Model.Requests
{
    public class TemporaryCareRequest : MemberRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Pet Pet { get; set; }
        public TemporaryCareRequest() { RequestType = RequestType.TEMPORARY_CARE; }

        public TemporaryCareRequest(int id, RequestType requestType, Member member, Pet pet, DateTime startDate, DateTime endDate)
        {
            Id = id;
            RequestType = requestType;
            Requester = member;
            Pet = pet;
            StartDate = startDate;
            EndDate = endDate;
        }

        public TemporaryCareRequest(Member member, Pet pet, DateTime startDate, DateTime endDate)
        {
            RequestType = RequestType.TEMPORARY_CARE;
            Requester = member;
            Pet = pet;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
