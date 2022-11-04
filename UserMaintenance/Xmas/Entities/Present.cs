using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Abstractions;

namespace Xmas.Entities
{
    public class Present : Toy
    {
        public SolidBrush PresentColor1 { get; private set; }
        public SolidBrush PresentColor2 { get; private set; }

        public Present(Color color1, Color color2)
        {
            PresentColor1 = new SolidBrush(color1);
            PresentColor2 = new SolidBrush(color2);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(PresentColor1, 0, 0, Width, Height);
            g.FillRectangle(PresentColor2, 20, 0, 10, 50);
            g.FillRectangle(PresentColor2, 0, 20, 50, 10);

        }

    }
}
