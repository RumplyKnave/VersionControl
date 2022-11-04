using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Abstractions;

namespace Xmas.Entities
{
    internal class PresentFactory : IToyFactory
    {
        public Color PresentColor1 { get; set; }
        public Color PresentColor2 { get; set; }

        public Toy CreateNew()
        {
            return new Present(PresentColor1, PresentColor2);
        }
    }
}
