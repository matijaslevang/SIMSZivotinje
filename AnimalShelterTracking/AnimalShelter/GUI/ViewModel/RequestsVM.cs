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

namespace AnimalShelter.GUI.ViewModel
{
    public class RequestsVM : INotifyPropertyChanged
    {
        public ICommand AcceptCommand { get; set; }
        public ICommand DeniedCommand { get; set; }
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

        public RequestsVM(PostBorders borders)
        {
            Borders = borders;
            Borders.HideAllBorders();
            AcceptCommand = new RelayCommand(AcceptClick);
            DeniedCommand = new RelayCommand(DeniedClick);

            requestController = new RequestController();
            Requests = new ObservableCollection<Request>(requestController.GetAll());
            for (int i = 0; i < Requests.Count; i++)
            {
                borders.Show(i);
                if (Requests[i].RequestType == RequestType.REGISTRATION)
                {
                    borders.Registered(i);
                }
            }

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

                case RequestType.POST:
                    if (Requests[i].Id == -1)
                    {
                        ToPost((PostRequest)Requests[i], true);
                        MessageBox.Show("The post has successfully been posted.", "Announcement");
                    }
                    else
                    {
                        ToPost((PostRequest)Requests[i], false);
                        MessageBox.Show("The post has successfully been updated.", "Announcement");
                    }

                    DeletePostRequest(i);
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
                case RequestType.POST:
                    DeletePostRequest(i);
                    MessageBox.Show("The post request successfully denied.", "Announcement");
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

        private void ToPost(PostRequest request, bool Add)
        {
            PostService service = new PostService();
            if (Add)
            {
                service.Add(request.Post);
            }
            else {
                service.Update(request.Post.Id, request.Post);
            }
        }

        private void DeleteRequest(int placeHolder)
        {
            requestController.Delete(Requests[placeHolder].Id, RequestType.REGISTRATION);
            
            Borders.Hide(placeHolder);
            MessageBox.Show(Requests[placeHolder].Id.ToString());

        }

        private void DeletePostRequest(int placeHolder)
        {
            requestController.Delete(Requests[placeHolder].Id, RequestType.POST);

            Borders.Hide(placeHolder);
            MessageBox.Show(Requests[placeHolder].Id.ToString());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

