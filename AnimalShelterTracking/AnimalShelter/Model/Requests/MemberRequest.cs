using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Requests
{
    public abstract class MemberRequest
    {
        public Member Requester { get; set; }
    }
}
