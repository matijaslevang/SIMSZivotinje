using AnimalShelter.GUI.View.Member;
using AnimalShelter.Model.Enums;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Requests;
using AnimalShelter.Model.Users;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class PostRequestVM : INotifyPropertyChanged
    {
        private string _name;
        private int _age;
        private string _color;
        private Species _species;
        private Breed _breed;
        private string _newSpecies;
        private string _newBreed;
        private string _location;
        private string _healthDescription;
        private Gender _selectedGender;
        private HealthStatus _selectedHealthStatus;

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

        public Species Species
        {
            get { return _species; }
            set { _species = value; OnPropertyChanged(); }
        }

        public Breed Breed
        {
            get { return _breed; }
            set { _breed = value; OnPropertyChanged(); }
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
        public Member Member { get; set; }
        PostRequestWindow Window { get; set; }
        public ObservableCollection<Gender> GenderOptions { get; set; }
        public ObservableCollection<HealthStatus> HealthStatusOptions { get; set; }
        public ObservableCollection<Species> SpeciesOptions { get; set; }
        public ObservableCollection<Breed> BreedOptions { get; set; }

        public ICommand SendRequestCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public PostRequestVM(PostRequestWindow window, Member member)
        {
            Window = window;
            Member = member;
            GenderOptions = new ObservableCollection<Gender> { Gender.MALE, Gender.FEMALE};
            HealthStatusOptions = new ObservableCollection<HealthStatus> { HealthStatus.CHRONICALLY_ILL, HealthStatus.ILL, HealthStatus.DISABLED, HealthStatus.HEALTHY };
            SpeciesOptions = new ObservableCollection<Species>(); //TO-DO: POPUNITI PODACIMA
            BreedOptions = new ObservableCollection<Breed>(); //TO-DO: POPUNITI PODACIMA

            SendRequestCommand = new RelayCommand(SendRequestClick);
            CancelCommand = new RelayCommand(CancelClick);
        }

        private void SendRequestClick(object parameter)
        {
            if (NewSpecies != null || NewSpecies != "")
            {
                Species = new Species(NewSpecies);
            }

            if (NewBreed != null || NewBreed != "")
            {
                Breed = new Breed(NewBreed);
            }

            Pet pet = new Pet(Name, SelectedHealthStatus, HealthDescription, Age, SelectedGender, Color, Location, Species, Breed, null);
            Model.Posts.Post post = new Model.Posts.Post(Member, pet);
            PostRequest postRequest = new PostRequest(Member, post);
            MessageBox.Show("Post request sent successfully.");
            Window.Close();
        }

        private void CancelClick(object parameter)
        {
            Window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
