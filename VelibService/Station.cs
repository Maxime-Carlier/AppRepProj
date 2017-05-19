using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VelibService
{
    class Station
    {
        public int number;
        public Coordinates coordinates;
        public string name;
        public string address;

        public Station(XmlNode node)
        {
            number = Convert.ToInt32(node.Attributes["number"].Value);
            coordinates = new Coordinates(
                Convert.ToDouble(node.Attributes["lat"].Value),
                Convert.ToDouble(node.Attributes["lng"].Value)
            );
            name = node.Attributes["name"].Value;
            address = node.Attributes["fullAddress"].Value;
        }
    }
}
