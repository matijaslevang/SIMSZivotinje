using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Posts;
using AnimalShelter.Model.Requests;
using AnimalShelter.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AnimalShelter.Model.Users;
using System.Windows;
using System.Windows.Media;

namespace AnimalShelter.GUI.ViewModel
{
    public class RequestsVM : INotifyPropertyChanged
    {
        private const int PAGE_SIZE = 8;
        private int _totalPages;
        private int _currentPage = 1;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                    UpdateCollection();
                }
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            set
            {
                if (_totalPages != value)
                {
                    _totalPages = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AcceptCommand { get; set; }
        public ICommand DeniedCommand { get; set; }
        public ICommand PreviousPageCommand => new RelayCommand(PreviousPage);
        public ICommand NextPageCommand => new RelayCommand(NextPage);
        public PostBorders Borders { get; set; }
        public RequestController requestController { get; set; }

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged();
            }
        }

        private void UpdateCollection()
        {
            Borders.HideAllBorders();

            int startIndex = (CurrentPage - 1) * PAGE_SIZE;
            Requests = new ObservableCollection<Request>(new RequestController().GetAll().Skip(startIndex).Take(PAGE_SIZE));

            int totalRequestsCount = new RequestController().GetAll().Count;
            TotalPages = (int)Math.Ceiling((double)totalRequestsCount / PAGE_SIZE);

            for (int i = 0; i < Requests.Count; i++)
            {
                Borders.Show(i);
                if (Requests[i].RequestType == RequestType.REGISTRATION)
                {
                    Borders.Registered(i);
                }
            }
        }

        public RequestsVM(PostBorders borders)
        {
            Borders = borders;
            Borders.HideAllBorders();
            AcceptCommand = new RelayCommand(AcceptClick);
            DeniedCommand = new RelayCommand(DeniedClick);

            requestController = new RequestController();

            UpdateCollection();

        }
        private void AcceptClick(object parameter)
        {
            int i = Convert.ToInt32(parameter);
            switch (Requests[i].RequestType)
            {
                case RequestType.REGISTRATION:
                    ToMember((RegistrationRequest) Requests[i]);
                    DeleteRequest(i);
                    MessageBox.Show("The member successfully registered.", "Announcement");
                    break;

                default: break;
            }

        }

        private void DeniedClick(object parameter)
        {
            int i = Convert.ToInt32(parameter);
            switch (Requests[i].RequestType)
            {
                case RequestType.REGISTRATION:
                    DeleteRequest(i);
                    MessageBox.Show("The user successfully denied.", "Announcement");
                    break;

                default: break;
            }
        }

        private void ToMember(RegistrationRequest request)
        {
            UserService service = new UserService();
            int id = service.GenerateId();
            Account account = new Account(request.Email, request.Password, Role.MEMBER);

            Model.Users.Member member = new Model.Users.Member(id, account, request.Name, request.Surname, request.PhoneNumber, request.IdCardNumber, request.BirthDate, request.Gender);
            service.Add(member);
            
        }

        private void DeleteRequest(int placeHolder)
        {
            requestController.Delete(Requests[placeHolder].Id, RequestType.REGISTRATION);
            
            Borders.Hide(placeHolder);
            MessageBox.Show(Requests[placeHolder].Id.ToString());

        }
        private void PreviousPage(object parameter)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        private void NextPage(object parameter)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

