using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace AnimalShelter.GUI.ViewModel.Helper
{
    public class PollReasons
    {
        public TextBlock reason1 { get; set; }
        public TextBlock reason2 { get; set; }
        public TextBlock reason3 { get; set; }
        public TextBlock reason4 { get; set; }
        public TextBlock reason5 { get; set; }
        public TextBlock reason6 { get; set; }
        public TextBlock reason7 { get; set; }
        public TextBlock reason8 { get; set; }
        public PollReasons(TextBlock reason1, TextBlock reason2, TextBlock reason3, TextBlock reason4, TextBlock reason5, TextBlock reason6, TextBlock reason7, TextBlock reason8)
        {
            this.reason1 = reason1;
            this.reason2 = reason2;
            this.reason3 = reason3;
            this.reason4 = reason4;
            this.reason5 = reason5;
            this.reason6 = reason6;
            this.reason7 = reason7;
            this.reason8 = reason8;
        }
        public List<TextBlock> ReasonsList()
        {
            List<TextBlock> list = new List<TextBlock>();
            list.Add(reason1);
            list.Add(reason2);
            list.Add(reason3);
            list.Add(reason4);
            list.Add(reason5);
            list.Add(reason6);
            list.Add(reason7);
            list.Add(reason8);
            return list;
        }
        public void IsBeingPromoted(int placeholder)
        {
            TextBlock textBlock = ReasonsList()[placeholder];
            textBlock.Text = "PROMOTE";
        }
        public void IsBeingDegraded(int placeholder)
        {
            TextBlock textBlock = ReasonsList()[placeholder];
            textBlock.Text = "KICK";
        }
    }
}
