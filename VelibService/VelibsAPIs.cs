using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Xml;
using System.Device.Location;
using System.Globalization;

namespace VelibService
{
    public class VelibsAPIs
    {
        private XmlNodeList stations;

        public VelibsAPIs()
        {
            this.stations = GetCarto();
        }

        private XmlNodeList GetCarto()
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            XmlNodeList elemList = doc.GetElementsByTagName("marker");

            reader.Close();
            response.Close();

            return elemList;
        }

        // Méthode générique qui permet de recup les infos station selon élément recherché
        // (exemple elemWanted peut être : available, free, total, ticket, ...)
        // voir ici : http://www.velib.paris/service/stationdetails/12152
        public int GetDetailsStation(string station, string elemWanted)
        {
            int result = 0;

            for (int i = 0; i < stations.Count; i++)
            {
                if (stations[i].Attributes["name"].Value.Contains(station))
                {
                    string numPoint = stations[i].Attributes["number"].Value;

                    WebRequest request_for_data = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + numPoint);

                    WebResponse response_for_data = request_for_data.GetResponse();
                    
                    Stream dataStream_for_data = response_for_data.GetResponseStream();
                    StreamReader reader_for_data = new StreamReader(dataStream_for_data);
                    string responseFromServer_for_data = reader_for_data.ReadToEnd();
                    
                    XmlDocument doc_for_data = new XmlDocument();
                    doc_for_data.LoadXml(responseFromServer_for_data);
                    XmlNodeList elemList_for_data = doc_for_data.GetElementsByTagName(elemWanted);

                    result = Int32.Parse(elemList_for_data[0].FirstChild.Value);

                    reader_for_data.Close();
                    response_for_data.Close();
                }
            }

            return result;
        }

        // Trouver la station la plus proche des coordonnées
        // disposant au moins d'un vélo au depart
        public Station GetNearStationWithBikes(Coordinates coord)
        {
            double maxDistance = Double.MaxValue;
            Station theNearestStation = null;

            for (int i = 0; i < stations.Count; i++)
            {
                double tempLat = Convert.ToDouble(stations[i].Attributes["lat"].Value, CultureInfo.InvariantCulture);
                double tempLng = Convert.ToDouble(stations[i].Attributes["lng"].Value, CultureInfo.InvariantCulture);

                var stationCoord = new GeoCoordinate(tempLat, tempLng);
                var currentCoord = new GeoCoordinate(coord.latitude, coord.longitude);

                double distance = stationCoord.GetDistanceTo(currentCoord);

                //int availableBikes = GetDetailsStation(elemList[i].Attributes["name"].Value, "available");
                int availableBikes = 1;

                if (distance < maxDistance && availableBikes > 0)
                {
                    theNearestStation = new Station(stations[i]);
                    maxDistance = distance;
                }
            }

            return theNearestStation;
        }

        // Trouver la station la plus proche des coordonnées
        // disposant au moins d'un emplacement libre
        public Station GetNearStationWithFreePlaces(Coordinates coord)
        {
            double maxDistance = Double.MaxValue;
            Station theNearestStation = null;

            for (int i = 0; i < stations.Count; i++)
            {
                double tempLat = Convert.ToDouble(stations[i].Attributes["lat"].Value, CultureInfo.InvariantCulture);
                double tempLng = Convert.ToDouble(stations[i].Attributes["lng"].Value, CultureInfo.InvariantCulture);

                var stationCoord = new GeoCoordinate(tempLat, tempLng);
                var currentCoord = new GeoCoordinate(coord.latitude, coord.longitude);

                double distance = stationCoord.GetDistanceTo(currentCoord);

                //int freePlaces = GetDetailsStation(elemList[i].Attributes["name"].Value, "free");
                int freePlaces = 1;

                if (distance < maxDistance && freePlaces > 0)
                {
                    theNearestStation = new Station(stations[i]);
                    maxDistance = distance;
                }
            }

            return theNearestStation;
        }
    }
}
