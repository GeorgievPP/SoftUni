using System;

namespace P01.ClassBoxData
{
    public class Box
    {

        private const double SIDE_MIN_VALUE = 0;
        //private const string INVALID_SIDE = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;


        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Heigth = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value <= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }

        }

        public double Heigth
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= SIDE_MIN_VALUE)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double CalculateLateralSurfaceArea()
        {
            double lateralSurfaceArea = (2 * this.Length * this.Heigth)
                + (2 * this.Width * this.Heigth);

            return lateralSurfaceArea;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Heigth;

            return volume;
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = (2 * this.Length * this.Width)
                + (2 * this.Length * this.Heigth)
                + (2 * this.Width * this.Heigth);

            return surfaceArea;
        }

       /* private void ValidateSide(double value, string sideName)
        {
            if(value <= SIDE_MIN_VALUE)
            {
                throw new ArgumentException(String.Format(INVALID_SIDE, sideName));
            }

        }
       */

    }
}
