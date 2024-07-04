using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace AnimalShelter.GUI.ViewModel.Helper
{
    public class PostBorders
    {
        public Border Border1 { get; set; }
        public Border Border2 { get; set; }
        public Border Border3 { get; set; }
        public Border Border4 { get; set; }
        public Border Border5 { get; set; }
        public Border Border6 { get; set; }
        public Border Border7 { get; set; }
        public Border Border8 { get; set; }
        public Border Border9 { get; set; }

        public PostBorders(Border border1, Border border2, Border border3, Border border4, Border border5,
                             Border border6, Border border7, Border border8, Border border9)
        {
            Border1 = border1;
            Border2 = border2;
            Border3 = border3;
            Border4 = border4;
            Border5 = border5;
            Border6 = border6;
            Border7 = border7;
            Border8 = border8;
            Border9 = border9;
        }

        public void HideAllBorders()
        {
            Border1.Visibility = Visibility.Collapsed;
            Border2.Visibility = Visibility.Collapsed;
            Border3.Visibility = Visibility.Collapsed;
            Border4.Visibility = Visibility.Collapsed;
            Border5.Visibility = Visibility.Collapsed;
            Border6.Visibility = Visibility.Collapsed;
            Border7.Visibility = Visibility.Collapsed;
            Border8.Visibility = Visibility.Collapsed;
            if (Border9 != null)
            {
                Border9.Visibility = Visibility.Collapsed;
            }
        }

        public void Hide(int placeholder)
        {
            Border border = BordersList()[placeholder];
            border.Visibility = Visibility.Collapsed;
        }

        public void Show(int placeholder)
        {
            Border border = BordersList()[placeholder];
            border.Visibility = Visibility.Visible;
        }

        public List<Border> BordersList()
        {
            List<Border> list = new List<Border>();
            list.Add(Border1);
            list.Add(Border2);
            list.Add(Border3);
            list.Add(Border4);
            list.Add(Border5);
            list.Add(Border6);
            list.Add(Border7);
            list.Add(Border8);
            list.Add(Border9);
            return list;
        }
        public void NotAdopted(int placeholder)
        {
            Border border = BordersList()[placeholder];
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6f1d1b"));
            border.Background = brush;
        }
        public void Registered(int placeholder)
        {
            Border border = BordersList()[placeholder];
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc389"));
            border.Background = brush;
        }
        public void NotRegistered(int placeholder)
        {
            Border border = BordersList()[placeholder];
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b98e64"));
            border.Background = brush;
        }
    }

}
