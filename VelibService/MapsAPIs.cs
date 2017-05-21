using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using log4net;
using log4net.Config;
using VelibService;

namespace VelibService
{
    public static class MapsAPIs
    {

        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(typeof(PlacesAPIs));

        // Ma clef perso (faut-il sortir ca en .conf pour plus tard ?)
        private static string key = "AIzaSyD0RXPsAcfkGFb6f5mVB9H61HvfAt6XLMI";
        private static string urlapi = "https://maps.googleapis.com/maps/api/";

        static MapsAPIs() {
            BasicConfigurator.Configure();
        }

        public static List<Coordinates> GetDirections(string origin, string destination, string transportType) {
            string url = urlapi + "directions/json?origin=" + origin + "&destination=" + destination + "&mode=" +
                         transportType + "&key=" + key;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse) response).StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JObject json = JObject.Parse(result);
            JArray steps = JArray.FromObject(json["routes"].First["legs"].First["steps"]);

            List<Coordinates> resultCoordinates = new List<Coordinates>();
            int i = 0;

            foreach (JObject step in steps) {
                Coordinates start = new Coordinates(step["start_location"]["lat"].Value<double>(),
                    step["start_location"]["lng"].Value<double>());
                Coordinates end = new Coordinates(step["end_location"]["lat"].Value<double>(),
                    step["start_location"]["lng"].Value<double>());
                Log.Debug(String.Format("Exctracted Coordinates #{0} [{2}] and #{1} [{3}]", i++, i++, start, end));
                resultCoordinates.Add(start);
                resultCoordinates.Add(end);
            }

            return resultCoordinates;
        }

        public static Coordinates GetCoordinates(string address)
        {
            string url = urlapi + "geocode/json?address=" + address + "&key=" + key;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JObject json = JObject.Parse(result);
            double lat = (double)json["results"].First["geometry"]["location"]["lat"];
            double lng = (double)json["results"].First["geometry"]["location"]["lng"];

            return new Coordinates(lat, lng);
        }

        public static async Task<Coordinates> GetCoordinatesAsync(string address)
        {
            string url = urlapi + "geocode/json?address=" + address + "&key=" + key;

            WebRequest request = WebRequest.CreateHttp(url);
            Log.Debug("Request sent : " + request);

            WebResponse response = await request.GetResponseAsync();
            Log.Debug("Response received : " + ((HttpWebResponse)response).StatusDescription);

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JObject json = JObject.Parse(result);
            double lat = (double)json["results"].First["geometry"]["location"]["lat"];
            double lng = (double)json["results"].First["geometry"]["location"]["lng"];

            Log.Debug("Coordinate : {" + lat + ", " + lng + "}");
            return new Coordinates(lat, lng);
        }
    }
}
