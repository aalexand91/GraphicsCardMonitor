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
        const int SETTLING_TIME = 100;

        /// <summary>
        /// converts the GPU base voltage values to V
        /// </summary>
        const double BASE_VOLTAGE_CONVERSION = 1e9;

        /// <summary>
        /// converts all GPU processor clock speeds to MHz
        /// </summary>
        const double CLOCK_FREQ_CONVERSION = 1e6;

        #endregion Constants

        #region Private Global Static Variables

        /// <summary>
        /// interface for the graphics cards
        /// </summary>
        private static IGraphicsCard gs_GraphicsCards;

        /// <summary>
        /// the total number of graphics cards in the system
        /// </summary>
        private static uint gs_NumGraphicsCards = 0u;

        /// <summary>
        /// List containing the BackgroundWorker objects available in the form
        /// </summary>
        private static List<BackgroundWorker> gs_backGroundWorkers = new List<BackgroundWorker>();

        /// <summary>
        /// selected GPU from the GraphicsCardComboxBox
        /// </summary>
        private static uint gs_selectedGpu = 0u;

        /// <summary>
        /// state of cancelling the BackgroundWorker objects
        /// </summary>
        private bool gs_cancelBackgroundWorkers = true;

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
            gs_backGroundWorkers.Add(physRamBackgroundWorker);
            gs_backGroundWorkers.Add(vRamBackgroundWorker);
            gs_backGroundWorkers.Add(numCoresBackgroundWorker);
            gs_backGroundWorkers.Add(busIdBackgroundWorker);
            gs_backGroundWorkers.Add(coreTempBackgroundWorker);
            gs_backGroundWorkers.Add(pciInternalBackgroundWorker);
            gs_backGroundWorkers.Add(pciRevBackgroundWorker);
            gs_backGroundWorkers.Add(pciSubsystemBackgroundWorker);
            gs_backGroundWorkers.Add(pciExternalBackgroundWorker);
            gs_backGroundWorkers.Add(graphicsCurrentClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(graphicsBaseClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(graphicsBoostClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(memoryCurrentClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(memoryBaseClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(memoryBoostClockSpeedBackgroundWorker);
            gs_backGroundWorkers.Add(perfStateBackgroundWorker);
            gs_backGroundWorkers.Add(baseVoltage1BackgroundWorker);
            gs_backGroundWorkers.Add(baseVoltage2BackgroundWorker);
            gs_backGroundWorkers.Add(baseVoltage3BackgroundWorker);
            gs_backGroundWorkers.Add(baseVoltage4BackgroundWorker);
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

                // disable all the TextBox controls since they are not in use
                DisableTextBoxes();

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

                // clear the application TextBoxes
                SerialNumTextBox.Text                   = "";
                VbiosTextBox.Text                       = "";
                PhysRamTextBox.Text                     = "";
                VirtualRamTextBox.Text                  = "";
                GpuCoresTextBox.Text                    = "";
                BusIdTextBox.Text                       = "";
                CoreTempTextBox.Text                    = "";
                PciInternalIdTextBox.Text               = "";
                PciRevTextBox.Text                      = "";
                PciSubsystemTextBox.Text                = "";
                PciExternalIdTextBox.Text               = "";
                GraphicsCurrentClockSpeedTextBox.Text   = "";
                GraphicsBaseClockSpeedTextBox.Text      = "";
                GraphicsBoostClockSpeedTextBox.Text     = "";
                MemoryCurrentClockSpeedTextBox.Text     = "";
                MemoryBaseClockSpeedTextBox.Text        = "";
                MemoryBoostClockSpeedTextBox.Text       = "";
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
        /// Disables all TextBox controls
        /// </summary>
        private void DisableTextBoxes()
        {
            // disable the all TextBoxes
            SerialNumTextBox.Enabled                    = false;
            VbiosTextBox.Enabled                        = false;
            PhysRamTextBox.Enabled                      = false;
            VirtualRamTextBox.Enabled                   = false;
            GpuCoresTextBox.Enabled                     = false;
            BusIdTextBox.Enabled                        = false;
            CoreTempTextBox.Enabled                     = false;
            PciInternalIdTextBox.Enabled                = false;
            PciRevTextBox.Enabled                       = false;
            PciSubsystemTextBox.Enabled                 = false;
            PciExternalIdTextBox.Enabled                = false;
            GraphicsCurrentClockSpeedTextBox.Enabled    = false;
            GraphicsBaseClockSpeedTextBox.Enabled       = false;
            GraphicsBoostClockSpeedTextBox.Enabled      = false;
            MemoryCurrentClockSpeedTextBox.Enabled      = false;
            MemoryBaseClockSpeedTextBox.Enabled         = false;
            MemoryBoostClockSpeedTextBox.Enabled        = false;
            PerfStateTextBox.Enabled                    = false;
            BaseVoltageTextBox1.Enabled                 = false;
            BaseVoltageTextBox2.Enabled                 = false;
            BaseVoltageTextBox3.Enabled                 = false;
            BaseVoltageTextBox4.Enabled                 = false;
        }

        /// <summary>
        /// Cancels all BackgroundWorker object operations in the BackgroundWorker List
        /// </summary>
        private void CancelBackgroundWorkers()
        {
            // set the cancellation state of all BackgroundWorker objects to true
            gs_cancelBackgroundWorkers = true;

            // iterate through each BackgroundWorker in the BackgroundWorker List
            // and stop any of the operations occurring
            foreach (BackgroundWorker bw in gs_backGroundWorkers)
            {
                bw.CancelAsync();
            }
        }

        /// <summary>
        /// Updates a TextBox control with a BackgroundWorker object's result
        /// </summary>
        /// <param name="textBox">The TextBox control to update</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void UpdateTextBoxControlText(TextBox textBox, RunWorkerCompletedEventArgs e)
        {
            // check if any errors occurred
            if (e.Error != null)
            {
                // disable the TextBox
                textBox.Enabled = false;

                // set the TextBox text to the error message
                textBox.Text = e.Error.Message;
            }
            else
            {
                // check if the BackgroundWorker was cancelled before trying to update
                if (!e.Cancelled && !gs_cancelBackgroundWorkers)
                {
                    // enable the TextBox
                    textBox.Enabled = true;

                    // set the TextBox text to the result obtained by the BackgroundWorker
                    textBox.Text = e.Result.ToString();
                }
            }
        }

        /// <summary>
        /// Updates the base voltage TextBox control text to the respective base voltage BackgroundWorker
        /// object result. If any errors occurred obtaining the specific base voltage, a message is
        /// displayed to the user and then the TextBox control is cleared and then disabled.
        /// </summary>
        /// <param name="textBox">The base voltage TextBox control</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void UpdateBaseVoltageTextBoxControlText(TextBox textBox, RunWorkerCompletedEventArgs e)
        {
            // check if any error occurred
            if (e.Error != null)
            {
                // display the error message to the user to let them know
                MessageBox.Show(e.Error.Message);

                // more than likely, the graphics card does not have this base voltage
                // clear any text from the text box and disable it
                textBox.Text = "";
                textBox.Enabled = false;
            }
            else
            {
                // check if the background worker is not cancelled
                if (!e.Cancelled)
                {
                    // enable the TextBox control
                    textBox.Enabled = true;

                    // set the base voltage TextBox control to the BackgroundWorker result
                    textBox.Text = String.Format("{0:0.00}", e.Result.ToString());
                }
            }
        }

        #endregion Private Methods

        #region Control Events

        /// <summary>
        /// Event that occurs when the user selects a graphics card to monitor
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void GraphicsCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // cancel all BackgroundWorkers from doing work
                CancelBackgroundWorkers();

                // set the selected GPU handler to use for the background workers
                gs_selectedGpu = (uint)GraphicsCardComboBox.SelectedIndex;

                // set the cancellation state of all BackgroundWorker objects to false
                gs_cancelBackgroundWorkers = false;

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
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
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

        #endregion Control Events

        #region BackgroundWorker Events

        /// <summary>
        /// Gets the graphics card serial number using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
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

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // an error occurred getting the graphics card serial number
                // get the error and throw it as an exception
                throw new Exception("ERROR: Could not get serial number. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the serial number TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void serialNumBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the serial number TextBox text
            UpdateTextBoxControlText(SerialNumTextBox, e);
        }

        /// <summary>
        /// Gets the graphics card VBIOS info using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
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

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // an error occurred getting the graphics card serial number
                // get the error and throw it as an exception
                throw new Exception("ERROR: Could not get VBIOS info. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the VBIOS TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void vbiosBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the VBIOS TextBox text
            UpdateTextBoxControlText(VbiosTextBox, e);
        }

        /// <summary>
        /// Gets the graphics card physical RAM size using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void physRamBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the physical RAM of the graphics card
                    e.Result = gs_GraphicsCards.GetPhysicalRamSize(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card physical RAM size
                throw new Exception("ERROR: Could not get physical RAM size. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the physical RAM TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void physRamBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the physical RAM TextBox text
            UpdateTextBoxControlText(PhysRamTextBox, e);
        }

        /// <summary>
        /// Gets the graphics card virtual RAM size using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void vRamBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the virtual RAM of the graphics card
                    e.Result = gs_GraphicsCards.GetVirtualRamSize(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card virtual RAM size
                throw new Exception("ERROR: Could not get virtual RAM size. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the virtual RAM TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void vRamBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the virtual RAM TextBox text
            UpdateTextBoxControlText(VirtualRamTextBox, e);
        }

        /// <summary>
        /// Gets the number of GPU cores for the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void numCoresBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the number of GPU cores the graphics card has
                    e.Result = gs_GraphicsCards.GetGpuCoreCount(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the number of GPU cores for the graphics card
                throw new Exception("ERROR: Could not get number of GPU cores. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU core count TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void numCoresBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the GPU core count TextBox text
            UpdateTextBoxControlText(GpuCoresTextBox, e);
        }

        /// <summary>
        /// Gets the GPU bus ID for the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void busIdBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the number of GPU cores the graphics card has
                    e.Result = gs_GraphicsCards.GetGpuBusId(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the bus ID for the graphics card
                throw new Exception("ERROR: Could not get bus ID. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU bus ID TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void busIdBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the bus ID TextBox text
            UpdateTextBoxControlText(BusIdTextBox, e);
        }

        /// <summary>
        /// Gets the GPU core temperature using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void coreTempBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the GPU core temperature of the graphics card
                    e.Result = gs_GraphicsCards.GetGpuCoreTemp(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card GPU core temperature
                throw new Exception("ERROR: Could not get GPU core temperature. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU core temp TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void coreTempBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the GPU core temperature TextBox text
            UpdateTextBoxControlText(CoreTempTextBox, e);

            // check if no cancellations are pending
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                coreTempBackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the PCI internal ID of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void pciInternalBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the GPU PCI internal device ID
                    e.Result = gs_GraphicsCards.GetGpuPciInternalDeviceId(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card PCI internal ID
                throw new Exception("ERROR: Could not get PCI internal ID. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU PCI Internal ID TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void pciInternalBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the PCI internal ID TextBox text
            UpdateTextBoxControlText(PciInternalIdTextBox, e);
        }

        /// <summary>
        /// Gets the PCI revision ID of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void pciRevBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the GPU PCI revision
                    e.Result = gs_GraphicsCards.GetGpuPciRevId(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card PCI revision ID
                throw new Exception("ERROR: Could not get PCI revision ID. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU PCI revision TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void pciRevBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the GPU PCI revision TextBox text
            UpdateTextBoxControlText(PciRevTextBox, e);
        }

        /// <summary>
        /// Gets the PCI subsystem ID of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void pciSubsystemBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the GPU PCI subsystem ID
                    e.Result = gs_GraphicsCards.GetGpuPciSubSystemId(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card PCI subsystem ID
                throw new Exception("ERROR: Could not get PCI subsystem ID. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU PCI subsystem ID TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void pciSubsystemBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the GPU PCI subsystem ID TextBox text
            UpdateTextBoxControlText(PciSubsystemTextBox, e);
        }

        /// <summary>
        /// Gets the PCI external ID of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void pciExternalBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the GPU PCI external ID
                    e.Result = gs_GraphicsCards.GetGpuPciExternalDeviceId(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card PCI external ID
                throw new Exception("ERROR: Could not get PCI external ID. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the GPU PCI External ID TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void pciExternalBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the GPU PCI external ID TextBox text
            UpdateTextBoxControlText(PciExternalIdTextBox, e);
        }

        /// <summary>
        /// Gets the current clock speed of the graphics processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void graphicsCurrentClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the graphic processor current clock speed
                    e.Result = gs_GraphicsCards.GetGraphicsCurrentClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the current graphics processor clock speed for the graphics card
                throw new Exception("ERROR: Could not get current clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the graphics processor current clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void graphicsCurrentClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the graphics processor current clock speed TextBox text
            UpdateTextBoxControlText(GraphicsCurrentClockSpeedTextBox, e);

            // check if the BackgroundWorker object is cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                graphicsCurrentClockSpeedBackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the base clock speed of the graphics processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void graphicsBaseClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the graphics processor base clock speed
                    e.Result = gs_GraphicsCards.GetGraphicsBaseClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics processor base clock speed for the graphics card
                throw new Exception("ERROR: Could not get base clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the graphics processor base clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void graphicsBaseClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the graphics processor base clock speed TextBox text
            UpdateTextBoxControlText(GraphicsBaseClockSpeedTextBox, e);
        }

        /// <summary>
        /// Gets the boost clock speed of the graphics processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void graphicsBoostClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the graphics processor boost clock speed
                    e.Result = gs_GraphicsCards.GetGraphicsBoostClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics processor boost clock speed for the graphics card
                throw new Exception("ERROR: Could not get boost clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the graphics processor boost clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void graphicsBoostClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the graphics processor current clock speed TextBox text
            UpdateTextBoxControlText(GraphicsBoostClockSpeedTextBox, e);
        }

        /// <summary>
        /// Gets the current clock speed of the memory processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void memoryCurrentClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the memory processor current clock speed
                    e.Result = gs_GraphicsCards.GetMemoryCurrentClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the memory processor current clock speed for the graphics card
                throw new Exception("ERROR: Could not get current clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the memory processor current clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void memoryCurrentClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the memory processor current clock speed TextBox text
            UpdateTextBoxControlText(MemoryCurrentClockSpeedTextBox, e);

            // check if the BackgroundWorker object is cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                memoryCurrentClockSpeedBackgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Gets the base clock speed of the memory processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void memoryBaseClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the memory processor base clock speed
                    e.Result = gs_GraphicsCards.GetMemoryBaseClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the memory processor base clock speed for the graphics card
                throw new Exception("ERROR: Could not get base clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the memory processor base clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void memoryBaseClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the memory processor base clock speed TextBox text
            UpdateTextBoxControlText(MemoryBaseClockSpeedTextBox, e);
        }

        /// <summary>
        /// Gets the boost clock speed of the memory processor using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void memoryBoostClockSpeedBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the memory processor boost clock speed
                    e.Result = gs_GraphicsCards.GetMemoryBoostClockFreq(gs_selectedGpu) / CLOCK_FREQ_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the memory processor boost clock speed for the graphics card
                throw new Exception("ERROR: Could not get boost clock speed. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the memory processor boost clock speed TextBox control text to its 
        /// respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void memoryBoostClockSpeedBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the memory processor boost clock speed TextBox text
            UpdateTextBoxControlText(MemoryBoostClockSpeedTextBox, e);
        }

        /// <summary>
        /// Gets the current performance state of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void perfStateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the current performance state of the graphics card
                    e.Result = gs_GraphicsCards.GetCurrentPerformanceState(gs_selectedGpu);
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card performance state
                throw new Exception("ERROR: Could not get performance state. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the graphics card performance state TextBox control text to its respective BackgroundWorker object result
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void perfStateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the graphics card performance state ID TextBox text
            UpdateTextBoxControlText(PerfStateTextBox, e);
        }

        /// <summary>
        /// Gets a base voltage of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void baseVoltage1BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get base voltage 1 of the graphics card
                    e.Result = gs_GraphicsCards.GetBaseVoltage(gs_selectedGpu, 0) / BASE_VOLTAGE_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card performance state base voltage
                // for base voltages, it is possible that no base voltage exists for the current graphics card
                throw new Exception("ERROR: Could not get base voltage. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the base voltage 1 TextBox control text to its respective BackgroundWorker object result.
        /// The TextBox control gets disabled if any errors occur with the BackgroundWorker object.
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void baseVoltage1BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the base voltage 1 TextBox text
            UpdateBaseVoltageTextBoxControlText(BaseVoltageTextBox1, e);

            // check if the BackgroundWorker is not cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the worker again
                // this will create a continuous update until the user refreshes
                // or closes the application
                baseVoltage1BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                // sometimes the BackgroundWorker will cancel before the
                // Refresh button can clear the TextBox
                // clear the TextBox text and disable it
                BaseVoltageTextBox1.Text    = "";
                BaseVoltageTextBox1.Enabled = false;
            }
        }

        /// <summary>
        /// Gets a base voltage of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void baseVoltage2BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get base voltage 2 of the graphics card
                    e.Result = gs_GraphicsCards.GetBaseVoltage(gs_selectedGpu, 1) / BASE_VOLTAGE_CONVERSION;
                }
                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);

            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card performance state base voltage
                // for base voltages, it is possible that no base voltage exists for the current graphics card
                throw new Exception("ERROR: Could not get base voltage. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the base voltage 2 TextBox control text to its respective BackgroundWorker object result.
        /// The TextBox control gets disabled if any errors occur with the BackgroundWorker object.
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void baseVoltage2BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the base voltage 2 TextBox text
            UpdateBaseVoltageTextBoxControlText(BaseVoltageTextBox2, e);

            // check if the BackgroundWorker is not cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                baseVoltage2BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                // sometimes the BackgroundWorker will cancel before the
                // Refresh button can clear the TextBox
                // clear the TextBox text and disable it
                BaseVoltageTextBox2.Text    = "";
                BaseVoltageTextBox2.Enabled = false;
            }
        }

        /// <summary>
        /// Gets a base voltage of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void baseVoltage3BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get base voltage 3 of the graphics card
                    e.Result = gs_GraphicsCards.GetBaseVoltage(gs_selectedGpu, 2) / BASE_VOLTAGE_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card performance state base voltage
                // for base voltages, it is possible that no base voltage exists for the current graphics card
                throw new Exception("ERROR: Could not get base voltage. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the base voltage 3 TextBox control text to its respective BackgroundWorker object result.
        /// The TextBox control gets disabled if any errors occur with the BackgroundWorker object.
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void baseVoltage3BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the base voltage 3 TextBox text
            UpdateBaseVoltageTextBoxControlText(BaseVoltageTextBox3, e);

            // check if the BackgroundWorker object has not been cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                baseVoltage3BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                // sometimes the BackgroundWorker will cancel before the
                // Refresh button can clear the TextBox
                // clear the TextBox text and disable it
                BaseVoltageTextBox3.Text    = "";
                BaseVoltageTextBox3.Enabled = false;
            }
        }

        /// <summary>
        /// Gets a base voltage of the graphics card using the respective BackgroundWorker object
        /// </summary>
        /// <param name="sender">BackgroundWorker object raising the event</param>
        /// <param name="e">Object to store the BackgroundWorker results</param>
        /// <exception cref="System.Exception">
        /// An exception is thrown if an error occurs with the graphics card API
        /// </exception>
        private void baseVoltage4BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    // get the base voltage 4 of the graphics card
                    e.Result = gs_GraphicsCards.GetBaseVoltage(gs_selectedGpu, 3) / BASE_VOLTAGE_CONVERSION;
                }

                // allow the hardware/API to settle
                System.Threading.Thread.Sleep(SETTLING_TIME);
            }
            catch (Exception ex)
            {
                // throw an exception to let the user know an error occurred getting
                // the graphics card performance state base voltage
                // for base voltages, it is possible that no base voltage exists for the current graphics card
                throw new Exception("ERROR: Could not get base voltage. " + GetInternalExceptionMessage(ex));
            }
        }

        /// <summary>
        /// Sets the base voltage 4 TextBox control text to its respective BackgroundWorker object result.
        /// The TextBox control gets disabled if any errors occur with the BackgroundWorker object.
        /// </summary>
        /// <param name="sender">BackgroundWorker object that raised the event</param>
        /// <param name="e">Object with the BackgroundWorker object results</param>
        private void baseVoltage4BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // update the base voltage 4 TextBox text
            UpdateBaseVoltageTextBoxControlText(BaseVoltageTextBox4, e);

            // check if the BackgroundWorker object is not cancelled
            if (!gs_cancelBackgroundWorkers)
            {
                // run the BackgroundWorker again
                // this will cause the BackgroundWorker to update the application repeatadely
                // until the user either refreshes or exits the application
                baseVoltage4BackgroundWorker.RunWorkerAsync();
            }
            else
            {
                // sometimes the BackgroundWorker will cancel before the
                // Refresh button can clear the TextBox
                // clear the TextBox text and disable it
                BaseVoltageTextBox4.Text    = "";
                BaseVoltageTextBox4.Enabled = false;
            }
        }

        #endregion BackgroundWorker Events

    }
}
