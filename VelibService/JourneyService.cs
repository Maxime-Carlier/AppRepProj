using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using log4net;
using VelibService;

namespace VelibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "JourneyService" à la fois dans le code et le fichier de configuration.
    public class JourneyService : IJourneyService
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(JourneyService));

        public Journey GetJourney(string departure, string arrival)
        {
            Log.Debug("Started Journey calculations");

            Coordinates origin = MapsAPIs.GetCoordinates(departure);
            Log.Debug("Got origin coordinates : " + origin);

            Coordinates destination = MapsAPIs.GetCoordinates(arrival);
            Log.Debug("Got destination coordinates : " + destination);

            VelibsAPIs velibsAPIs = new VelibsAPIs();

            Station startStation = velibsAPIs.GetNearStationWithBikes(origin);
            Log.Debug("Got closest station to origin : " + startStation);

            Station endStation = velibsAPIs.GetNearStationWithFreePlaces(destination);
            Log.Debug("Got closest station to destination : " + endStation);

            Log.Debug("Ended Journey Calculation");
            return new Journey(origin, startStation.coordinates, endStation.coordinates, destination);
        }

        /* ---
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        --- */
    }
}
