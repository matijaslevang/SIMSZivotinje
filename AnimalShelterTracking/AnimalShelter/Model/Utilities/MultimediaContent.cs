using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Model.Utilities
{
    public class MultimediaContent
    {
        public string Path { get; set; }

        public MultimediaContent() { }

        public MultimediaContent(string path)
        {
            Path = path;
        }
    }
}
