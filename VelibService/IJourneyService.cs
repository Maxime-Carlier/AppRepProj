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

        // [OperationContract]
        // CompositeType GetDataUsingDataContract(CompositeType composite);

    }

    [DataContract]
    public class Journey {
        [DataMember]
        public List<Coordinates> StartToStartStationCoordinates;

        [DataMember]
        public List<Coordinates> StartStationToEndStationCoordinates;

        [DataMember]
        public List<Coordinates> EndStationToEndCoordinates;

        public Journey(List<Coordinates> startToStartStationCoordinates, List<Coordinates> startStationToEndStationCoordinates, List<Coordinates> endStationToEndCoordinates) {
            StartToStartStationCoordinates = startToStartStationCoordinates;
            StartStationToEndStationCoordinates = startStationToEndStationCoordinates;
            EndStationToEndCoordinates = endStationToEndCoordinates;
        }
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "VelibService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
