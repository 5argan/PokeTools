using GoogleMaps.LocationServices;
using log4net;
using POGOLib.Net;
using PokeTools.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeTools
{
    static class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            log4net.Config.XmlConfigurator.Configure();
            
            MapPoint position = GetPosition();
            while (position == null)
            {
                MessageBox.Show("Entered location is invalid.");
                position = GetPosition();
            }
            Session session;
            session = CreateSession(position);
        }

        private static MapPoint GetPosition()
        {
            LocationForm locationForm = new LocationForm();
            Application.Run(locationForm);
            logger.Debug("found location");
            return locationForm.position;
        }
        private static Session CreateSession(MapPoint position)
        {
            LoginForm loginForm = new LoginForm(position.Latitude, position.Longitude);
            Application.Run(loginForm);
            return loginForm.CurrentSession;
        }
    }
}
