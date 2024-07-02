using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Requests
{
    public class AdoptionRequest : MemberRequest
    {
        public Pet Pet { get; set; }
        public AdoptionRequest() { RequestType = RequestType.TEMPORARY_CARE; }

        public AdoptionRequest(int id, RequestType requestType, Member member, Pet pet)
        {
            Id = id;
            RequestType = requestType;
            Requester = member;
            Pet = pet;
        }

        public AdoptionRequest(Member member, Pet pet)
        {
            RequestType = RequestType.ADOPTION;
            Requester = member;
            Pet = pet;
        }
    }
}
