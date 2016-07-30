using log4net;
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

            //TODO if closing then end application
            LocationForm locationForm = new LocationForm();
            Application.Run(locationForm);

            LoginForm loginForm = new LoginForm(locationForm.position.Latitude, locationForm.position.Longitude);
            Application.Run(loginForm);
        }
    }
}
