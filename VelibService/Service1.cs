﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelibService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class Service1 : IService1
    {
        public string GetJourney(string departure, string arrival)
        {
            MapsAPIs mapsServices = new MapsAPIs();

            Coordinates origin = mapsServices.GetCoordinates(departure);
            Coordinates destination = mapsServices.GetCoordinates(arrival);

            VelibsAPIs velibsServices = new VelibsAPIs();

            // TODO : intéragir avec velibsServices pour recup les bonnes stations..

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