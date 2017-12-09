using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Algorithms
    {
        private PointF RotateCenter(PointF center, float angle, PointF input)
        {
            const float RADIAN_PER_DEGREE = 0.0174532F;
            double ca = Math.Cos(-angle * RADIAN_PER_DEGREE);
            double sa = Math.Sin(-angle * RADIAN_PER_DEGREE);
            double rx1 = (center.X + (input.X - center.X) * ca - (input.Y - center.Y) * sa);
            double ry1 = (center.Y + (input.X - center.X) * sa + (input.Y - center.Y) * ca);
            return new PointF((float)rx1, (float)ry1);
        }
    }
}
