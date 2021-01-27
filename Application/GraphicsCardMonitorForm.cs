using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using GraphicsCards;        // namespace containining graphics card interfaces and drivers

namespace GraphicsCardMonitor
{
    /// <summary>
    /// The Graphics Card Monitor Application
    /// </summary>
    public partial class GraphicsCardMonitorForm : Form
    {
        #region Constants

        /// <summary>
        /// amount of time, in milliseconds, to refresh the application data for a selected GPU
        /// </summary>
        const int REFRESH_TIME = 1000;

        #endregion Constants

        #region Private Global Static Variables

        /// <summary>
        /// interface for the graphics cards
        /// </summary>
        private static IGraphicsCard gs_GraphicsCards;

        /// <summary>
        /// the total number of graphics cards in the system
        /// </summary>
        private static uint gs_NumGraphicsCards = 0;

        /// <summary>
        /// List containing the BackgroundWorker objects available in the form
        /// </summary>
        private static List<BackgroundWorker> gs_backGroundWorkers = new List<BackgroundWorker>();

        /// <summary>
        /// selected GPU from the GraphicsCardComboxBox
        /// </summary>
        private static uint gs_selectedGpu = 0;

        #endregion Private Global Static Variables

        #region Constructors

        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public GraphicsCardMonitorForm()
        {
            try
            {
                InitializeComponent();

                // initialize the BackgroundWorker list
                InitializeBackgroundWorkerList();

                // refresh the application
                RefreshApplication();
            }
            catch (Exception formEx)
            {
                // let the user know an error occurred starting the application
                MessageBox.Show("ERROR: Could not initialize application. " +
                    "Click Refresh to refresh the application or Exit to exit the application." +
                    "Error that occurred: " + GetInternalExceptionMessage(formEx));
            }
        }

        #endregion Constructors

        #region Private Methods

        /// <summary>
        /// Finds the inner most exception message of an exception that occured
        /// </summary>
        /// <param name="ex">The Exception object</param>
        /// <returns>The inner most exception message as a string</returns>
        private string GetInternalExceptionMessage(Exception ex)
        {
            // while the inner most exception is not found
            // assign the current exception to the internal exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            // return the inner most internal exception message
            return ex.Message;
        }

        /// <summary>
        /// Adds all BackgroundWorker objects to the BackgroundWorker List object
        /// </summary>
        private void InitializeBackgroundWorkerList()
        {
            gs_backGroundWorkers.Add(serialNumBackgroundWorker);
            gs_backGroundWorkers.Add(vbiosBackgroundWorker);
        }

