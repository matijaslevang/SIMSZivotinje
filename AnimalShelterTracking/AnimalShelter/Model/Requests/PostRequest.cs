using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Posts;
using AnimalShelter.Model.Users;

namespace AnimalShelter.Model.Requests
{
    public class PostRequest : MemberRequest
    {
        public Post Post { get; set; }
        public PostRequest() { RequestType = RequestType.POST; }

        public PostRequest(Member requester, Post post) 
        {
            RequestType = RequestType.POST;
            Post = post;
            Requester = requester;
        }

        public PostRequest(int id, RequestType requestType, Member requester, Post post)
        {
            Id = id;
            RequestType = requestType;
            Requester = requester;
            Post = post;
        }
    }
}
