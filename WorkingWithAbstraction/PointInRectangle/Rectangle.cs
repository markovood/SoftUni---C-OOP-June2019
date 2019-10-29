using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool insideByX = point.CoordinateX >= this.TopLeft.CoordinateX &&
                            point.CoordinateX <= this.BottomRight.CoordinateX;

            bool isInsideByY = point.CoordinateY >= this.TopLeft.CoordinateY &&
                            point.CoordinateY <= this.BottomRight.CoordinateY;

            return insideByX && isInsideByY;
        }
    }
}
