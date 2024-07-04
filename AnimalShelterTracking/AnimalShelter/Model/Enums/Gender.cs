using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Enums
{
    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }
    public static class GenderExtensions
    {
        public static string Name(this Gender gender)
        {
            switch (gender)
            {
                case Gender.MALE:
                    return "Male";
                case Gender.FEMALE:
                    return "Female";
                case Gender.OTHER:
                    return "Unknown";
                default:
                    return "Unknown";
            }
        }
    }
    public class GenderWrapper
    {
        public Gender Value { get; set; }
        public string DisplayName { get; set; }
    }
}
