using AnimalShelter.Model.Enums;
using AnimalShelter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Requests
{
    public class RequestController
    {
        private readonly AdoptionRequestService _adoptionRequestService = new AdoptionRequestService();
        private readonly PostRequestService _postRequestService = new PostRequestService();
        private readonly TemporaryCareRequestService _temporaryCareRequestService = new TemporaryCareRequestService();
        private readonly RegistrationRequestService _registrationRequestService = new RegistrationRequestService();

        public RequestController() { }

        public void Add(Request newRequest)
        {
            if (newRequest.GetType() == typeof(AdoptionRequest))
            {
                _adoptionRequestService.Add((AdoptionRequest) newRequest);
            }
            else if (newRequest.GetType() == typeof(PostRequest))
            {
                _postRequestService.Add((PostRequest) newRequest);
            }
            else if (newRequest.GetType() == typeof(TemporaryCareRequest))
            {
                _temporaryCareRequestService.Add((TemporaryCareRequest) newRequest);
            }
            else if (newRequest.GetType() == typeof(RegistrationRequest))
            {
                _registrationRequestService.Add((RegistrationRequest) newRequest);
            }
        }

        public void Update(int requestId, Request newRequest)
        {
            if (newRequest.GetType() == typeof(AdoptionRequest))
            {
                _adoptionRequestService.Update(requestId, (AdoptionRequest) newRequest);
            }
            else if (newRequest.GetType() == typeof(PostRequest))
            {
                _postRequestService.Update(requestId, (PostRequest)newRequest);
            }
            else if (newRequest.GetType() == typeof(TemporaryCareRequest))
            {
                _temporaryCareRequestService.Update(requestId, (TemporaryCareRequest)newRequest);
            }
            else if (newRequest.GetType() == typeof(RegistrationRequest))
            {
                _registrationRequestService.Update(requestId, (RegistrationRequest)newRequest);
            }
        }

        public Request Get(int requestId, RequestType type)
        {
            if (type == RequestType.ADOPTION)
            {
                return _adoptionRequestService.Get(requestId);
            }
            if (type == RequestType.POST)
            {
                return _postRequestService.Get(requestId);
            }
            if (type == RequestType.TEMPORARY_CARE)
            {
                return _temporaryCareRequestService.Get(requestId);
            }
            return _registrationRequestService.Get(requestId);
            
        }

        public void Delete(int requestId, RequestType type)
        {
            if (type == RequestType.ADOPTION)
            {
                _adoptionRequestService.Get(requestId);
            }
            else if (type == RequestType.POST)
            {
                _postRequestService.Get(requestId);
            }
            else if (type == RequestType.TEMPORARY_CARE)
            {
                _temporaryCareRequestService.Get(requestId);
            }
            else
            {
                _registrationRequestService.Get(requestId);
            }

        }

        public List<Request> GetAll()
        {
            List<Request> allRequests = new List<Request>();

            allRequests.AddRange(_adoptionRequestService.GetAll());
            allRequests.AddRange(_postRequestService.GetAll());
            allRequests.AddRange(_temporaryCareRequestService.GetAll());
            allRequests.AddRange(_registrationRequestService.GetAll());

            return allRequests;
            
        }
    }
}
