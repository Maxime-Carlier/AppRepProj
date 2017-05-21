using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VelibService
{
    public class Station
    {
        public int number;
        public Coordinates coordinates;
        public string name;
        public string address;

        public Station(XmlNode node)
        {
            number = Convert.ToInt32(node.Attributes["number"].Value);
            coordinates = new Coordinates(
                Convert.ToDouble(node.Attributes["lat"].Value, CultureInfo.InvariantCulture),
                Convert.ToDouble(node.Attributes["lng"].Value, CultureInfo.InvariantCulture)
            );
            name = node.Attributes["name"].Value;
            address = node.Attributes["fullAddress"].Value;
        }

        public override string ToString() {
            return $"{nameof(number)}: {number}, {nameof(coordinates)}: {coordinates}, {nameof(name)}: {name}, {nameof(address)}: {address}";
        }
    }
}
