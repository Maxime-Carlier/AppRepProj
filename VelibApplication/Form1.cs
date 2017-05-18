using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Xml;

namespace VelibApplication
{
    public partial class VelibApplication : Form
    {
        public VelibApplication()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            
            string Station_Substring = DepartureTextBox.Text;

            // Station_Substring = "QUIT" to quit 
            if (!Station_Substring.Equals(""))
            {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create("http://www.velib.paris/service/carto");

                // Get Response from the Service 
                WebResponse response = request.GetResponse();

                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access and put it into a string
                StreamReader reader = new StreamReader(dataStream); // Read the content.
                string responseFromServer = reader.ReadToEnd(); // Put it in a String 

                // Parse the response and put the entries in XmlNodeList 
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);
                XmlNodeList elemList = doc.GetElementsByTagName("marker");

                bool founded = false;

                // browse the XmlNodeList
                for (int i = 0; i < elemList.Count; i++)
                {
                    //Test if the substring is in the name of the station  
                    if (elemList[i].Attributes["name"].Value.Contains(Station_Substring))
                    {
                        //Check if we found something
                        founded = true;

                        //Get the number of the Station 
                        String numPoint = elemList[i].Attributes["number"].Value;

                        // Create a request for the URL.
                        WebRequest request_for_data = WebRequest.Create("http://www.velib.paris/service/stationdetails/" + numPoint);

                        // Get Response 
                        WebResponse response_for_data = request_for_data.GetResponse();

                        // Open the stream using a StreamReader for easy access and put it into a string
                        Stream dataStream_for_data = response_for_data.GetResponseStream();
                        StreamReader reader_for_data = new StreamReader(dataStream_for_data); // Read the content.
                        string responseFromServer_for_data = reader_for_data.ReadToEnd(); // Put it in a String

                        // Parse the response and put the entries in XmlNodeList 
                        XmlDocument doc_for_data = new XmlDocument();
                        doc_for_data.LoadXml(responseFromServer_for_data);
                        XmlNodeList elemList_for_data = doc_for_data.GetElementsByTagName("available");

                        // Display the result
                        MessageBox.Show(
                            elemList_for_data[0].FirstChild.Value +
                            " bikes are available " +
                            "at " + elemList[i].Attributes["name"].Value,
                            "Result");

                        reader_for_data.Close();
                        response_for_data.Close();
                    }
                }

                if (!founded)
                {
                    MessageBox.Show(
                        "This station does not exist..",
                        "Error station..");
                }

                // Clean up the streams and the response.
                reader.Close();
                response.Close();
            }
            else
            {
                MessageBox.Show(
                    "Plz, \"Departure\" is a mandatory field..",
                    "Error field..");
            }
        }

        private void DepartureTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ArrivalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DepartureLabel_Click(object sender, EventArgs e)
        {

        }

        private void ArrivalLabel_Click(object sender, EventArgs e)
        {

        }

        private void VelibApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
