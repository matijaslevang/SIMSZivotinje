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

namespace AnimalShelter.GUI.ViewModel
{
    public class RequestsVM : INotifyPropertyChanged
    {
        public ICommand AcceptCommand { get; set; }

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
            borders.HideAllBorders();
            AcceptCommand = new RelayCommand(AcceptClick);
            RequestController requestController= new RequestController();
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


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

