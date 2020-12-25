using System;
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
        #region Static Variables

        /// <summary>
        /// The Graphics Card object
        /// </summary>
        static IGraphicsCard gCard;

        #endregion

        #region Private Methods

        void InitializeNvidiaGraphicsCardApi()
        {
            try
            {
                // set the interface variable to a new Nvidia Graphics card object
                gCard = new NvidiaGraphicsCard();

                // initialize the graphics card API
                bool apiInitialized = gCard.InitializeApi();

                // check if the graphics card API initialized
                if (apiInitialized)
                {

                }
            }
            catch (Exception ex)
            {
                // let the user know that no graphics cards were either detected
                // in the system or an error occurred with the graphics card API
                string errMsg = "No graphics cards were detected or an error occurred with the API." + ex.Message;
                throw new Exception(errMsg);
            }
        }

        #endregion

        public GraphicsCardTestPanel()
        {
            InitializeComponent();  // default constructor method

            try
            {
                InitializeNvidiaGraphicsCardApi();
            }
            catch (Exception ex)
            {
                // display a message to the user that an error occurred
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}
