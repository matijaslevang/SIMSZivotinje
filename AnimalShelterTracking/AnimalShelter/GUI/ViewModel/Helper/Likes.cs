using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Schema;

namespace AnimalShelter.GUI.ViewModel.Helper
{
    public class Likes
    {
        public Button like1 { get; set; }
        public Button like2 { get; set; }
        public Button like3 { get; set; }
        public Button like4 { get; set; }
        public Button like5 { get; set;}
        public Button like6 { get; set;}
        public Button like7 { get; set;}
        public Button like8 { get; set;}
        public Button like9 { get; set;}
        public Likes(Button like1, Button like2, Button like3, Button like4, Button like5, Button like6, Button like7, Button like8, Button like9)
        {
            this.like1 = like1;
            this.like2 = like2;
            this.like3 = like3;
            this.like4 = like4;
            this.like5 = like5;
            this.like6 = like6;
            this.like7 = like7;
            this.like8 = like8;
            this.like9 = like9;
        }
        public List<Button> ListLikes()
        {
            List<Button> likes = new List<Button>();
            likes.Add(like1);
            likes.Add(like2);
            likes.Add(like3);
            likes.Add(like4);
            likes.Add(like5);
            likes.Add(like6);
            likes.Add(like7);
            likes.Add(like8);
            likes.Add(like9);
            return likes;
        }
        public void RedHeart(int index)
        {
            Button button = ListLikes()[index];
            button.Foreground = Brushes.DarkRed;
        }
        public void RemoveRedHeart(int index)
        {
            Button button = ListLikes()[index];
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6f573c"));
            button.Foreground = brush;
        }
    }
}
