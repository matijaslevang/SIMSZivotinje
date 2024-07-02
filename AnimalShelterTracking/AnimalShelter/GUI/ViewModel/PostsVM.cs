﻿using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Post;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class PostsVM: INotifyPropertyChanged
    {
        private ObservableCollection<Post> _posts;
        public PostService PostService { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public PostBorders Borders;
        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        private void UpdateCollection()
        {
            Borders.HideAllBorders();
            Posts = new ObservableCollection<Post>(PostService.GetAll());
            for (int i = 0; i < Posts.Count; i++)
            {
                Borders.Show(i);
                if (!Posts[i].Pet.IsAdopted)
                {
                    Borders.NotAdopted(i);
                }
            }
        }
        public PostsVM(PostBorders borders)
        {
            this.Borders = borders;
            this.PostService = new PostService();
            DeleteCommand = new RelayCommand(DeleteClick);
            UpdateCommand = new RelayCommand(UpdateClick);
            UpdateCollection();
            
        }
        public void DeleteClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            PostService.Delete(Posts[index].Id);
            UpdateCollection();
        }
        public void UpdateClick(object parameter)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
