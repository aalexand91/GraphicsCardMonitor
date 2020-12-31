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
        #region Private Static Variables

        /// <summary>
        /// The Graphics Card object
        /// </summary>
        private static IGraphicsCard s_graphicsCard = null;

        /// <summary>
        /// The number of GPUs the API found
        /// </summary>
        private static uint s_numOfGpus = 0;

        /// <summary>
        /// The selected GPU handler to test
        /// </summary>
        private static uint s_selectedGpu = 0;

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the Nvidia GPU API and gets the total number of Nvidia graphics cards available to test
        /// </summary>
        /// <returns>The total number of Nvidia graphics cards that are testable</returns>
        uint GetNvidiaGraphicsCards()
        {
            uint numNvidiaCards = 0;

            // try to get all Nvidia graphics cards available to test
            try
            {
                // instantiate a new NvidiaGraphicsCard object
                s_graphicsCard = new NvidiaGraphicsCard();

                // initialize the graphics card API
                // if the API does not initialize, throw an exception
                if (!s_graphicsCard.InitializeApi())
                {
                    // let the user know an error occurred initializing the API
                    throw new Exception("Nvidia API failed to initialize.");
                }

                // initialize all GPU handlers
                // if GPUs could not be initialized, throw an exception
                if (!s_graphicsCard.InitializeHandlers())
                {
                    // let the user know an error occurred initializing the GPU handlers
                    throw new Exception("Could not initialize Nvidia GPU handlers.");
                }

                // get the total number of GPUs in the system
                numNvidiaCards = s_graphicsCard.GetNumHandlers();
            }
            catch (Exception ex)
            {
                // an error occurred when trying to get all Nvidia graphics cards installed
                // display a message to the user to let them know that no graphics cards could be found
                MessageBox.Show(ex.Message + ". No Nvidia graphics cards to test.");
            }

            // return the number of Nvidia graphics cards are in the system
            return numNvidiaCards;
        }

        /// <summary>
        /// Disables all test buttons
        /// </summary>
        void DisableTestButtons()
        {
            // disable all test buttons in order to prevent user from trying
            // to test a graphics card before selecting one
            CoreCountButton.Enabled         = false;
            NameButton.Enabled              = false;
            VbiosButton.Enabled             = false;
            VirtualRamButton.Enabled        = false;
            PhysicalRamButton.Enabled       = false;
            SerialNumberButton.Enabled      = false;
            PciInternalIdButton.Enabled     = false;
            PciRevButton.Enabled            = false;
            PciSubsystemIdButton.Enabled    = false;
            PciExternalIdButton.Enabled     = false;
            BusIdButton.Enabled             = false;
            FanSpeedButton.Enabled          = false;
            CoreTempButton.Enabled          = false;
            MemoryTempButton.Enabled        = false;
            PowerSupplyTempButton.Enabled   = false;
            BoardTempButton.Enabled         = false;
            PerfStateButton.Enabled         = false;
            BaseClockFreqButton.Enabled     = false;
            CurrentClockFreqButton.Enabled  = false;
            BoostClockFreqButton.Enabled    = false;
            BaseVoltage1Button.Enabled      = false;
            BaseVoltage2Button.Enabled      = false;
            BaseVoltage3Button.Enabled      = false;
            BaseVoltage4Button.Enabled      = false;
            TestButton.Enabled              = false;
        }

        /// <summary>
        /// Enables all test buttons
        /// </summary>
        void EnableTestButtons()
        {
            // disable all test buttons in order to prevent user from trying
            // to test a graphics card before selecting one
            CoreCountButton.Enabled         = true;
            NameButton.Enabled              = true;
            VbiosButton.Enabled             = true;
            VirtualRamButton.Enabled        = true;
            PhysicalRamButton.Enabled       = true;
            SerialNumberButton.Enabled      = true;
            PciInternalIdButton.Enabled     = true;
            PciRevButton.Enabled            = true;
            PciSubsystemIdButton.Enabled    = true;
            PciExternalIdButton.Enabled     = true;
            BusIdButton.Enabled             = true;
            FanSpeedButton.Enabled          = true;
            CoreTempButton.Enabled          = true;
            MemoryTempButton.Enabled        = true;
            PowerSupplyTempButton.Enabled   = true;
            BoardTempButton.Enabled         = true;
            PerfStateButton.Enabled         = true;
            BaseClockFreqButton.Enabled     = true;
            CurrentClockFreqButton.Enabled  = true;
            BoostClockFreqButton.Enabled    = true;
            BaseVoltage1Button.Enabled      = true;
            BaseVoltage2Button.Enabled      = true;
            BaseVoltage3Button.Enabled      = true;
            BaseVoltage4Button.Enabled      = true;
        }

        /// <summary>
        /// Resets the TestPanel application
        /// </summary>
        void ResetApplication()
        {
            try
            {
                // disable all test buttons
                DisableTestButtons();

                // clear the graphics card ComboBox text
                GraphicsCardComboBox.Text = "";

                // clear out the graphics card ComboBox
                GraphicsCardComboBox.Items.Clear();

                // reset all static variables
                s_graphicsCard  = null;
                s_numOfGpus     = 0;
                s_selectedGpu   = 0;

                // get any Nvidia graphics cards to test
                s_numOfGpus = GetNvidiaGraphicsCards();

                // iterate through the total number of Nvidia GPUs and 
                // add them to the graphics card ComboBox
                for (uint i = 0; i < s_numOfGpus; i++)
                {
                    GraphicsCardComboBox.Items.Add(s_graphicsCard.GetName(i));
                }
            }
            catch (Exception ex)
            {
                // let the user know an error occurred resetting the application
                throw new Exception("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Get the selected base voltage of the GPU and returns the result as a string
        /// </summary>
        /// <param name="baseVoltageNum">The base voltage number</param>
        /// <returns>The selected base voltage value as a string</returns>
        string GetBaseVoltageResult(uint baseVoltageNum)
        {
            string baseVoltageMessage;   // message containing the base voltage result

            try
            {
                // get the selected GPU base voltage and convert it to a string
                // add the unit type for the user
                baseVoltageMessage  = "GPU base voltage " + baseVoltageNum.ToString() + ": " 
                                    + s_graphicsCard.GetBaseVoltage(s_selectedGpu, baseVoltageNum).ToString() 
                                    + " uV";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU base voltage
                baseVoltageMessage = "ERROR: Could not get GPU base voltage " + baseVoltageNum.ToString() + ". " + ex.Message;
            }

            // return the base voltage message
            return baseVoltageMessage;
        }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Test Panel Initialization Method
        /// Finds all graphics cards available in the system to test
        /// </summary>
        public GraphicsCardTestPanel()
        {
            InitializeComponent();  // default constructor method
            
            // reset the application to a default state
            try
            {
                ResetApplication();
            }
            catch (Exception ex)
            {
                // display a message to the user that an error occurred
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Event that occurs when the user selects a graphics card to test
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void GraphicsCardComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check if the index selected is not a blank value
            if (GraphicsCardComboBox.SelectedItem.ToString() != string.Empty)
            {
                TestButton.Enabled = true;
            }
        }

        /// <summary>
        /// Event that lets the user reset the TestPanel application
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult resetResult = MessageBox.Show("Reset the application?", "Reset Application", MessageBoxButtons.YesNo);

            // determine if the user wants to reset the application
            if (resetResult == DialogResult.Yes)
            {
                try
                {
                    // the user wants to reset the application
                    ResetApplication();
                }
                catch (Exception ex)
                {
                    // an error occurred resetting the application
                    // display the message to the user
                    MessageBox.Show("Error resetting the application. " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Event that occurs when the TestButton button is clicked
        /// </summary>
        /// <param name="sender">Reference to the object that raised the eventparam>
        /// <param name="e">Object to the specific event</param>
        private void TestButton_Click(object sender, EventArgs e)
        {
            // set the selectd graphics card handler number to the selected ComboBox index number
            s_selectedGpu = (uint)GraphicsCardComboBox.SelectedIndex;

            // enable all test buttons
            EnableTestButtons();
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get GPU Core Count" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void CoreCountButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU core count for the selected GPU and convert it to a string
                resultMessage = "GPU core count: " + s_graphicsCard.GetGpuCoreCount(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting
                resultMessage = "ERROR: Could not get GPU core count. " + ex.Message;
            }
            finally
            {
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Name" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void NameButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // set the result to the graphics card name of the selected GPU
                resultMessage = "Graphics card name: " + s_graphicsCard.GetName(s_selectedGpu);
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the graphics card name
                resultMessage = "ERROR: Could not get graphics card name. " + ex.Message;
            }
            finally
            {
                // display the message to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get VBIOS Info" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void VbiosButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the VBIOS version info of the selected GPU
                resultMessage = "VBIOS info: " + s_graphicsCard.GetVBiosInfo(s_selectedGpu);
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the graphics card VBIOS info
                resultMessage = "ERROR: Could not get VBIOS info. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Virtual RAM Size" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void VirtualRamButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the virtual RAM size and convert it to a string
                // also add the unit type (KB) for the user
                resultMessage = "Virtual RAM size: " + s_graphicsCard.GetVirtualRamSize(s_selectedGpu).ToString() + " KB";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the virtual RAM size
                resultMessage = "ERROR: Could not get virtual RAM size. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Physical RAM Size" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PhysicalRamButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the physical RAM size of the selected GPU and convert it to a string
                // to display it to the user. Also add the unit type
                resultMessage = "Physical RAM size: " + s_graphicsCard.GetPhysicalRamSize(s_selectedGpu).ToString() + " KB";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU physical RAM size
                resultMessage = "ERROR: Could not get physical RAM size. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Serial Number" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void SerialNumberButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to the display to the user

            try
            {
                // get the serial number of the selected GPU and display it to the user
                resultMessage = "Serial Number: " + s_graphicsCard.GetCardSerialNumber(s_selectedGpu);
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the graphcis card serial number
                resultMessage = "ERROR: Could not get graphics card serial number. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get PCI Internal ID" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PciInternalIdButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU PCI internal ID number and convert it to a string
                resultMessage = "GPU PCI internal ID: " + s_graphicsCard.GetGpuPciInternalDeviceId(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the PCI internal ID
                resultMessage = "ERROR: Could not get GPU PCI internal ID. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get PCI Rev ID" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PciRevButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU PCI revision ID and convert it to a string
                resultMessage = "GPU PCI rev ID: " + s_graphicsCard.GetGpuPciRevId(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU PCI rev ID
                resultMessage = "ERROR: Could not get PCI revision ID. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get PCI Subsystem ID" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PciSubsystemIdButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU PCI subsystem ID and convert it to a string
                resultMessage = "GPU PCI subsystem ID: " + s_graphicsCard.GetGpuPciSubSystemId(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU PCI subsystem ID
                resultMessage = "ERROR: Could not get GPU PCI subsystem ID. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get PCI External ID" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PciExternalIdButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU PCI external ID and convert it to a string
                resultMessage = "GPU PCI external ID: " + s_graphicsCard.GetGpuPciExternalDeviceId(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU PCI external ID
                resultMessage = "ERROR: Could not get PCI external ID. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Bus ID" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BusIdButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU bus ID and convert it to a string
                resultMessage = "GPU bus ID: " + s_graphicsCard.GetGpuBusId(s_selectedGpu).ToString();
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU bus ID
                resultMessage = "ERROR: Could not get GPU bus ID. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get GPU Fan Speed" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specfic event</param>
        private void FanSpeedButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU heatsink fan speed and convert it to a string
                // also add the unit type for the user
                resultMessage = "GPU fan speed: " + s_graphicsCard.GetGpuFanSpeed(s_selectedGpu).ToString() + " RPM";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU fan speed
                resultMessage = "ERROR: Could not get GPU fan speed. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get GPU Core Temp" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void CoreTempButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU core temperature and convert it to a string
                // also add the unit type for the user
                resultMessage = "GPU core temperature: " + s_graphicsCard.GetGpuCoreTemp(s_selectedGpu).ToString() + " C";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the GPU core temperature
                resultMessage = "ERROR: Could not get GPU core temperature. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Memory Temp" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void MemoryTempButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the memory (RAM) temperature and convert it to a string
                // also add the unit type for the user
                resultMessage = "GPU memory temperature: " + s_graphicsCard.GetMemoryTemp(s_selectedGpu).ToString() + " C";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the memory (RAM) temperature
                resultMessage = "ERROR: Could not get memory temperature. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Power Supply Temp" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PowerSupplyTempButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU power supply temperature and conver it to a string
                // also add the unit type for the user
                resultMessage = "GPU power supply temperature: " + s_graphicsCard.GetPowerSupplyTemp(s_selectedGpu).ToString() + " C";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the power supply temperature
                resultMessage = "ERROR: Could not get power supply temperature. " + ex.Message;
            }
            finally
            {
                // display the result to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Board Temp" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BoardTempButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the graphics card board temperature and conver it to a string
                // also add the unit type for the user
                resultMessage = "Board temperature: " + s_graphicsCard.GetBoardTemp(s_selectedGpu).ToString() + " C";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the graphics card board temperature
                resultMessage = "ERROR: Could not get board temperature. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Current Performance State" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void PerfStateButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the current performance state of the graphics card
                resultMessage = "Current performance state: " + s_graphicsCard.GetCurrentPerformanceState(s_selectedGpu);
            }
            catch (Exception ex)
            {
                // let the user know an error occured when getting the current performance state
                resultMessage = "ERROR: Could not get graphics card performance state. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Base Clock Frequency" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BaseClockFreqButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the GPU base clock frequency and convert it to a string
                // also add the unit type for the user
                resultMessage = "Base clock frequency: " + s_graphicsCard.GetGraphicsBaseClockFreq(s_selectedGpu).ToString() + " kHz";
            }
            catch (Exception ex)
            {
                // let the user know an error occured getting the base clock frequency of the GPU
                resultMessage = "ERROR: Could not get base clock frequency. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Current Clock Frequency" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void CurrentClockFreqButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;    // the result to display to the user

            try
            {
                // get the current GPU processor clock frequency and convert it to a string
                // also add the unit type for the user
                resultMessage = "Current clock frequency: " + s_graphicsCard.GetGraphicsCurrentClockFreq(s_selectedGpu).ToString() + "kHz";
            }
            catch (Exception ex)
            {
                // let the user know an error occurred getting the current GPU processor clock frequency
                resultMessage = "ERROR: Could not get current clock frequency. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Boost Clock Frequency" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BoostClockFreqButton_Click(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;

            try
            {
                // get the GPU processor boost clock frequency and convert it to a string
                // also add the unit type for the user
                resultMessage = "Boost clock frequency: " + s_graphicsCard.GetGraphicsBoostClockFreq(s_selectedGpu).ToString() + " kHz";
            }
            catch (Exception ex) 
            {
                // let the user know an error occurred getting the GPU processor boost clock frequency
                resultMessage = "ERROR: Could not get boost clock frequency. " + ex.Message;
            }
            finally
            {
                // display the results to the user
                MessageBox.Show(resultMessage);
            }
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Base Voltage 1" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BaseVoltage1Button_Click(object sender, EventArgs e)
        {
            // get the GPU base voltage 1
            MessageBox.Show(GetBaseVoltageResult(1));
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Base Voltage 2" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BaseVoltage2Button_Click(object sender, EventArgs e)
        {
            // get the GPU base voltage 2
            MessageBox.Show(GetBaseVoltageResult(2));
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Base Voltage 3" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BaseVoltage3Button_Click(object sender, EventArgs e)
        {
            // get the GPU base voltage 3
            MessageBox.Show(GetBaseVoltageResult(3));
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Get Base Voltage 4" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void BaseVoltage4Button_Click(object sender, EventArgs e)
        {
            // get the GPU base voltage 4
            MessageBox.Show(GetBaseVoltageResult(4));
        }

        /// <summary>
        /// Event that occurs when the user clicks the "Exit" button
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Object to the specific event</param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            // ask the user if they want to close the application
            DialogResult userResult = MessageBox.Show("Exit the application?", "TestPanel Application", MessageBoxButtons.YesNo);

            // check if the user wants to close the application
            if (userResult == DialogResult.Yes)
            {
                // close the test application
                this.Close();
            }
        }

        #endregion
    }
}
