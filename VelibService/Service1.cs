using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VelibService.MapsAPI;

namespace VelibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public Journey GetJourney(string departure, string arrival)
        {

            Task<Coordinates> origin = MapsAPIs.GetCoordinates(departure);
            Task<Coordinates> destination = MapsAPIs.GetCoordinates(arrival);

            VelibsAPIs velibsServices = new VelibsAPIs();

            // TODO : intéragir avec velibsServices pour recup les bonnes stations.. :
            // TODO : GetNearStation(origin)
            // TODO : GetNearStation(destination)

            // TODO : intéragir avec mapsServices pour recup le bon trajet.. :
            // TODO : getDirection(Departure, stationDeparture, walking)
            // TODO : getDirection(stationDeparture, stationArrival, bicycling)
            // TODO : getDirection(stationArrival, arrival, walking

            // TODO : constuire le result à envoyer au client

            List<Coordinates> startToStartStationCoordinates = new List<Coordinates>();
            List<Coordinates> startStationToEndStationCoordinates = new List<Coordinates>();
            List<Coordinates> endStationToEndCoordinates = new List<Coordinates>();

            return new Journey(startToStartStationCoordinates, startStationToEndStationCoordinates, endStationToEndCoordinates);
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
