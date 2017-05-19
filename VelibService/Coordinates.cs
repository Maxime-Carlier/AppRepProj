using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibService
{
    class Coordinates
    {
        public double latitude;
        public double longitude;

        public Coordinates(double lat, double lng)
        {
            latitude = lat;
            longitude = lng;
        }
    }
}
