using POGOLib.Net;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PokeTools
{

    public partial class MainWindow : Form
    {
        private Session session;
        private List<IPokemon> ownedPokemon;
        private List<IPokemonEgg> ownedEggs;
        private Dictionary<string, int> ownedCandy;
        private Dictionary<string, int> ownedItems;
        private List<IIncubator> ownedIncubators;
        //TODO: List of currently applied items
        public MainWindow(Session session)
        {
            InitializeComponent();
            this.session = session;
            session.Startup();
        }
    }
}
