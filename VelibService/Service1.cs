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
        public async Task<string> GetJourney(string departure, string arrival)
        {

            Coordinates origin = await MapsAPIs.GetCoordinates(departure);
            Coordinates destination = await MapsAPIs.GetCoordinates(arrival);

            VelibsAPIs velibsServices = new VelibsAPIs();

            // TODO : intéragir avec velibsServices pour recup les bonnes stations.. :
            // TODO : GetNearStation(origin)
            // TODO : GetNearStation(destination)

            // TODO : intéragir avec mapsServices pour recup le bon trajet.. :
            // TODO : getDirection(Departure, stationDeparture, walking)
            // TODO : getDirection(stationDeparture, stationArrival, bicycling)
            // TODO : getDirection(stationArrival, arrival, walking

            // TODO : constuire le result à envoyer au client

            return string.Format("Result here");
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
