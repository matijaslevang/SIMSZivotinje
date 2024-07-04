using AnimalShelter.GUI.View;
using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Requests;
using AnimalShelter.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class TemporaryCareRequestVM: INotifyPropertyChanged
    {
        public Pet Pet;
        public Member Member { get; set; }
        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public TemporaryCareRequestWindow Window { get; set; }
        public RequestController RequestController { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public TemporaryCareRequestVM(TemporaryCareRequestWindow window, Pet pet, Member member)
        {
            Window = window;
            Pet = pet;
            Member = member;
            RequestController = new RequestController();
            AcceptCommand = new RelayCommand(AcceptClick);
            CancelCommand = new RelayCommand(CancelClick);
        }
        public void AcceptClick(object parameter)
        {
            TemporaryCareRequest temporaryCareRequest = new TemporaryCareRequest(Member, Pet, StartDate, EndDate);
            RequestController.Add(temporaryCareRequest);
            MessageBox.Show("Temporary care request has been sent successfully.");
            Window.Close();
        }
        public void CancelClick(object parameter)
        {
            Window.Close();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
