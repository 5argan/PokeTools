using GoogleMaps.LocationServices;
using log4net;
using POGOLib.Net;
using POGOLib.Pokemon;
using PokeTools.UI;
using System;
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
            session.Player.Inventory.Update += InventoryOnUpdate;
            session.Map.Update += MapOnUpdate;
            

            Application.Run(new MainWindow(session));
        }

        private static void InventoryOnUpdate(object sender, EventArgs eventArgs)
        {
            logger.Info("Inventory was updated.");
            logger.Debug(((Inventory)sender).InventoryItems.ToString());
        }

        private static void MapOnUpdate(object sender, EventArgs eventArgs)
        {
            logger.Info("Map was updated.");
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
