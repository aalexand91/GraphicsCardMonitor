﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphicsCards;

namespace GraphicsCardsTestPanel
{
    public partial class GraphicsCardTestPanel : Form
    {
        static IGraphicsCard gCard;

        public GraphicsCardTestPanel()
        {
            InitializeComponent();
        }
    }
}
