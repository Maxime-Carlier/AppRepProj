using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using Newtonsoft.Json.Linq;

namespace VelibService.PlacesAPI {
    public static class PlacesAPIs {

        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(typeof(PlacesAPIs));

        private static readonly string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json";
        private static readonly string key = "AIzaSyCumpMGwKBTp9BtHLL0q7hvBbEtdg-FMGA";

        static PlacesAPIs() {
            BasicConfigurator.Configure();
        }

        public static async Task<List<string>> getAutoCompleteAsync(string input) {
            //string placesRequest = url + "?input=" + input +
            //                       "&types=geocode&location=48.856127,2.351332&radius=10000&strictbound&key=" + key;

            //WebRequest request = WebRequest.Create(placesRequest);
            //Log.Debug("Request sent : "+placesRequest);
            //WebResponse response = request.GetResponse();
            //Log.Debug("Response Status : "+ ((HttpWebResponse)response).StatusDescription);

            //JObject json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

            //// Parse the response to get suggestions
            //AutoCompleteStringCollection suggestions = new AutoCompleteStringCollection();
            //string debugresult = "{";
            //foreach(JObject current in json["predictions"]) {
            //    debugresult += "\""+current["description"]+"\", ";
            //    suggestions.Add(current["description"].ToString());
            //}
            //if (debugresult.Length > 3) {
            //    debugresult = debugresult.Remove(debugresult.Length - 2);
            //}

            //debugresult += "}";
            //Log.Debug("Suggestions : "+debugresult);

            //return suggestions;

            //      #################
            //      # ASYNC VERSION #
            //      #################

            string placesRequest = url + "?input=" + input +
                                   "&types=geocode&location=48.856127,2.351332&radius=10000&strictbound&key=" + key;

            WebRequest request = WebRequest.CreateHttp(placesRequest);
            Log.Debug("Request sent : " + placesRequest);
            WebResponse response = await request.GetResponseAsync();
            Log.Debug("Response received : " + ((HttpWebResponse) response).StatusDescription);

            JObject json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

            // Parse the response to get suggestions
            List<string> suggestions = new List<string>();
            string debugresult = "{";
            foreach (JObject current in json["predictions"]) {
                debugresult += "\"" + current["description"] + "\", ";
                suggestions.Add(current["description"].ToString());
            }
            if (debugresult.Length > 3) {
                debugresult = debugresult.Remove(debugresult.Length - 2);
            }

            debugresult += "}";
            Log.Debug("Suggestions : " + debugresult);
            return suggestions;
        }

    }
}