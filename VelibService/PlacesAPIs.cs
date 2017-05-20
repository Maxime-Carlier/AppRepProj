using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace VelibService.PlacesAPI
{
    public static class PlacesAPIs
    {

        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(typeof(PlacesAPIs));

        private static readonly string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json";
        private static readonly string key = "AIzaSyCumpMGwKBTp9BtHLL0q7hvBbEtdg-FMGA";

        static PlacesAPIs() {
            BasicConfigurator.Configure();
        }

        public static void getAutoComplete(string input)
        {
            string placesRequest = url + "?input=" + input +
                                   "&types=geocode&location=48.856127,2.351332&radius=10000&strictbound&key=" + key;
            
            WebRequest request = WebRequest.Create(placesRequest);
            Log.Debug("Request sent : "+placesRequest);
            WebResponse response = request.GetResponse();
            Log.Debug("Response : "+response);
        }
    }
    
}