        /// <summary>
        /// Gets all Nvidia based graphics cards installed in the system
        /// </summary>
        private void GetNvidiaGraphicsCards()
        {
            try
            {
                bool success    = true; // determines if getting the graphics cards was successful
                string errorMsg = "";   // stores an error message if any errors occur

                // create an instance of an Nvidia Graphics card
                gs_GraphicsCards = new NvidiaGraphicsCard();
               
                // initialize the graphics card API
                try
                {
                    success = gs_GraphicsCards.InitializeApi();

                    // set the error message if the graphics card API failed to initialize
                    if (!success)
                    {
                        errorMsg = "Graphics card API failed to initialize.";
                    }
                }
                catch (Exception initEx)
                {
                    // get the cause of the error and throw it as an exception
                    errorMsg = GetInternalExceptionMessage(initEx);
                    throw new Exception(errorMsg);
                }

                // initialize the graphics card handlers
                try
                {
                    success = gs_GraphicsCards.InitializeHandlers();

                    // set the error message if the GPU handlers failed to initialize
                    if (!success)
                    {
                        errorMsg = "GPU handlers failed to initialize.";
                    }
                }
                catch (Exception handlersEx)
                {
                    // get the cause of the error and throw it as an exception
                    errorMsg = GetInternalExceptionMessage(handlersEx);
                    throw new Exception(errorMsg);
                }

                // get the total number of grahics cards in the system
                try
                {
                    gs_NumGraphicsCards = gs_GraphicsCards.GetNumHandlers();

                    if (gs_NumGraphicsCards == 0)
                    {
                        success = false;

                        // let the user know no graphics cards were found in the system
                        errorMsg = "No graphics cards found.";
                    }
                }
                catch (Exception numEx)
                {
                    // get the cause of the error and throw it as an exception
                    errorMsg = GetInternalExceptionMessage(numEx);
                    throw new Exception(errorMsg);
                }

                // if any of the above steps failed, throw an exception with the error message
                if (!success)
                {
                    throw new Exception(errorMsg);
                }
            }
            catch (System.Exception ex)
            {
                // an error occurred obtaining the graphics cards for the application
                // return a message to the user to let them know an error occurred
                string message = GetInternalExceptionMessage(ex);
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Fills the graphics card ComboBox with the name of all available
        /// graphics cards
        /// </summary>
        /// <param name="comboBox">The Windows From ComboBox object to fill</param>
        /// <param name="gCards">The graphics card interface</param>
        private void FillComboBox(ComboBox comboBox, IGraphicsCard gCards)
        {
            try
            {
                // iterate through all the available graphics cards
                // and add them to the the combo box
                for (uint i = 0; i < gs_NumGraphicsCards; i++)
                {
                    comboBox.Items.Add(gCards.GetName(i));
                }
            }
            catch (Exception comboEx)
            {
                // throw an exception to let the user know an error occurred
                string message = GetInternalExceptionMessage(comboEx);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Refreshes the application to a default state
        /// </summary>
        private void RefreshApplication()
        {
            try
            {
                // cancel all BackgroundWorkers from doing work
                CancelBackgroundWorkers();

                // clear the application items
                ClearAppItems();

                // enable all base voltage text boxes
                BaseVoltageTextBox1.Enabled = true;
                BaseVoltageTextBox2.Enabled = true;
                BaseVoltageTextBox3.Enabled = true;
                BaseVoltageTextBox4.Enabled = true;

                // get all Nvidia graphics cards in the system
                // TODO: USE REFECTION TO LOAD ANY GRAPHICS CARD DRIVER FROM A GIVEN.DLL FILE
                GetNvidiaGraphicsCards();

                // fill the selectable graphics card ComboBox with
                // the avaialable graphics cards in the system
                FillComboBox(GraphicsCardComboBox, gs_GraphicsCards);
            }
            catch (Exception refreshEx)
            {
                // let the user know an error occurred refreshing the application
                string message  = "ERROR: An error occurred refreshing the application. "
                                + GetInternalExceptionMessage(refreshEx) 
                                + "\n Click Refresh to refresh the application."
                                + "\n Click Exit to exit the application.";
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Clears the application ComboBox and TextBox objects
        /// </summary>
        private void ClearAppItems()
        {
            try
            {
                // clear the graphics card ComboBox items and the text
                GraphicsCardComboBox.Items.Clear();
                GraphicsCardComboBox.Text = "";

                // clear the application TextBoxs
                CardInfoTextBox.Text                    = "";
                VbiosTextBox.Text                       = "";
                PhysRamTextBox.Text                     = "";
                VirtualRamTextBox.Text                  = "";
                GpuCoresTextBox.Text                    = "";
                BusIdTextBox.Text                       = "";
                CoreTempTextBox.Text                    = "";
                GraphicsCurrentClockSpeedTextBox.Text   = "";
                GraphicsBaseClockSpeedTextBox.Text      = "";
                GraphicsBoostClockSpeedTextBox.Text     = "";
                MemoryCurrentClockSpeedTextBox.Text     = "";
                MemoryBaseClockSpeedTextBox.Text        = "";
                MemoryBoostClockSpeedTextBox.Text       = "";
                PciInternalIdTextBox.Text               = "";
                PciRevTextBox.Text                      = "";
                PciSubsystemTextBox.Text                = "";
                PciExternalIdTextBox.Text               = "";
                PerfStateTextBox.Text                   = "";
                BaseVoltageTextBox1.Text                = "";
                BaseVoltageTextBox2.Text                = "";
                BaseVoltageTextBox3.Text                = "";
                BaseVoltageTextBox4.Text                = "";
            }
            catch (Exception clearEx)
            {
                // let the user know an error occurred clearing the application items
                // and bubble up the exception
                string message  = "Could not clear ComboBox and TextBox items. "
                                + GetInternalExceptionMessage(clearEx);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Cancels all BackgroundWorker object operations in the BackgroundWorker List
        /// </summary>
        private void CancelBackgroundWorkers()
        {
            // iterate through each BackgroundWorker in the BackgroundWorker List
            // and stop any of the operations occurring
            foreach (BackgroundWorker bw in gs_backGroundWorkers)
            {
                bw.CancelAsync();
            }
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Event that occurs when the user selects a graphics card to monitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // cancel all BackgroundWorkers from doing work
                CancelBackgroundWorkers();

                // set the selected GPU handler to use for the background workers
                gs_selectedGpu = (uint)GraphicsCardComboBox.SelectedIndex;

                // start each BackgroundWorker work with the newly selected GPU
                foreach (BackgroundWorker bw in gs_backGroundWorkers)
                {
                    bw.RunWorkerAsync();
                }
            }
            catch (Exception selectGraphicsCardEx)
            {
                // let the user know an error occurred trying to update
                // the application with the graphics card info
                string message = "ERROR: An issue occurred updating graphics card information. "
                                + GetInternalExceptionMessage(selectGraphicsCardEx)
                                + "\n Click Refresh to refresh the application or "
                                + "\n Click Exit to exit the application";
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the Refresh button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshApplication();
            }
            catch (Exception refreshEx)
            {
                // let the user know an error occurred refreshing the application
                string message = "ERROR: An error occurred refreshing the application. "
                                + GetInternalExceptionMessage(refreshEx)
                                + "\n Click Refresh to refresh the application or "
                                + "\n Click Exit to exit the application";
                MessageBox.Show(message);
            }
        }

       

        /// <summary>
        /// Event that occurs when the user clicks the Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // cancel all BackgroundWorkers from doing work
                CancelBackgroundWorkers();

                // close the application
                this.Close();
            }
            catch (Exception exitEx)
            {
                // let the user know an error occurred trying to exit the application
                string message = "ERROR: " + GetInternalExceptionMessage(exitEx)
                                + ". Try closing the application again.";
                MessageBox.Show(message);
            }
        }

        #endregion Events

        private void serialNumBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // get the BackgroundWorker object raising the event
                BackgroundWorker bw = sender as BackgroundWorker;

                // check if any cancellations are pending
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    // get the serial number of the selected GPU and set it as the result
                    e.Result = gs_GraphicsCards.GetCardSerialNumber(gs_selectedGpu);
                }
            }
            catch (Exception ex)
            {
                // an error occurred getting the graphics card serial number
                // get the error and throw it as an exception
                throw new Exception("ERROR: " + GetInternalExceptionMessage(ex));
            }
        }

        private void serialNumBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // check if any errors occurred
            if (e.Error != null)
            {
                // set the serial number TextBox text to the error message
                CardInfoTextBox.Text = e.Error.Message;
            }
            else
            {
                // set the serial number TextBox to the result obtained by the BackgroundWorker
                CardInfoTextBox.Text = e.Result.ToString();
            }
        }

        private void vbiosBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // get the BackgroundWorker object raising the event
                BackgroundWorker bw = sender as BackgroundWorker;

                // check if any cancellations are pending
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    // get the serial number of the selected GPU and set it as the result
                    e.Result = gs_GraphicsCards.GetVBiosInfo(gs_selectedGpu);
                }
            }
            catch (Exception ex)
            {
                // an error occurred getting the graphics card serial number
                // get the error and throw it as an exception
                throw new Exception("ERROR: " + GetInternalExceptionMessage(ex));
            }
        }

        private void vbiosBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // check if any errors occurred
            if (e.Error != null)
            {
                // set the serial number TextBox text to the error message
                VbiosTextBox.Text = e.Error.Message;
            }
            else
            {
                // set the serial number TextBox to the result obtained by the BackgroundWorker
                VbiosTextBox.Text = e.Result.ToString();
            }
        }

        private void physRamBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void physRamBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void vRamBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void vRamBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void numCoresBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void numCoresBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
