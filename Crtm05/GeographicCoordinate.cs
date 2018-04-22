using System;

namespace Crtm05
{
    public class GeographicCoordinate
    {
        public double Coordinate
        {
            get
            {
                return coordinate;
            }
            set
            {
                coordinate = value;
                UpdateDegreesMinutesSeconds();
            }
        }

        public int Degrees
        {
            get
            {
                return degrees;
            }
            set
            {
                degrees = value;
                UpdateCoordinate();
            }
        }

        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
                UpdateCoordinate();
            }
        }

        public double Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;
                UpdateCoordinate();
            }
        }

        double coordinate;
        int degrees;
        int minutes;
        double seconds;

        public GeographicCoordinate(double coordinate)
        {
            Coordinate = coordinate;
        }

        public GeographicCoordinate(int degrees, int minutes, double seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
            UpdateCoordinate();
        }

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
    }
}
