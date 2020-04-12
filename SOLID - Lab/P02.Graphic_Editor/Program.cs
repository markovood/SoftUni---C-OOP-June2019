using System;

namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            var square = new Square();
            var circle = new Circle();
            var rectangle = new Rectangle();

            var ge = new GraphicEditor();
            ge.DrawShape(square);
            ge.DrawShape(circle);
            ge.DrawShape(rectangle);
        }
    }
}
