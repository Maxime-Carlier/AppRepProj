using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace VelibService
{
    class MapsAPIs
    {
        // Ma clef perso (faut-il sortir ca en .conf pour plus tard ?)
        private String key = "AIzaSyD0RXPsAcfkGFb6f5mVB9H61HvfAt6XLMI";

        public void GetDirections(string origin, string destination)
        {
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;

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

        public Coordinates GetCoordinates(string address)
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + key;

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
    }
}
