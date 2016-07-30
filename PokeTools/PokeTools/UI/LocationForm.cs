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
        private static GoogleLocationService locationService = new GoogleLocationService();
        private static string LOCATION_ERROR = "An error occured while trying to parse position.";
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
                    MessageBox.Show(LOCATION_ERROR);
                    logger.Error(ex.Message);
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                position = locationService.GetLatLongFromAddress(this.txtAddress.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(LOCATION_ERROR);
                logger.Error(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitApplication();
            }
        }

        private void ExitApplication()
        {
            if (MessageBox.Show("Are you sure you want to exit PokeTools?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
