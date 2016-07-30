using System;
using System.Windows.Forms;
using POGOLib.Net.Authentication;
using POGOLib.Pokemon.Data;
using log4net;
using POGOLib.Net;

namespace PokeTools.UI
{
    public partial class LoginForm : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private double latitude;
        private double longitude;
        private bool EXIT_APP = true;

        public Session CurrentSession { get; private set; }

        public LoginForm(double latitude, double longitude)
        {
            InitializeComponent();
            this.latitude = latitude;
            this.longitude = longitude;
            this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }

        private void btnLoginPTC_Click(object sender, EventArgs e)
        {
            if (TryLogin(LoginProvider.PokemonTrainerClub))
            {
                EXIT_APP = false;
                this.Close();
            }
        }

        private void btnLoginGoogle_Click(object sender, EventArgs e)
        {
            if (TryLogin(LoginProvider.GoogleAuth))
            {
                EXIT_APP = false;
                this.Close();
            }
        }

        private bool TryLogin(LoginProvider provider)
        {
            try
            {
                logger.Debug("Trying to log in");
                CurrentSession = Login.GetSession(this.txtUsername.Text, this.txtPassword.Text, provider, latitude, longitude);
                logger.Debug("Logged in");
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("incorrect") || ex.Message.Contains("disabled"))
                {
                    //PTC login fail
                    MessageBox.Show(ex.Message);
                }
                else if (ex.Message.Contains("BadAuthentication"))
                {
                    //Google login fail
                    MessageBox.Show("Username and/or password were incorrect.");
                }
                else
                {
                    logger.Error(ex.Message);
                }
                return false;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EXIT_APP)
            {
                if (MessageBox.Show("Are you sure you want to exit PokeTools?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
