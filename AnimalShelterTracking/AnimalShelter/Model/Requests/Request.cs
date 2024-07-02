using AnimalShelter.Model.Enums;

namespace AnimalShelter.Model.Requests
{
    public abstract class Request
    {
        public int Id { get; set; }
        public RequestType RequestType { get; set; }
    }
}
