using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Xml;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using VelibService;

namespace VelibApplication
{
    public partial class VelibApplication : Form {

        // Needed to keep track of which TextBox was focused to fill in the address
        private Control latestElementFocused;

        private GMapOverlay markers;
        private GMapOverlay routes;

        private bool validateSuggestionSelection = false;
        private bool validateDepartureEdit = true;
        private bool validateArrivalEdit = true;

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
            JourneyService journeyServiceClient = new JourneyService();
            Journey result = journeyServiceClient.GetJourney(DepartureTextBox.Text, ArrivalTextBox.Text);

            PointLatLng origin = new PointLatLng(result.OriginCoordinates.latitude, result.OriginCoordinates.longitude);
            PointLatLng startStation = new PointLatLng(result.StartStationCoordinates.latitude, result.StartStationCoordinates.longitude);
            PointLatLng endStation = new PointLatLng(result.EndStationCoordinates.latitude, result.EndStationCoordinates.longitude);
            PointLatLng destination = new PointLatLng(result.DestinationCoordinates.latitude, result.DestinationCoordinates.longitude);

            GDirections startToStartStationDirections;
            GDirections startStationToEndStationDirections;
            GDirections endStationToDestinationDirections;

            GoogleMapProvider.Instance.GetDirections(out startToStartStationDirections, origin, startStation, false, false, true, false, false);
            GoogleMapProvider.Instance.GetDirections(out startStationToEndStationDirections, startStation, endStation, false, false, true, false, false);
            GoogleMapProvider.Instance.GetDirections(out endStationToDestinationDirections, endStation, destination, false, false, true, false, false);


            GMapRoute startToStartStationGMapRoute = new GMapRoute(startToStartStationDirections.Route, "First");
            GMapRoute startStationToEndStationGMapRoute = new GMapRoute(startStationToEndStationDirections.Route, "Second");
            GMapRoute endStationToDestinationGMapRoute = new GMapRoute(endStationToDestinationDirections.Route, "Third");

            startToStartStationGMapRoute.Stroke.Color = Color.Blue;
            startToStartStationGMapRoute.Stroke.DashStyle = DashStyle.Dash;

            startStationToEndStationGMapRoute.Stroke = (Pen) startToStartStationGMapRoute.Stroke.Clone();
            startStationToEndStationGMapRoute.Stroke.Color=Color.Red;
            startStationToEndStationGMapRoute.Stroke.DashStyle = DashStyle.Solid;

            endStationToDestinationGMapRoute.Stroke.DashStyle = DashStyle.Dash;
            endStationToDestinationGMapRoute.Stroke.Color = Color.Blue;

            routes.Routes.Add(startToStartStationGMapRoute);
            routes.Routes.Add(startStationToEndStationGMapRoute);
            routes.Routes.Add(endStationToDestinationGMapRoute);
        }

        private async void DepartureTextBox_TextChanged(object sender, EventArgs e) {
            if (validateDepartureEdit) {
                validateSuggestionSelection = false; 
                List<string> result = await PlacesAPIs.getAutoCompleteAsync(DepartureTextBox.Text);
                SuggestionListBox.DataSource = result;
                SuggestionListBox.Visible = true;
                SuggestionListBox.SelectedIndex = -1;
                validateSuggestionSelection = true;
            }
        }

        private async void ArrivalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (validateArrivalEdit) {
                validateSuggestionSelection = false;
                List<String> result = await PlacesAPIs.getAutoCompleteAsync(ArrivalTextBox.Text);
                SuggestionListBox.DataSource = result;
                SuggestionListBox.Visible = true;
                SuggestionListBox.SelectedIndex = -1;
                validateSuggestionSelection = true;
            }
        }

        private void DepartureLabel_Click(object sender, EventArgs e)
        {

        }

        private void ArrivalLabel_Click(object sender, EventArgs e)
        {

        }

        private void VelibApplication_Load(object sender, EventArgs e) {
            initGMapControl();
            SuggestionListBox.SelectedIndex = -1;
        }

        private void initGMapControl() {
            GMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GMapControl.SetPositionByKeywords("Paris, France");
            markers = new GMapOverlay("markers");
            routes = new GMapOverlay("routes");
            GMapControl.Overlays.Add(markers);
            GMapControl.Overlays.Add(routes);
        }

        private void SuggestionListBox_SelectedValueChanged(object sender, EventArgs e) {
            if (validateSuggestionSelection) {
                if (SuggestionListBox.SelectedIndex >= 0 && SuggestionListBox.SelectedIndex < SuggestionListBox.Items.Count) {
                    if (latestElementFocused == DepartureTextBox) {
                        validateDepartureEdit = false;
                        DepartureTextBox.Text = SuggestionListBox.SelectedItem.ToString();
                        SuggestionListBox.DataSource = null;
                        SuggestionListBox.Visible = false;
                        validateDeparture();
                        validateDepartureEdit = true;
                    }
                    else if (latestElementFocused == ArrivalTextBox) {
                        validateArrivalEdit = false;
                        ArrivalTextBox.Text = SuggestionListBox.SelectedItem.ToString();
                        SuggestionListBox.DataSource = null;
                        SuggestionListBox.Visible = false;
                        validateArrival();
                        validateArrivalEdit = true;
                    }

                }
            }
        }

        private async void validateDeparture() {
            if (GMapControl.SetPositionByKeywords(DepartureTextBox.Text) == GeoCoderStatusCode.G_GEO_SUCCESS) {
                GMapControl.Zoom = 14;
                Coordinates departureMarkerCoordinate = await MapsAPIs.GetCoordinatesAsync(DepartureTextBox.Text);
                GMapMarker departureMarker=new GMarkerGoogle(new PointLatLng(departureMarkerCoordinate.latitude,departureMarkerCoordinate.longitude),GMarkerGoogleType.red_dot);
                markers.Markers.Add(departureMarker);
                
            }
        }

        private async void validateArrival() {
            if (GMapControl.SetPositionByKeywords(ArrivalTextBox.Text) == GeoCoderStatusCode.G_GEO_SUCCESS) {
                GMapControl.Zoom = 14;
                Coordinates arrivalMarkerCoordinates = await MapsAPIs.GetCoordinatesAsync(ArrivalTextBox.Text);
                GMapMarker arrivalMarker=new GMarkerGoogle(new PointLatLng(arrivalMarkerCoordinates.latitude, arrivalMarkerCoordinates.longitude), GMarkerGoogleType.blue_dot);
                markers.Markers.Add(arrivalMarker);
            }
        }

        private void UpdateLatestFocused(object sender, EventArgs e) {
            latestElementFocused = (Control) sender;
        }
    }
}
