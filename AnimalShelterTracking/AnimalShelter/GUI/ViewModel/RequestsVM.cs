﻿using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Post;
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
        //public ICommand AcceptCommand { get; set; }

        //private ObservableCollection<Request> _requests;
        //public ObservableCollection<Request> Requests
        //{
        //    get => _requests;
        //    set
        //    {
        //        _requests = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public RequestsVM()//RequestBorders borders)
        //{
        //    AcceptCommand = new RelayCommand(AcceptClick);
        //borders.HideAllBorders();
        //RequestService requestService = new RequestService();
        //Requests = new ObservableCollection<Post>(requestService.GetAll());
        //for (int i = 0; i < Requests.Count; i++)
        //{
        //    borders.Show(i);
        //}

        //private void AcceptClick(object parameter)
        //{


        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //}
    }
}

