using AnimalShelter.Model.Pets;
using AnimalShelter.Model.Posts;
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
        public Pet pet;

        public event PropertyChangedEventHandler PropertyChanged;
        public AdoptionRequestVM() 
        {
            
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
