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
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class AdoptionRequestVM: INotifyPropertyChanged
    {
        public Pet Pet { get; set; }
        public Member Member {  get; set; }
        public AdoptionRequestWindow Window { get; set; }
        public RequestController RequestController { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public AdoptionRequestVM(AdoptionRequestWindow window, Pet pet) 
        {
            Window = window;
            Pet = pet;
            RequestController = new RequestController();
            AcceptCommand = new RelayCommand(AcceptClick);
            CancelCommand = new RelayCommand(CancelClick);
        }
        public void AcceptClick(object parameter)
        {
            AdoptionRequest adoptionRequest = new AdoptionRequest(Member, Pet);
            RequestController.Add(adoptionRequest);
            MessageBox.Show("Adoption request has been sent successfully.");
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
