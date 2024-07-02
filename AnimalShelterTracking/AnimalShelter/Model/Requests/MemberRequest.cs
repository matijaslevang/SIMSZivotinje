using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Requests
{
    public abstract class MemberRequest : Request
    {
        public Member Requester { get; set; }

    }
}
