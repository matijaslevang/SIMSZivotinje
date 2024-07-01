using AnimalShelter.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace AnimalShelter.GUI.View.Member
{
    public partial class PostRequest : Window
    {
        public PostRequest()
        {
            InitializeComponent();
            gender.Items.Add(Gender.MALE);
            gender.Items.Add(Gender.FEMALE);
            this.Show();
        }

    }
}
