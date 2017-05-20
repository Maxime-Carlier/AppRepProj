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
using VelibService.PlacesAPI;

namespace VelibService.MapsAPI
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

        public static void GetDirections(string origin, string destination, string transportType)
        {
            string url = urlapi + "directions/json?origin=" + origin + "&destination=" + destination + "&mode=" + transportType + "&key=" + key;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string result = reader.ReadToEnd();

            reader.Close();
            response.Close();

            JObject json = JObject.Parse(result);
            List<JToken> steps = json["routes"].First["legs"].First["steps"].Children().ToList();
            
            foreach (JToken step in steps)
            {
                // on a besoin de quoi ?? (voir ici https://developers.google.com/maps/documentation/directions/intro)
            }

            // return ?;
        }

        public static async Task<Coordinates> GetCoordinates(string address)
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
