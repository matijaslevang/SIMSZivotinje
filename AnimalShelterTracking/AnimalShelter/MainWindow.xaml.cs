using System.Windows;
using AnimalShelter.GUI.View;
using AnimalShelter.GUI.View.Member;

namespace AnimalShelter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //RegistrationRequest regReq = new RegistrationRequest();
            //regReq.Show();
            PostRequest postReq = new PostRequest();
            postReq.Show();
            //GuestWindow guestWindow = new GuestWindow();
            //guestWindow.Show();

        }
    }
}
