using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimalShelter.GUI.ViewModel
{
    public class AdoptionRequestVM: INotifyPropertyChanged
    {
        public Pet Pet { get; set; }
        public RequestService RequestService { get; set; }
        public ICommand AcceptCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public AdoptionRequestVM(Pet pet) 
        {
            Pet = pet;
            RequestService = new RequestService();
            AcceptCommand = new RelayCommand(AcceptClick);
        }
        public void AcceptClick(object parameter)
        {
           //TO-DO: IMPLEMEMT ADD(REQUEST)
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
