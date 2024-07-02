using AnimalShelter.GUI.ViewModel.Helper;
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

namespace AnimalShelter.GUI.ViewModel
{
    public class PostsVM: INotifyPropertyChanged
    {
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public PostsVM(PostBorders borders)
        {
            borders.HideAllBorders();
            PostService postService = new PostService();
            Posts = new ObservableCollection<Post>(postService.GetAll());
            for (int i = 0; i < Posts.Count; i++)
            {
                borders.Show(i);
                if (!Posts[i].Pet.IsAdopted)
                {
                    borders.NotAdopted(i);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
