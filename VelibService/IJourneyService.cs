using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VelibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IJourneyService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IJourneyService
    {
        [OperationContract]
        Journey GetJourney(string departure, string arrival);
    }

    [DataContract]
    public class Journey {
        [DataMember]
        public Coordinates OriginCoordinates;

        [DataMember]
        public Coordinates StartStationCoordinates;

        [DataMember]
        public Coordinates EndStationCoordinates;

        [DataMember]
        public Coordinates DestinationCoordinates;

        public Journey(Coordinates originCoordinates, Coordinates startStationCoordinates, Coordinates endStationCoordinates, Coordinates destinationCoordinates) {
            OriginCoordinates = originCoordinates;
            StartStationCoordinates = startStationCoordinates;
            EndStationCoordinates = endStationCoordinates;
            DestinationCoordinates = destinationCoordinates;
        }
    }
}
