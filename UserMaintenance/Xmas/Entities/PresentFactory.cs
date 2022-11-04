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
        public Color PresentColor { get; set; }

        public Toy CreateNew()
        {
            return new Present(PresentColor);
        }
    }
}
