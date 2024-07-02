using AnimalShelter.Model.Users;
using AnimalShelter.Model.Utilities;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Windows.Documents;

namespace AnimalShelter.Model
{
    public class Association
    {
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public List<Volunteer> Volunteers { get; set; }

        public Association() { }

        public Association(Address address, Contact contact, List<Volunteer> volunteers)
        {
            Address = address;
            Contact = contact;
            Volunteers = volunteers;
        }

        public Association(Address address, Contact contact, Volunteer firstVolunteer)
        {
            Address = address;
            Contact = contact;
            Volunteers = new List<Volunteer>
            {
                firstVolunteer
            };
        }

        public void AddVolunteer(Volunteer volunteer)
        {
            Volunteers.Add(volunteer);
        }

        public bool RemoveVolunteer(Volunteer volunteer)
        {
            return Volunteers.Remove(volunteer);
        }

    }
}
