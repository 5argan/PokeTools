﻿using POGOLib.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeTools
{
    
    public partial class MainWindow : Form
    {
        private Session session;
        public MainWindow(Session session)
        {
            InitializeComponent();
            this.session = session;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
