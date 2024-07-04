using AnimalShelter.GUI.View;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Requests;
using AnimalShelter.Model.Users;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Model.Posts;
using Microsoft.Win32;

namespace AnimalShelter.GUI.ViewModel
{
    public class PostRequestVM : INotifyPropertyChanged
    {
        private const string IMAGE_FOLDER_PATH = "/GUI/Images/";

        private int _id;
        private string _name;
        private int _age;
        private string _color;
        private SpeciesWrapper _selectedSpecies;
        private BreedWrapper _selectedBreed;
        private string _newSpecies;
        private string _newBreed;
        private string _location;
        private string _healthDescription;
        private Gender _selectedGender;
        private HealthStatus _selectedHealthStatus;
        private string _uploadedFilePath;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(); }
        }

        public SpeciesWrapper SelectedSpecies
        {
            get { return _selectedSpecies; }
            set
            {
                _selectedSpecies = value;
                OnPropertyChanged();
                UpdateBreedOptions();
            }
        }

        public BreedWrapper SelectedBreed
        {
            get { return _selectedBreed; }
            set { _selectedBreed = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; OnPropertyChanged(); }
        }

        public string HealthDescription
        {
            get { return _healthDescription; }
            set { _healthDescription = value; OnPropertyChanged(); }
        }

        public Gender SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; OnPropertyChanged(); }
        }

        public HealthStatus SelectedHealthStatus
        {
            get { return _selectedHealthStatus; }
            set { _selectedHealthStatus = value; OnPropertyChanged(); }
        }

        public string NewSpecies
        {
            get { return _newSpecies; }
            set { _newSpecies = value; OnPropertyChanged(); }
        }

        public string NewBreed
        {
            get { return _newBreed; }
            set { _newBreed = value; OnPropertyChanged(); }
        }
        public string UploadedFilePath
        {
            get { return _uploadedFilePath; }
            set
            {
                _uploadedFilePath = value;
                OnPropertyChanged(nameof(UploadedFilePath));
            }
        }
        public Member Member { get; set; }
        public PostRequestWindow Window { get; set; }

        public ObservableCollection<GenderWrapper> GenderOptions { get; set; }
        public ObservableCollection<HealthStatusWrapper> HealthStatusOptions { get; set; }
        public ObservableCollection<SpeciesWrapper> SpeciesOptions { get; set; }
        public ObservableCollection<BreedWrapper> BreedOptions { get; set; }
        SpeciesService SpeciesService { get; set; }
        BreedService BreedService { get; set; }
        PostRequestService PostRequestService { get; set; }

        public ICommand SendRequestCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand UploadFileCommand { get; private set; }


        public PostRequestVM(PostRequestWindow window, Member member)
        {
            _id = -1;
            Window = window;
            Member = member;

            GenderOptions = new ObservableCollection<GenderWrapper>
            {
                new GenderWrapper { Value = Gender.MALE, DisplayName = Gender.MALE.Name() },
                new GenderWrapper { Value = Gender.FEMALE, DisplayName = Gender.FEMALE.Name() },
                new GenderWrapper { Value = Gender.OTHER, DisplayName = Gender.OTHER.Name() }
            };

            HealthStatusOptions = new ObservableCollection<HealthStatusWrapper>
            {
                new HealthStatusWrapper { Value = HealthStatus.HEALTHY, DisplayName = HealthStatus.HEALTHY.Name() },
                new HealthStatusWrapper { Value = HealthStatus.ILL, DisplayName = HealthStatus.ILL.Name() },
                new HealthStatusWrapper { Value = HealthStatus.CHRONICALLY_ILL, DisplayName = HealthStatus.CHRONICALLY_ILL.Name() },
                new HealthStatusWrapper { Value = HealthStatus.DISABLED, DisplayName = HealthStatus.DISABLED.Name() }
            };

            SpeciesService = new SpeciesService();
            BreedService = new BreedService();
            PostRequestService = new PostRequestService();

            List<Species> speciesList = SpeciesService.GetAll();
            SpeciesOptions = new ObservableCollection<SpeciesWrapper>(speciesList.Select(s => new SpeciesWrapper(s)));

            BreedOptions = new ObservableCollection<BreedWrapper>();
            UpdateBreedOptions();

            SendRequestCommand = new RelayCommand(SendRequestClick);
            CancelCommand = new RelayCommand(CancelClick);
            UploadFileCommand = new RelayCommand(UploadFile);
        }

        public PostRequestVM(PostRequestWindow window, Member member, Post post)
        {
            _id = post.Id;
            Window = window;
            Member = member;

            GenderOptions = new ObservableCollection<GenderWrapper>
            {
                new GenderWrapper { Value = Gender.MALE, DisplayName = Gender.MALE.Name() },
                new GenderWrapper { Value = Gender.FEMALE, DisplayName = Gender.FEMALE.Name() },
                new GenderWrapper { Value = Gender.OTHER, DisplayName = Gender.OTHER.Name() }
            };

            HealthStatusOptions = new ObservableCollection<HealthStatusWrapper>
            {
                new HealthStatusWrapper { Value = HealthStatus.HEALTHY, DisplayName = HealthStatus.HEALTHY.Name() },
                new HealthStatusWrapper { Value = HealthStatus.ILL, DisplayName = HealthStatus.ILL.Name() },
                new HealthStatusWrapper { Value = HealthStatus.CHRONICALLY_ILL, DisplayName = HealthStatus.CHRONICALLY_ILL.Name() },
                new HealthStatusWrapper { Value = HealthStatus.DISABLED, DisplayName = HealthStatus.DISABLED.Name() }
            };

            SpeciesService = new SpeciesService();
            BreedService = new BreedService();
            PostRequestService = new PostRequestService();

            List<Species> speciesList = SpeciesService.GetAll();
            SpeciesOptions = new ObservableCollection<SpeciesWrapper>(speciesList.Select(s => new SpeciesWrapper(s)));

            BreedOptions = new ObservableCollection<BreedWrapper>();
            UpdateBreedOptions();

            SendRequestCommand = new RelayCommand(SendRequestClick);
            CancelCommand = new RelayCommand(CancelClick);

            _name = post.Pet.Name;
            _age = post.Pet.Age;
            _color = post.Pet.Color;
            SelectedSpecies = new SpeciesWrapper(post.Pet.Species);
            SelectedBreed = new BreedWrapper(post.Pet.Breed);
            _location = post.Pet.Location;
            _healthDescription = post.Pet.HealthDescription;
            SelectedGender = post.Pet.Gender;
            SelectedHealthStatus = post.Pet.HealthStatus;

        }

        private void UpdateBreedOptions()
        {
            if (SelectedSpecies != null)
            {
                BreedService breedService = new BreedService();
                List<Breed> breeds = breedService.GetBySpeciesId(SelectedSpecies.Species.Id); 

                BreedOptions.Clear();
                foreach (var breed in breeds)
                {
                    BreedOptions.Add(new BreedWrapper(breed));
                }
            }
            else
            {
                BreedOptions.Clear();
            }
        }

        private void SendRequestClick(object parameter)
        {
            if (!string.IsNullOrEmpty(NewSpecies))
            {
                SelectedSpecies = new SpeciesWrapper(new Species(NewSpecies));
                SpeciesService.Add(SelectedSpecies.Species);
            }

            if (!string.IsNullOrEmpty(NewBreed))
            {
                SelectedBreed = new BreedWrapper(new Breed(NewBreed));
                BreedService.Add(SelectedBreed.Breed);
            }

            if (UploadedFilePath == null)
            {
                UploadedFilePath = IMAGE_FOLDER_PATH + "DefaultImage.jpg";
            }

            Pet pet = new Pet(Name, SelectedHealthStatus, HealthDescription, Age, SelectedGender, Color, Location, SelectedSpecies.Species, SelectedBreed.Breed, UploadedFilePath);
            Model.Posts.Post post = new Model.Posts.Post(Member, pet);
            PostRequest postRequest = new PostRequest(Member, post);
            if (_id == -1)
            {
                PostRequestService.Add(postRequest);
            }
            else
            {
                postRequest.Post.Id = _id;
                PostRequestService.Add(postRequest);
            }
            MessageBox.Show("Post request sent successfully.");
            Window.Close();
        }

        private void CancelClick(object parameter)
        {
            Window.Close();
        }
        private void UploadFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string[] imageSplit = openFileDialog.FileName.Split('\\');
                string image = imageSplit[imageSplit.Length - 1];

                UploadedFilePath = IMAGE_FOLDER_PATH + image;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
