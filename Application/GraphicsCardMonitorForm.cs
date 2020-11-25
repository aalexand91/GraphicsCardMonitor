using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraphicsCards;        // namespace containining graphics card interfaces and drivers

namespace GraphicsCardMonitor
{
    public partial class GraphicsCardMonitorForm : Form
    {
        #region Constants

        /// <summary>
        /// amount of time, in milliseconds, to refresh the application data for a selected GPU
        /// </summary>
        const int REFRESH_TIME = 2000;

        #endregion Constants

        #region Global Variables

        /// <summary>
        /// interface for the graphics cards
        /// </summary>
        IGraphicsCard gGraphicsCards;

        /// <summary>
        /// the total number of graphics cards in the system
        /// </summary>
        uint gNumGraphicsCards = 0;

        #endregion Global Variables

        #region Constructors

        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public GraphicsCardMonitorForm()
        {
            try
            {
                InitializeComponent();

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
        /// Gets the graphics cards within the system
        /// </summary>
        /// <param name="gCards">The graphics card interface</param>
        /// <exception cref="System.Exception">
        /// Graphics card API failed to initialize.
        /// </exception>
        /// <exception cref="System.Exception">
        /// GPU handlers failed to initialize.
        /// </exception>
        /// <exception cref="System.Exception">
        /// No graphics cards found.
        /// </exception>
        private void GetGraphicsCards(IGraphicsCard gCards)
        {
            try
            {
                // variable that determines if getting the graphics cards is successful
                bool success = true;

                // varialbe to store the error message if any errors occur
                string errorMsg = "";

                // initialize the graphics card API
                try
                {
                    success = gCards.InitializeApi();

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
                    success = gCards.InitializeHandlers();

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
                    gNumGraphicsCards = gCards.GetNumHandlers();

                    if (gNumGraphicsCards == 0)
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
                for (uint i = 0; i < gNumGraphicsCards; i++)
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
        /// Defaults the graphics card ComboBox
        /// </summary>
        /// <param name="comboBox">The graphics card ComboBox item</param>
        private void DefaultComboBox(ComboBox comboBox)
        {
            try
            {
                // if there are items listed in the ComboBox
                // select the first item
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception defaultComBoxEx)
            {
                // let the user know an error occurred defaulting
                // the graphics card combo box to the first selected item
                string message = "ERROR: " + GetInternalExceptionMessage(defaultComBoxEx);
                MessageBox.Show(message);
            }
        }

        /// <summary>
        /// Refreshes the application to a default state
        /// </summary>
        private void RefreshApplication()
        {
            try
            {
                // wait for the API background thread to not be busy and then cancel the thread
                while (!ApiBackGroundWorker.IsBusy)
                {
                    ApiBackGroundWorker.CancelAsync();
                }

                // clear the application items
                ClearAppItems();

                // if the number of graphics cards in the system is 0
                // it is possible the application is first being initialized
                // find all graphics cards in the system
                GetGraphicsCards(gGraphicsCards);

                // fill the selectable graphics card ComboBox with
                // the avaialable graphics cards in the system
                FillComboBox(GraphicsCardComboBox, gGraphicsCards);

                // default the graphcis card ComboBox to the first item
                DefaultComboBox(GraphicsCardComboBox);
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
                // clear the graphics card ComboBox items
                GraphicsCardComboBox.Items.Clear();

                // clear the application TextBoxs
                CardInfoTextBox.Text        = "";
                VbiosTextBox.Text           = "";
                PhysRamTextBox.Text         = "";
                VirtualRamTextBox.Text      = "";
                CoreVoltageTextBox.Text     = "";
                GpuCoresTextBox.Text        = "";
                BusIdTextBox.Text           = "";
                Max3dTextBox.Text           = "";
                Balanced3dTextBox.Text      = "";
                HdTextBox.Text              = "";
                CoreTempTextBox.Text        = "";
                BoardTempTextBox.Text       = "";
                MemoryTempTextBox.Text      = "";
                SupplyTempTextBox.Text      = "";
                PciInternalIdTextBox.Text   = "";
                PciRevTextBox.Text          = "";
                PciSubsystemTextBox.Text    = "";
                PciExternalIdTextBox.Text   = "";
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
                ApiBackGroundWorker.RunWorkerAsync();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Event that the API background thread is conducting once called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApiBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker apiWorker = sender as BackgroundWorker;

            try
            {
                // update the application text box field while no cancellation requests are called
                while (apiWorker.CancellationPending != true)
                {
                    // the GPU handler selected in memory
                    uint selectedGpu = (uint)GraphicsCardComboBox.SelectedIndex;

                    // update all TextBox text to relevant graphics card information
                    //CardInfoTextBox.Text        = gGraphicsCards.GetCardInfo(selectedGpu);
                    VbiosTextBox.Text           = gGraphicsCards.GetVBiosInfo(selectedGpu);
                    PhysRamTextBox.Text         = gGraphicsCards.GetPhysicalRamSize(selectedGpu).ToString();
                    VirtualRamTextBox.Text      = gGraphicsCards.GetVirtualRamSize(selectedGpu).ToString();
                    CoreVoltageTextBox.Text     = gGraphicsCards.GetBaseVoltage(selectedGpu).ToString();
                    GpuCoresTextBox.Text        = gGraphicsCards.GetGpuCoreCount(selectedGpu).ToString();
                    BusIdTextBox.Text           = gGraphicsCards.GetGpuBusId(selectedGpu).ToString();
                    Max3dTextBox.Text           = gGraphicsCards.GetMax3dPerformanceState(selectedGpu).ToString();
                    Balanced3dTextBox.Text      = gGraphicsCards.GetBalanced3dPerformanceState(selectedGpu).ToString();
                    HdTextBox.Text              = gGraphicsCards.GetHighDefVideoPlaybackState(selectedGpu).ToString();
                    CoreTempTextBox.Text        = gGraphicsCards.GetGpuCoreTemp(selectedGpu).ToString();
                    BoardTempTextBox.Text       = gGraphicsCards.GetBoardTemp(selectedGpu).ToString();
                    MemoryTempTextBox.Text      = gGraphicsCards.GetMemoryTemp(selectedGpu).ToString();
                    SupplyTempTextBox.Text      = gGraphicsCards.GetPowerSupplyTemp(selectedGpu).ToString();
                    PciInternalIdTextBox.Text   = gGraphicsCards.GetGpuPciInternalDeviceId(selectedGpu).ToString();
                    PciRevTextBox.Text          = gGraphicsCards.GetGpuPciRevId(selectedGpu).ToString();
                    PciSubsystemTextBox.Text    = gGraphicsCards.GetGpuPciSubSystemId(selectedGpu).ToString();
                    PciExternalIdTextBox.Text   = gGraphicsCards.GetGpuPciExternalDeviceId(selectedGpu).ToString();

                    // delay for some time before refreshing the application again
                    System.Threading.Thread.Sleep(REFRESH_TIME);
                }
            }
            catch (Exception backgroundEx)
            {
                // an error occurred with the background worker
                // cancel the operation and report the error back to the user
                e.Cancel = true;
                string message = "An issue occurred with the application: "
                                + GetInternalExceptionMessage(backgroundEx);
                throw new Exception(message);
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
                // cancel the API background worker if it is still performing
                // an operation
                while (!ApiBackGroundWorker.IsBusy)
                {
                    ApiBackGroundWorker.CancelAsync();
                }

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
    }
}
