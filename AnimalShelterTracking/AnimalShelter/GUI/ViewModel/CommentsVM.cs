using AnimalShelter.GUI.View.Member;
using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Posts;
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
using System.Windows.Media;

namespace AnimalShelter.GUI.ViewModel
{
    public class CommentsVM : INotifyPropertyChanged
    {
        private ObservableCollection<Comment> _comments;
        public CommentWindow CommentWindow {  get; set; }
        public ICommand BackCommand { get; set; }
        public ObservableCollection<Comment> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }
        public CommentsVM(PostBorders borders, CommentWindow commentWindow)
        {
            CommentWindow = commentWindow;
            BackCommand = new RelayCommand(BackClick);
            borders.HideAllBorders();
            CommentService cs = new CommentService();
            Comments = new ObservableCollection<Comment>(cs.GetAll());
            for (int i = 0; i < Comments.Count; i++)
            {
                borders.Show(i);
            }
        }

        public void BackClick(object parameter)
        {
            CommentWindow.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
