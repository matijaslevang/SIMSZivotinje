﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AnimalShelter.GUI.ViewModel;
using AnimalShelter.GUI.ViewModel.Helper;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{
    public partial class GuestWindow : Window
    {
        public GuestWindow()
        {
            InitializeComponent();
            PostBorders borders = new PostBorders(Border1, Border2, Border3, Border4, Border5, Border6, Border7, Border8, Border9);
            PostsVM postsVM = new PostsVM(borders);
            DataContext = postsVM;
        }
    }
}
