namespace AnimalShelter.Model.Enums
{
    public enum HealthStatus
    {
        HEALTHY,
        ILL,
        CHRONICALLY_ILL,
        DISABLED
    }
    public static class HealthStatusExtensions
    {
        public static string Name(this HealthStatus healthStatus)
        {
            switch (healthStatus)
            {
                case HealthStatus.CHRONICALLY_ILL:
                    return "Chronically Ill";
                case HealthStatus.ILL:
                    return "Ill";
                case HealthStatus.DISABLED:
                    return "Disabled";
                case HealthStatus.HEALTHY:
                    return "Healthy";
                default:
                    return "Unknown";
            }
        }
    }
    public class HealthStatusWrapper
    {
        public HealthStatus Value { get; set; }
        public string DisplayName { get; set; }
    }
}
