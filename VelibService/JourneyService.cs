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
            Log.Debug("Got origin coordinates : "+origin);

            Coordinates destination = MapsAPIs.GetCoordinates(arrival);
            Log.Debug("Got destination coordinates : " + destination);

            VelibsAPIs velibsAPIs = new VelibsAPIs();

            Station startStation = velibsAPIs.GetNearStationWithBikes(origin);
            Log.Debug("Got closest station to origin : "+startStation);

            Station endStation = velibsAPIs.GetNearStationWithFreePlaces(destination);
            Log.Debug("Got closest station to destination : " + endStation);

            List<Coordinates> departureToStartStationCoordinates = MapsAPIs.GetDirections(departure, startStation.address, "walking");
            string departureToStartCoordinateString = "{";
            foreach(Coordinates c in departureToStartStationCoordinates)
            {
                departureToStartCoordinateString += "["+c.ToString()+"]" + ", ";

            }
            departureToStartCoordinateString += "}";
            Log.Debug("Got Route from origin to startStation : "+departureToStartCoordinateString);

            List<Coordinates> StartStationToEndStationCoordinates = MapsAPIs.GetDirections(startStation.address, endStation.address, "bicycling");
            string startStationToEndStationString = "{";
            foreach (Coordinates c in StartStationToEndStationCoordinates)
            {
                startStationToEndStationString += "[" + c.ToString() + "]" + ", ";

            }
            startStationToEndStationString += "}";
            Log.Debug("Got Route from origin to startStation : " + startStationToEndStationString);

            List<Coordinates> EndStationToArrivalCoordinates = MapsAPIs.GetDirections(endStation.address, arrival, "walking");
            string EndStationToArrivalString = "{";
            foreach (Coordinates c in EndStationToArrivalCoordinates)
            {
                EndStationToArrivalString += "[" + c.ToString() + "]" + ", ";

            }
            EndStationToArrivalString += "}";
            Log.Debug("Got Route from origin to startStation : " + EndStationToArrivalString);

            // TODO : intéragir avec velibsServices pour recup les bonnes stations.. :
            // TODO : GetNearStation(origin)
            // TODO : GetNearStation(destination)

            // TODO : intéragir avec mapsServices pour recup le bon trajet.. :
            // TODO : getDirection(Departure, stationDeparture, walking)
            // TODO : getDirection(stationDeparture, stationArrival, bicycling)
            // TODO : getDirection(stationArrival, arrival, walking

            // TODO : constuire le result à envoyer au client

            Log.Debug("Ended Journey Calculation");
            return new Journey(departureToStartStationCoordinates, StartStationToEndStationCoordinates, EndStationToArrivalCoordinates);
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
