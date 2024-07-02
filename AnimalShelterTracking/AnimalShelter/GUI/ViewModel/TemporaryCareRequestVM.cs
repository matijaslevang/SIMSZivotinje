using AnimalShelter.Model.Pets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.GUI.ViewModel
{
    public class TemporaryCareRequestVM: INotifyPropertyChanged
    {
        public Pet pet;

        public event PropertyChangedEventHandler PropertyChanged;
        public TemporaryCareRequestVM()
        {

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
