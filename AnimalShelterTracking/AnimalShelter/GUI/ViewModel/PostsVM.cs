using AnimalShelter.GUI.View;
using AnimalShelter.GUI.View.Member;
using AnimalShelter.Model.Users;
using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Posts;
using AnimalShelter.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class PostsVM: INotifyPropertyChanged
    {
        private const int PAGE_SIZE = 9;
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

        private ObservableCollection<Post> _posts;
        public PostService PostService { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand AdoptCommand { get; set; }
        public ICommand TemporaryCareCommand { get; set; }
        public ICommand PostRequestCommand { get; set; }
        public ICommand CommentCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand PreviousPageCommand => new RelayCommand(PreviousPage);
        public ICommand NextPageCommand => new RelayCommand(NextPage);
        public PostBorders Borders;
        public Likes Likes { get; set; }
        public Member Member;
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
            
            int startIndex = (CurrentPage - 1) * PAGE_SIZE;
            Posts = new ObservableCollection<Post>(PostService.GetAll().Skip(startIndex).Take(PAGE_SIZE));

            int totalPostsCount = PostService.GetAll().Count;
            TotalPages = (int)Math.Ceiling((double)totalPostsCount / PAGE_SIZE);

            for (int i = 0; i < Posts.Count; i++)
            {
                Borders.Show(i);
                if (Posts[i].Pet.AdoptionStatus == AdoptionStatus.NOT_ADOPTED)
                {
                    Borders.NotAdopted(i);
                }
                if (Member != null && Posts[i].IsLikedByUser(Member.Id))
                {
                    Likes.RedHeart(i);
                }
                if (Member != null && !Posts[i].IsLikedByUser(Member.Id))
                {
                    Likes.RemoveRedHeart(i);
                }
            }
        }

        public PostsVM(PostBorders borders, Member member, Likes likes)
        {
            this.Borders = borders;
            this.Likes = likes;
            this.PostService = new PostService();
            this.Member = member;
            DeleteCommand = new RelayCommand(DeleteClick);
            UpdateCommand = new RelayCommand(UpdateClick);
            AdoptCommand = new RelayCommand(AdoptClick);
            TemporaryCareCommand = new RelayCommand(TemporaryCareClick);
            PostRequestCommand = new RelayCommand(PostRequestClick);
            CommentCommand = new RelayCommand(CommentClick);
            LikeCommand = new RelayCommand(LikeClick);
            UpdateCollection();
            
        }
        public void LikeClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            PostService postService = new PostService();
            if (Member != null && !Posts[index].IsLikedByUser(Member.Id))
            {
                Posts[index].AddLike(Member.Id);
                postService.Update(Posts[index].Id, Posts[index]);
                Likes.RedHeart(index);
            }
            else if (Member != null && Posts[index].IsLikedByUser(Member.Id))
            {
                Posts[index].RemoveLike(Member.Id);
                postService.Update(Posts[index].Id, Posts[index]);
                Likes.RemoveRedHeart(index);
            }
            UpdateCollection();

           
        }
        public void CommentClick(object parameter)
        {
            if (Member != null)
            {
                int index = int.Parse(parameter.ToString());
                CommentWindow commentWindow = new CommentWindow();
                commentWindow.Show();
            }
        }
        public void DeleteClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            PostService.Delete(Posts[index].Id);

            if (Posts.Count == 1 && CurrentPage > 1)
            {
                CurrentPage--;
            }
            UpdateCollection();
        }
        public void UpdateClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            PostRequestWindow postRequestWindow = new PostRequestWindow(Posts[index], Member);
            postRequestWindow.Show();
        }
        public void AdoptClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            AdoptionRequestWindow adoptionRequestWindow = new AdoptionRequestWindow(Posts[index], Member);
            adoptionRequestWindow.Show();
        }
        public void TemporaryCareClick(object parameter)
        {
            int index = int.Parse(parameter.ToString());
            TemporaryCareRequestWindow temporaryCareRequestWindow = new TemporaryCareRequestWindow(Posts[index], Member);
            temporaryCareRequestWindow.Show();
        }
        public void PostRequestClick(object parameter)
        {
            PostRequestWindow postRequestWindow = new PostRequestWindow(Member);
            postRequestWindow.Show();
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
