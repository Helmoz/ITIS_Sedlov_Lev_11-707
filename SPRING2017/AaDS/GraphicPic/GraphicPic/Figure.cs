using System;
using System.Collections.Generic;

namespace GraphicPic
{
    public enum Figures
    {
        Rectangle = 1, Segment, Circle
    }

    public class Figure
    {
        public Figures Type { get;}
        public int Color { get;}
        public Point Top { get;}
        public Point Bottom { get;}
        public double Square => GetSquare();

        public Figure(int type, int topX, int topY, int bottomX, int bottomY, int color)
        {
            Type = (Figures)type;
            Top = new Point(topX, topY);
            Bottom = new Point(bottomX, bottomY);
            if (type == (int) Figures.Circle)
                Bottom.Y = 0;
            Color = color;
        }

        public Figure(int[] arr)
        {
            Type = (Figures)arr[0];
            Top = new Point(arr[1], arr[2]);
            Bottom = new Point(arr[3], arr[4]);
            if (arr[0] == (int)Figures.Circle)
                Bottom.Y = 0;
            Color = arr[5];
        }

        public double GetSquare()
        {
            switch (Type)
            {
                case Figures.Rectangle:
                    return Math.Abs(Bottom.X - Top.X) * Math.Abs(Bottom.Y - Top.Y);
                case Figures.Circle:
                    return Bottom.X * Bottom.X * Math.PI;
                case Figures.Segment:
                    return 0;
                default:
                    return double.NaN;
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case Figures.Circle:
                    return $"Type: {Type} \t| Center: ({Top.X};{Top.Y}) | Radius: {Bottom.X} | Color: #{Color} | Square: {Square:F2}";
                default:
                    return $"Type: {Type} | Top: ({Top.X};{Top.Y}) | Bottom: ({Bottom.X};{Bottom.Y}) | Color: #{Color} | Square: {Square:F2}";
            }
        }
        
        public bool Similar(Figure other)
        {
            return other != null
                   && Type == other.Type
                   && EqualityComparer<Point>.Default.Equals(Top, other.Top)
                   && EqualityComparer<Point>.Default.Equals(Bottom, other.Bottom);
        }

        public bool AreIntersected(Figure other)
        {
            switch (Type)
            {
                case Figures.Rectangle:
                    if (Top.X > other.Bottom.X &&
                        other.Top.X > Bottom.X &&
                        Top.Y > other.Bottom.Y &&
                        other.Top.Y > Bottom.Y)
                        return false;
                    return true;

                case Figures.Segment:
                    return Math.Min(other.Top.X, other.Bottom.X) <= Math.Max(Top.X, Bottom.X) &&
                           Math.Min(other.Top.Y, other.Bottom.Y) <= Math.Max(Top.Y, Bottom.Y) &&
                           Math.Max(other.Top.X, other.Bottom.X) >= Math.Min(Top.X, Bottom.X) &&
                           Math.Max(other.Top.Y, other.Bottom.Y) >= Math.Min(Top.Y, Bottom.Y);


                case Figures.Circle:
                    for (int i = other.Top.X; i <= other.Bottom.X; i++)
                        for (int j = other.Top.Y; j <= Math.Abs(other.Bottom.Y - other.Top.Y); j++)
                            if ((i - Top.X) * (i - Top.X) + (j - Top.Y) * (j - Top.Y) <= Bottom.X * Bottom.X)
                                return true;
                    break;
            }

            return false;
        }
    }
}