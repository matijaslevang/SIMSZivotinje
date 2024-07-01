using AnimalShelter.Repository;
using System.Collections.Generic;

namespace AnimalShelter.Model.Associations
{
    internal class AssociationService
    {
        private readonly IRepository<Payment> _repository;
        private const string filePath = "..../Data/Payments.json";

        public PaymentService()
        {
            _repository = new JSONRepository<Payment>(filePath);
        }

        public void Add(Payment newPayment)
        {
            _repository.Add(newPayment);
        }

        public void Update(int paymentId, Payment newPayment)
        {
            _repository.Update(paymentId, newPayment);
        }

        public Payment Get(int paymentId)
        {
            return _repository.Get(paymentId);
        }

        public void Delete(int paymentId)
        {
            _repository.Delete(paymentId);
        }

        public List<Payment> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
