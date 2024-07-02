﻿using AnimalShelter.GUI.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimalShelter.GUI.View
{
    public partial class MemberListPage : Page
    {
        public MemberListPage()
        {
            InitializeComponent();
            MembersVM memberVM = new MembersVM();
            DataContext = memberVM;
        }
    }
}
