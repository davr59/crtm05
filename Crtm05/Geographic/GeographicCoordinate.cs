using System;

namespace Crtm05.Geographic
{
    public class GeographicCoordinate
    {
        public double Coordinate
        {
            get => coordinate;
            set => UpdateCoordinate(value);
        }

        public int Degrees
        {
            get => degrees;
            set
            {
                degrees = value;
                UpdateCoordinate();
            }
        }

        public int Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                UpdateCoordinate();
            }
        }

        public double Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                UpdateCoordinate();
            }
        }

        public GeographicCoordinate(double coordinate)
        {
            UpdateCoordinate(coordinate);
        }

        public GeographicCoordinate(int degrees, int minutes, double seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
            UpdateCoordinate();
        }

        double coordinate;
        int degrees;
        int minutes;
        double seconds;

        void UpdateDegreesMinutesSeconds()
        {
            degrees = (int)Math.Floor(coordinate);
            minutes = (int)Math.Floor((coordinate - degrees) * 60);
            seconds = (coordinate - degrees - ((double)minutes / 60)) * 3600;
        }

        void UpdateCoordinate()
        {
            coordinate = degrees + ((double)minutes / 60) + (seconds / 3600);
        }

        void UpdateCoordinate(double newCoordinate)
        {
            coordinate = newCoordinate;
            UpdateDegreesMinutesSeconds();
        }
    }
}
