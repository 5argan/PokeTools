using GoogleMaps.LocationServices;
using log4net;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PokeTools.UI
{
    public partial class LocationForm : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GoogleLocationService locationService = new GoogleLocationService();
        public MapPoint position { get; private set; }
        public LocationForm()
        {
            InitializeComponent();
        }

        private void LocationForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        }

        private void btnGetLocation_Click(object sender, EventArgs e)
        {
            if (this.txtAddress.Text != String.Empty)
            {
                try
                {
                    position = locationService.GetLatLongFromAddress(this.txtAddress.Text);
                    txtLink.Text = $"https://www.google.com/maps/?q={position.Latitude},{position.Longitude}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while trying to parse position.");
                    logger.Error(ex.Message);
                }
            }
            
        }
    }
}
