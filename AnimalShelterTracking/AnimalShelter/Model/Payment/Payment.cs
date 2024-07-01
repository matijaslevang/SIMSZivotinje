using AnimalShelter.Model.Enums;

namespace AnimalShelter.Model.Payment
{
    public class Payment
    { 
        public int Id { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }
        public string Reason { get; set; }
        public string Donor { get; set; }
        
        public Payment() { }

        public Payment(PaymentStatus status, double amount, string reason, string donor)
        {
            Status = status;
            Amount = amount;
            Reason = reason;
            Donor = donor;
        }
    }
}
