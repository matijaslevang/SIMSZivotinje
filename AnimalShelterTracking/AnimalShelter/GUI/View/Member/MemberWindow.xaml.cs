using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{
    public partial class MemberWindow : Window
    {
        public MemberWindow()
        {
            InitializeComponent();
            Homepage homepage = new Homepage();
            frame.Navigate(homepage);
            homepage.delete1.Visibility = Visibility.Collapsed;
            homepage.update1.Visibility = Visibility.Collapsed;

            homepage.delete2.Visibility = Visibility.Collapsed;
            homepage.update2.Visibility = Visibility.Collapsed;

            homepage.delete3.Visibility = Visibility.Collapsed;
            homepage.update3.Visibility = Visibility.Collapsed;

            homepage.delete4.Visibility = Visibility.Collapsed;
            homepage.update4.Visibility = Visibility.Collapsed;

            homepage.delete5.Visibility = Visibility.Collapsed;
            homepage.update5.Visibility = Visibility.Collapsed;

            homepage.delete6.Visibility = Visibility.Collapsed;
            homepage.update6.Visibility = Visibility.Collapsed;

            homepage.delete7.Visibility = Visibility.Collapsed;
            homepage.update7.Visibility = Visibility.Collapsed;

            homepage.delete8.Visibility = Visibility.Collapsed;
            homepage.update8.Visibility = Visibility.Collapsed;

            homepage.delete9.Visibility = Visibility.Collapsed;
            homepage.update9.Visibility = Visibility.Collapsed;
        }
    }
}
