using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AnimalShelter.GUI.ViewModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnimalShelter.GUI.ViewModel.Helper;
using AnimalShelter.Model.Users;


namespace AnimalShelter.GUI.View
{
    public partial class VotingPage : Page
    {
        public VotingPage(Volunteer volunteer)
        {
            InitializeComponent();
            PostBorders borders = new PostBorders(Border1, Border2, Border3, Border4, Border5, Border6, Border7, Border8, null);
            PollReasons reasons = new PollReasons(reason1, reason2, reason3, reason4, reason5, reason6, reason7, reason8);
            PollsVM pollvm = new PollsVM(borders, reasons, volunteer);
            DataContext = pollvm;
        }
    }
}
