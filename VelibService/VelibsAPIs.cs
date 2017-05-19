using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Xml;

namespace VelibService
{
    class VelibsAPIs
    {
        private static XmlNodeList GetCarto()
        {
            WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            XmlNodeList elemList = doc.GetElementsByTagName("marker");

            reader.Close();
            response.Close();

            return elemList;
        }

        // Méthode générique qui permet de recup les infos station selon élément recherché
        // (exemple elemWanted peut être : available, free, total, ticket, ...)
        // voir ici : http://www.velib.paris/service/stationdetails/12152
        public int GetDetailsStation(Station station, String elemWanted)
        {
            XmlNodeList elemList = GetCarto();
            int result = 0;

            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].Attributes["name"].Value.Contains(station.name))
                {
                    String numPoint = elemList[i].Attributes["number"].Value;

                    WebRequest request_for_data = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + numPoint);

                    WebResponse response_for_data = request_for_data.GetResponse();
                    
                    Stream dataStream_for_data = response_for_data.GetResponseStream();
                    StreamReader reader_for_data = new StreamReader(dataStream_for_data);
                    string responseFromServer_for_data = reader_for_data.ReadToEnd();
                    
                    XmlDocument doc_for_data = new XmlDocument();
                    doc_for_data.LoadXml(responseFromServer_for_data);
                    XmlNodeList elemList_for_data = doc_for_data.GetElementsByTagName(elemWanted);

                    result = Int32.Parse(elemList_for_data[0].FirstChild.Value);

                    reader_for_data.Close();
                    response_for_data.Close();
                }
            }

            return result;
        }

        public Station GetNearStation(Coordinates coord)
        {
            // trouver la station la plus proche des coordonnées
            // disposant au moins d'un vélo au depart
            // et disposant au moins d'un emplacement vide à l'arrivée
            return null;
        }
    }
}
