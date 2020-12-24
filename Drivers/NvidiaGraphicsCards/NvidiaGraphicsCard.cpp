/**************************************************************************************
* File: NvidiaGraphicsCard.cpp
*
* Original Author: Anthony Alexander
*
* Description:	Source file that implements interface IGraphicsCard functions
*				and function prototypes for the CommonApiWrapper class.
*				Wrapper class that wraps Nvidia's API functionality into a class
*				that can be inherited by other Nvidia graphics card classes
*
* Date:			Author:				Description of Change:
* 07/16/2020	Anthony Alexander	Initial Creation
***************************************************************************************/
#include "GraphicsCards_pch.h"		// pre-compiled header file
#include "NvidiaGraphicsCards.h"	// contains function prototypes for this class

namespace GraphicsCards
{
	///********************************************************************************
	/// Private Class Methods
	///********************************************************************************

	/// <summary>
	/// Gets the API status error message
	/// </summary>
	/// <param name="apiStat"> The API status</param>
	/// <returns>The API error message as a System::String type</returns>
	String^ NvidiaGraphicsCard::GetApiErrMsg(NvAPI_Status apiStat)
	{
		try
		{
			// variable to store the API error message
			NvAPI_ShortString errMsg = "\0";

			// get the API status error message
			_apiStatus = NvAPI_GetErrorMessage(apiStat, errMsg);

			// if the API status is not ok, default the API error message
			if (_apiStatus != NVAPI_OK)
			{
				strcpy_s(errMsg, sizeof(errMsg), "Could not determine API error message");
			}
			
			return gcnew String(errMsg);
		}
		catch (Exception^ ex)
		{
			// throw an exception to let the user know an error occurred
			String^ msg = "Error determining API error. " + ex->Message;
			throw gcnew Exception(msg);
		}
	}

	/// <summary>
	/// Gets all physical GPU handlers in the system
	/// </summary>
	/// <returns>true if API successfully gets all GPU handlers; false otherwise</returns>
	bool NvidiaGraphicsCard::GetPhysicalHandlers()
	{
		try
		{
			// check if the API has been initialized and is ready for use
			if (_apiInit && _apiStatus == NVAPI_OK)
			{
				// variable to store the number of physical handlers in the system
				NvU32 numHandlers;

				// get all physical GPUs in the system and store them in memory
				// with the NvPhysicalGpuHandle member pointing to the memory location
				_apiStatus = NvAPI_EnumTCCPhysicalGPUs(_physicalHandlers, &numHandlers);

				// check if the API successfully obtained all physical handlers
				if (_apiStatus == NVAPI_OK)
				{
					// API was successful, set number of handlers obtained
					// return true since successful
					_numPhysHandlers = numHandlers;
					return true;
				}
				else
				{
					// get the API error message
					String^ errMsg = GetApiErrMsg(_apiStatus);

					// delete any data stored within at the handler address
					// and re-assign the handler pointer to a nullptr
					delete _physicalHandlers;
					_physicalHandlers = NULL;

					// throw an exception to let the user know the API error
					throw gcnew Exception(errMsg);
				}
			}
			else
			{
				// throw an exception to inform the user of the API status
				throw gcnew Exception("API must be initialized and OK before obtaining physical handlers.");
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred obtaining the GPU handlers
			String^ errMsg = "Error occurred obtaining GPU physical handlers. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the default error message when the user incorrectly uses the driver
	/// </summary>
	/// <returns>An error message as a System::String type</returns>
	String^ NvidiaGraphicsCard::GetDefaultErrMsg()
	{
		try
		{
			// the default error message
			String^ defaultMsg = "";

			// if the API is not initialize, let the user know to initialize the API first
			if (!_apiInit)
			{
				defaultMsg = "API must be initialized first.";
			}

			// if the API status is not ok, let the user know the API error message
			if (_apiStatus != NVAPI_OK)
			{
				defaultMsg = GetApiErrMsg(_apiStatus);
			}

			// if the GPU handlers have not been initialized, let the user know 
			// to initialize the handlers first
			if (!_handlersInit)
			{
				defaultMsg = "GPU handlers must be initialized first.";
			}

			// return the default error message
			return defaultMsg;
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred finding the default error message
			String^ errMsg = "Could not determine default error message. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets all GPU PCI Identifiers
	/// </summary>
	/// <param name="physHandlerNum">the physical hander index in memory</param>
	/// <param name="ptrPciIdentifiers">pointer to the PciIdentifiers member</param>
	void NvidiaGraphicsCard::GetPciIds(ULONG physHandlerNum, PciIdentifiers^ ptrPciIdentifiers)
	{
		try
		{
			NvU32 internalId	= 0;	// GPU PCI internal ID
			NvU32 subsystemId	= 0;	// GPU PCI subsystem PCI ID
			NvU32 revId			= 0;	// GPU PCI revision ID
			NvU32 externalId	= 0;	// GPU PCI external ID

			// get all PCI IDs for the GPU
			_apiStatus = NvAPI_GPU_GetPCIIdentifiers(_physicalHandlers[physHandlerNum], &internalId, &subsystemId, &revId, &externalId);

			// check if the API successfully obtained the PCI IDs for the GPU
			if (_apiStatus == NVAPI_OK)
			{
				// the API successfully obtained the PCI IDs
				// set all PciIdentifier member values
				ptrPciIdentifiers->hasIdInfo	= true;
				ptrPciIdentifiers->internalId	= internalId;
				ptrPciIdentifiers->subsystemId	= subsystemId;
				ptrPciIdentifiers->revId		= revId;
				ptrPciIdentifiers->externalId	= externalId;
			}
			else
			{
				// just in case, default all PCI ID values
				ptrPciIdentifiers->hasIdInfo	= false;
				ptrPciIdentifiers->internalId	= 0;
				ptrPciIdentifiers->subsystemId	= 0;
				ptrPciIdentifiers->revId		= 0;
				ptrPciIdentifiers->externalId	= 0;

				// let the user know there was an API error
				throw gcnew Exception(GetApiErrMsg(_apiStatus));
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred obtaining all GPU PCI identifiers
			String^ errMsg = "Could not get all GPU PCI identifiers. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Checks if the handler index is valid. This prevents the user from using an index
	/// number that is greater than the total number of handlers available in the system
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>true, if the handler index is valid</returns>
	bool NvidiaGraphicsCard::IsHandlerIndexValid(ULONG physHandlerNum)
	{
		// check if the handler index number if valid
		if (physHandlerNum > (_numPhysHandlers - 1))
		{
			// let the user know the handler index is invalid
			throw gcnew Exception("Physical handler number greater than total number of handlers.");
		}

		// return true since the handler index is valid
		return true;
	}

	/// <summary>
	/// Gets the thermal device name based on the NV_THERMAL_TARGET type
	/// </summary>
	/// <param name="deviceType">The NV_THERMAL_TARGET device type</param>
	/// <returns>Name of the thermal device as a System::String</returns>
	String^ NvidiaGraphicsCard::GetTempDeviceName(NV_THERMAL_TARGET deviceType)
	{
		String^ deviceName = "";

		// determine the type of thermal device under test and assign the appropriate name
		switch (deviceType)
		{
			case NVAPI_THERMAL_TARGET_GPU:
				deviceName = "GPU";
				break;
			case NVAPI_THERMAL_TARGET_MEMORY:
				deviceName = "Memory";
				break;
			case NVAPI_THERMAL_TARGET_POWER_SUPPLY:
				deviceName = "Power supply";
				break;
			case NVAPI_THERMAL_TARGET_BOARD:
				deviceName = "Board";
				break;
			case NVAPI_THERMAL_TARGET_VCD_BOARD:
				deviceName = "VCD Board";
				break;
			case NVAPI_THERMAL_TARGET_VCD_INLET:
				deviceName = "VCD Inlet";
				break;
			case NVAPI_THERMAL_TARGET_VCD_OUTLET:
				deviceName = "VCD Outlet";
				break;
			// if the target is all, known, or unknown, use the default case
			// since this method is meant for a single device type
			case NVAPI_THERMAL_TARGET_ALL:
			case NVAPI_THERMAL_TARGET_NONE:
			case NVAPI_THERMAL_TARGET_UNKNOWN:
			default:
				deviceName = "Unknown";
				break;
		}

		// return the device name
		return deviceName;
	}

	/// <summary>
	/// Gets the temperature for a specific thermal sensor device
	/// </summary>
	/// <param name="physHandler">The GPU physical handler</param>
	/// <param name="deviceType">The NV_THERMAL_TARGET device type</param>
	/// <param name="ptrDeviceTemp">Pointer to the data to store the device temperature</param>
	/// <returns>true if the selected device temperature is obtained</returns>
	bool NvidiaGraphicsCard::GetDeviceTemperature(NvPhysicalGpuHandle physHandler, NV_THERMAL_TARGET deviceType, float* ptrDeviceTemp)
	{
		try
		{
			// check if the device temperature pointer is null
			if (ptrDeviceTemp == NULL)
			{
				throw gcnew Exception("Null pointer to device temperature value used.");
			}
			else
			{
				bool						success = true;	// determines if API successfully get the thermal settings for the selected device
				NV_GPU_THERMAL_SETTINGS_V2* ptrThermalSettings = 0;	// pointer to the device thermal settings data

				// get the thermal settings for the thermal device
				// ptrThermalSettings will point to the address where the data of the thermal device is stored
				_apiStatus = NvAPI_GPU_GetThermalSettings(physHandler, deviceType, ptrThermalSettings);

				// check if the API successfully obtained the device thermal settings
				if (_apiStatus == NVAPI_OK && ptrThermalSettings != NULL)
				{
					// the API obtained the device temperature
					// set the value of the device temperature by dereferencing the pointer
					*ptrDeviceTemp = static_cast<float>(ptrThermalSettings[0].sensor[0].currentTemp);
				}
				else
				{
					// delete any data from the thermal settings pointer and
					// set the thermal settings pointer to null to ensure the pointer is not floating
					delete ptrThermalSettings;
					ptrThermalSettings = NULL;

					// let the user know an API error occurred
					throw gcnew Exception(GetApiErrMsg(_apiStatus));
				}

				// return if thermal settings were successfully obtained
				return success;
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the device temperature
			String^ errMsg = "Could not get " + GetTempDeviceName(deviceType) + " temperature. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the System::String equivalent of the NV_GPU_PUBLIC_ClOCK_ID variable
	/// </summary>
	/// <param name="clockId">The NV_GPU_PUBLIC_CLOCK_ID enum variable</param>
	/// <returns>The GPU public clock ID as a System::String</returns>
	String^ NvidiaGraphicsCard::GetClockIdType(NV_GPU_PUBLIC_CLOCK_ID clockId)
	{
		String^ clockIdType = "";	// the clock ID type

		// determine the type of clock ID from the clockId parameter
		switch (clockId)
		{
			case NVAPI_GPU_PUBLIC_CLOCK_GRAPHICS:
				clockIdType = "Graphics";
				break;
			case NVAPI_GPU_PUBLIC_CLOCK_MEMORY:
				clockIdType = "Memory";
				break;
			case NVAPI_GPU_PUBLIC_CLOCK_PROCESSOR:
				clockIdType = "Processor";
				break;
			case NVAPI_GPU_PUBLIC_CLOCK_VIDEO:
				clockIdType = "Video";
				break;
			case NVAPI_GPU_PUBLIC_CLOCK_UNDEFINED:
			default:
				clockIdType = "Unknown";
				break;
		}

		// return the clock ID type as a System::String
		return clockIdType;
	}

	/// <summary>
	/// Gets the System::String equivalent of the GPU clock frequency type
	/// </summary>
	/// <param name="clockType">The clock frequency type as a NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE enum</param>
	/// <returns>The GPU clock frequency type as a System::String</returns>
	String^ NvidiaGraphicsCard::GetClockType(NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType)
	{
		String^ clockTypeString = "";	// the System::String equivalent of the GPU clock type

		// determine the type of clock frequency from the clockType parameter
		switch (clockType)
		{
			case NV_GPU_CLOCK_FREQUENCIES_BASE_CLOCK:
				clockTypeString = "Base";
				break;
			case NV_GPU_CLOCK_FREQUENCIES_BOOST_CLOCK:
				clockTypeString = "Boost";
				break;
			case NV_GPU_CLOCK_FREQUENCIES_CURRENT_FREQ:
				clockTypeString = "Current";
				break;
			case NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE_NUM:
				clockTypeString = "Clock number";
				break;
			default:
				clockTypeString = "Unknown";
				break;
		}

		// return the clock type string
		return clockTypeString;
	}

	/// <summary>
	/// Gets the clock frequency for a specified clock and clock type on the GPU in kHz
	/// </summary>
	/// <param name="physHandler">The physical GPU handler in memory</param>
	/// <param name="clockId">The ID of the clock to obtain the data for</param>
	/// <param name="clockType">The type of clock frequency to get (i.e. base, current, boost)</param>
	/// <param name="ptrClockSpeed">pointer pointing the data storing the clock frequency</param>
	/// <returns>true if the API successfully gets the clock frequency; false otherwise</returns>
	bool NvidiaGraphicsCard::GetClockFrequency(NvPhysicalGpuHandle physHandler, NV_GPU_PUBLIC_CLOCK_ID clockId, NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType, float* ptrClockSpeed)
	{
		try
		{
			bool						success					= true;		// determines if clock frequency is successfully obtained
			NV_GPU_CLOCK_FREQUENCIES	clockFrequencies		= { 0 };	// struct containing all GPU clock data

			// get the clock frequency data for specific GPU clock type
			_apiStatus = NvAPI_GPU_GetAllClockFrequencies(physHandler, &clockFrequencies);

			// check if the API successfully obtained all GPU clock frequencies
			if (_apiStatus == NVAPI_OK)
			{
				// set the clock type to be returned
				clockFrequencies.ClockType = clockType;

				// assign the clock frequency data using the clock ID and clock type
				*ptrClockSpeed = static_cast<float>(clockFrequencies.domain[clockId].frequency);
			}
			else
			{
				// let the user know an API error occurred
				throw gcnew Exception(GetApiErrMsg(_apiStatus));
			}

			// return if the clock frequency was successfully obtained or not
			return success;
		}
		catch (Exception^ ex)
		{
			// let the user know that the clock frequency could not be obtained
			String^ errMsg	= "Error getting " + GetClockType(clockType) + " of the " 
							+ GetClockIdType(clockId) + ". " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU performance state ID code ranging from P0-P20
	/// </summary>
	/// <param name="physHandler">The physical handler index in memory</param>
	/// <returns>The GPU performance state ID as a NV_GPU_PERF_PSTATE_ID enum</returns>
	NV_GPU_PERF_PSTATE_ID NvidiaGraphicsCard::GetPerformanceStateId(NvPhysicalGpuHandle physHandler)
	{
		try
		{
			NV_GPU_PERF_PSTATE_ID gpuStateId;	// the GPU performance state ID

			// get the GPU performance state
			_apiStatus = NvAPI_GPU_GetCurrentPstate(physHandler, &gpuStateId);

			// check if the API successfully obtained the GPU performance state ID
			if (_apiStatus == NVAPI_OK)
			{
				// return the GPU performance state ID stored
				return gpuStateId;
			}
			else
			{
				// let the user know an API error occurred
				throw gcnew Exception(GetApiErrMsg(_apiStatus));
			}
		}
		catch (Exception^ ex)
		{
			// let the user know the GPU performance state ID could not be obtained
			String^ errMsg = "Could not get GPU performance state ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU performances state as a System::String
	/// </summary>
	/// <param name="perfState">GPU performances state ID (P0-P20)</param>
	/// <returns>The GPU performance state as a System::String</returns>
	String^ NvidiaGraphicsCard::GetPerformanceState(NV_GPU_PERF_PSTATE_ID perfState)
	{
		String^ performanceState = "";	// the GPU performance state

		// determine the type of performance state the GPU is in
		// and set the string representation accordingly
		// performance state ranges and definitions can be found in NVAPI documentation
		switch (perfState)
		{
			case NVAPI_GPU_PERF_PSTATE_P0:
			case NVAPI_GPU_PERF_PSTATE_P1:
				performanceState = "Max 3D";
				break;
			case NVAPI_GPU_PERF_PSTATE_P2:
			case NVAPI_GPU_PERF_PSTATE_P3:
				performanceState = "Balanced 3D";
				break;
			case NVAPI_GPU_PERF_PSTATE_P8:
				performanceState = "Basic HD playback";
				break;
			case NVAPI_GPU_PERF_PSTATE_P10:
				performanceState = "DVD playback";
				break;
			case NVAPI_GPU_PERF_PSTATE_P12:
				performanceState = "Minimum power consumption";
				break;
			default:
				performanceState = "Unknown";
				break;
		}

		// return the performance state of the GPU
		return performanceState;
	}

	///********************************************************************************
	/// Public Class Methods
	///********************************************************************************

	/// <summary>
	/// Constructor for CommonApiWrapper object
	/// </summary>
	NvidiaGraphicsCard::NvidiaGraphicsCard()
	{
		// default all class members
		_apiStatus					= NVAPI_API_NOT_INITIALIZED;
		_apiInit					= false;
		_handlersInit				= false;
		_physicalHandlers			= 0;
		_numPhysHandlers			= 0;
		_pciIdentities->hasIdInfo	= false;
		_pciIdentities->internalId	= 0;
		_pciIdentities->revId		= 0;
		_pciIdentities->subsystemId = 0;
		_pciIdentities->externalId	= 0;
	}

	/// <summary>
	/// Destructor for CommonApiWrapper object
	/// </summary>
	NvidiaGraphicsCard::~NvidiaGraphicsCard()
	{
		// free the physical GPUs and PCI identifier data from memory
		// and set the physical GPU handler pointer to null
		// all other class members will be deleted from memory on their own
		delete _physicalHandlers, _pciIdentities;
		_physicalHandlers = NULL;
	}

	/// <summary>
	/// Initializes the Nvidia graphics card API
	/// </summary>
	/// <returns>
	/// true if the Nvidia graphics card API initialized successfully;
	/// false otherwise
	/// </returns>
	bool NvidiaGraphicsCard::InitializeApi()
	{
		try
		{
			// initialize the Nvidia API
			_apiStatus = NvAPI_Initialize();

			// check if the API successfully initialized
			if (_apiStatus == NVAPI_OK)
			{
				// the API successfully initialized, return true
				_apiInit = true;
				return _apiInit;
			}
			else
			{
				// set the API initialization status to false
				_apiInit = false;

				// throw an exception to let the user know the API error that occurred
				throw gcnew Exception(GetApiErrMsg(_apiStatus));
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred initializing the API
			String^ errMsg = "Error initializing API. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Initializes all handlers for the GPUs in the system
	/// </summary>
	/// <returns>true if all GPU handlers successfully initialized; false otherwise</returns>
	bool NvidiaGraphicsCard::InitializeHandlers()
	{
		try
		{
			// initialize the gpu handlers
			return _handlersInit = GetPhysicalHandlers();
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred initializing graphics card handlers
			String^ errMsg = "Error occurred in initializing handlers. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the total number of GPU handlers in the system
	/// </summary>
	/// <returns>The total number of GPU handlers in the system as an unsigned long</returns>
	unsigned long NvidiaGraphicsCard::GetNumHandlers()
	{
		try
		{
			// check if API is initialize and okay
			// also check if the GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// API is good and handlers are initialized
				// return the number of GPU handlers
				return _numPhysHandlers;
			}
			else
			{
				// something is wrong with the API or GPU handlers
				// determine the default error and throw it as an exception
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred obtaining the number of GPU handlers
			String^ errMsg = "Could not get number of physical handlers. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the total number of GPU cores for the graphics card
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The number of GPU cores for the graphics card as an unsigned long</returns>
	ULONG NvidiaGraphicsCard::GetGpuCoreCount(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is initialized and ready
			// also check if the GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the physical handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvU32 numCores; // stores the number of GPU cores

					// get the number of GPU cores for the selected physical handler
					_apiStatus = NvAPI_GPU_GetGpuCoreCount(_physicalHandlers[physHandlerNum], &numCores);

					// check if the API okay after trying to obtain number of GPU cores
					if (_apiStatus == NVAPI_OK)
					{
						// API is okay, return the number of GPU cores
						return numCores;
					}
					else
					{
						// error occurred with API
						// determine API error and throw it as an exception
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// there is an issue with the API or GPU handlers
				// throw an exception to let the user know
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred obtaining GPU core count
			String^ errMsg = "Could not get GPU core count. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the full name of the graphics card
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The graphics card name as a System::String type</returns>
	String^ NvidiaGraphicsCard::GetName(ULONG physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if the GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the physical handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvAPI_ShortString name;	// stores the graphics card name

					// use the physical handler to get the selected graphics card name
					_apiStatus = NvAPI_GPU_GetFullName(_physicalHandlers[physHandlerNum], name);

					// check if the API status is ok
					if (_apiStatus == NVAPI_OK)
					{
						// API is ok, return the graphics card name
						return gcnew String(name);
					}
					else
					{
						// an API error occurred
						// throw an exception to let the user know
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// there is an issue with the API or GPU handlers
				// throw an exception to let the user know
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred obtaining the graphics card name
			String^ errMsg = "Could not get graphics card name. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the VBIOS information for the GPU
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The GPU VBIOS information as a System::String</returns>
	String^ NvidiaGraphicsCard::GetVBiosInfo(ULONG physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the selected handler index is invalid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvAPI_ShortString vbiosInfo;	// stores the VBIOS info

					// get the VBIO information for the selected GPU
					_apiStatus = NvAPI_GPU_GetVbiosVersionString(_physicalHandlers[physHandlerNum], vbiosInfo);

					// check if API is ok
					if (_apiStatus == NVAPI_OK)
					{
						// API is okay, return the VBIO info
						return gcnew String(vbiosInfo);
					}
					else
					{
						// let the user know an API error occurred
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or GPU handlers
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting graphics card VBIOS info
			String^ errMsg = "Could not get VBIOS info. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the virtual RAM size (physical RAM size and any allocated RAM for the GPU)
	/// used by the GPU in KB
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The virtual RAM size used by the GPU in KB as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetVirtualRamSize(ULONG physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if GPU handlers are initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if handler index selected is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvU32 virtualRamSize;	// stores virtual RAM size in KB

					// get the virtual RAM size of the selected handler
					_apiStatus = NvAPI_GPU_GetVirtualFrameBufferSize(_physicalHandlers[physHandlerNum], &virtualRamSize);

					// check if the API status is ok
					if (_apiStatus == NVAPI_OK)
					{
						// API is ok, return the virtual RAM size in KB
						return virtualRamSize;
					}
					else
					{
						// let the user know an API error occurred
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or GPU handlers
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting GPU virtual RAM size
			String^ errMsg = "Could not get virtual RAM size. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the physical RAM size of the GPU in KB
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The physical RAM of the GPU in KB as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetPhysicalRamSize(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handlers are initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvU32 physRamSize; // the physical GPU RAM size in KB

					// get the physical RAM size of the selected GPU
					_apiStatus = NvAPI_GPU_GetPhysicalFrameBufferSize(_physicalHandlers[physHandlerNum], &physRamSize);

					// check if the API succesfully obtained the GPU Physical RAM size
					if (_apiStatus == NVAPI_OK)
					{
						// API successfully obtained physical RAM size
						// return the GPU physical RAM size in KB
						return physRamSize;
					}
					else
					{
						// let the user know an error occurred with the API
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or GPU handlers
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting physical RAM size
			String^ errMsg = "Could not get physicalRamSize. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the serial number of the graphics card
	/// </summary>
	/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
	/// <returns>The graphics card serial number as a System::String</returns>
	String^ NvidiaGraphicsCard::GetCardSerialNumber(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler have been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NV_BOARD_INFO boardInfo;	// variable to store the graphics card info

					// get the graphics card information for the selected GPU
					_apiStatus = NvAPI_GPU_GetBoardInfo(_physicalHandlers[physHandlerNum], &boardInfo);

					// check if the API successfully obtained information for the graphics card
					if (_apiStatus == NVAPI_OK)
					{
						// the API was successful
						// store the board serial number
						return gcnew String((const char*)boardInfo.BoardNum);
					}
					else
					{
						// let the user know an error occurred with the API
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an API or GPU handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred get the graphics card info
			String^ errMsg = "Could not get graphics card information. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU PCI internal device ID
	/// </summary>
	/// <param name="physHandlerNum">the physical handler index number in memory</param>
	/// <returns>the GPU PCI internal device ID as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuPciInternalDeviceId(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler have been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					// check if the the PCI IDs have not been obtained
					if (!_pciIdentities->hasIdInfo)
					{
						GetPciIds(physHandlerNum, _pciIdentities);
					}

					// return the internal GPU PCI ID
					return _pciIdentities->internalId;
				}
			}
			else
			{
				// let the user know there is an API or GPU handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occured getting the GPU PCI internal device ID
			String^ errMsg = "Could not get GPU PCI internal device ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU PCI revision ID
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU PCI revision ID as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuPciRevId(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler has been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					// check if the PCI IDs have not been obtained yet
					if (!_pciIdentities->hasIdInfo)
					{
						// PCI IDs have not been obtained yet so get them first
						GetPciIds(physHandlerNum, _pciIdentities);
					}

					// return the PCI revision ID
					return _pciIdentities->revId;
				}
			}
			else
			{
				// let the user know there is an API or GPU handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occured getting the GPU PCI rev ID
			String^ errMsg = "Could not get GPU PCI revision ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU PCI subsystem ID
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU PCI subsystem ID as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuPciSubSystemId(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler has been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index if valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					// check if the PCI IDs have not been obtained
					if (!_pciIdentities->hasIdInfo)
					{
						// GPU PCI IDs have not been obtained yet so go get them
						GetPciIds(physHandlerNum, _pciIdentities);
					}

					// return the PCI subsystem ID
					return _pciIdentities->subsystemId;
				}
			}
			else
			{
				// let the user know there is an API or GPU handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occured getting the GPU subsystem PCI ID
			String^ errMsg = "Could not get GPU PCI subsytem ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU PCI external ID
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index number in memory</param>
	/// <returns>The GPU PCI external ID as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuPciExternalDeviceId(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler has been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					// check if the GPU PCI IDs have not been obtained
					if (!_pciIdentities->hasIdInfo)
					{
						// GPU PCI IDs have not been obtained yet so go get them
						GetPciIds(physHandlerNum, _pciIdentities);
					}

					// return the PCI external ID
					return _pciIdentities->externalId;
				}
			}
			else
			{
				// let the user know there is an API or handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU external PCI ID
			String^ errMsg = "Could not get GPU PCI external ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU Bus ID
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index number in memory</param>
	/// <returns>The GPU Bus ID as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuBusId(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handlers have been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvU32 busID = 0;	// the GPU Bus ID

					// get the GPU Bus ID
					_apiStatus = NvAPI_GPU_GetBusId(_physicalHandlers[physHandlerNum], &busID);

					// check if the API successfully obtained the GPU bus ID
					if (_apiStatus == NVAPI_OK)
					{
						return busID;
					}
					else
					{
						// let the user know an API error occurred
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an API or handler issue
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU Bus ID
			String^ errMsg = "Could not get GPU Bus ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU core temperature in celsius
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU core temperature in celsius as a float</returns>
	float NvidiaGraphicsCard::GetGpuCoreTemp(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float coreTemp = 0;	// the GPU core temperature

					// get the GPU core temperature
					// method throws an exception if any errors occurr
					bool success = GetDeviceTemperature(_physicalHandlers[physHandlerNum], NVAPI_THERMAL_TARGET_GPU, &coreTemp);

					// check if the API successfully obtained the GPU temperature
					if (success)
					{
						// return the GPU core temperature
						return coreTemp;
					}
				}
			}
			else
			{
				// let the user know there is an API or handler error
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU core temperature
			String^ errMsg = "Could not get GPU core temperature. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU memory temperature in celsius
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>GPU memory temperature in celsius as a float</returns>
	float NvidiaGraphicsCard::GetMemoryTemp(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float memoryTemp = 0;	// the GPU memory temperature

					// get the GPU memory temperature
					// method throws an exception if any errors occurr
					bool success = GetDeviceTemperature(_physicalHandlers[physHandlerNum], NVAPI_THERMAL_TARGET_MEMORY, &memoryTemp);

					// check if the memory temperature was obtained successfully
					if (success)
					{
						return memoryTemp;
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU memory temperature
			String^ errMsg = "Could not get GPU memory temperature. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU power supply temperature in celsius
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU power supply temperature in celsius as a float</returns>
	float NvidiaGraphicsCard::GetPowerSupplyTemp(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float powerSupplyTemp = 0;	// the GPU power supply temperature

					// get the GPU power supply temperature
					// method throws an exception if any errors occurr
					bool success = GetDeviceTemperature(_physicalHandlers[physHandlerNum], NVAPI_THERMAL_TARGET_POWER_SUPPLY, &powerSupplyTemp);

					// check if the GPU power supply temperature was successfully obtained
					if (success)
					{
						return powerSupplyTemp;
					}
				}
			}
			else
			{
				// let the user know there is an error with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU power supply temperature
			String^ errMsg = "Could not get GPU power supply temperature. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU board temperature in celsius
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU board temperature in celsius as a float</returns>
	float NvidiaGraphicsCard::GetBoardTemp(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float boardTemp = 0;	// the GPU board temperature

					// get the GPU board temperature
					// method throws an exception if any errors occur
					bool success = GetDeviceTemperature(_physicalHandlers[physHandlerNum], NVAPI_THERMAL_TARGET_BOARD, &boardTemp);

					// check if the board temperature was succesfully obtained
					if (success)
					{
						return boardTemp;
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU board temperature
			String^ errMsg = "Could not get GPU board temperature. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU fanspeed in RPM
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU fanspeed in RPM as an unsigned int</returns>
	UINT NvidiaGraphicsCard::GetGpuFanSpeed(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					NvU32 fanSpeed = 0;		// the GPU fan speed reading

					// get the GPU fan speed
					_apiStatus = NvAPI_GPU_GetTachReading(_physicalHandlers[physHandlerNum], &fanSpeed);

					// check if the API successfully obtained the GPU fanspeed
					if (_apiStatus == NVAPI_OK)
					{
						// retunr the GPU fan speed
						return fanSpeed;
					}
					else
					{
						// let the user know an error occurred obtaining the GPU fanspeed
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the GPU fan speed
			String^ errMsg = "Could not get GPU fan speed. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the base clock speed of the GPU processor in kHz
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU processor base clock speed in kHz as a float</returns>
	float NvidiaGraphicsCard::GetProcessorBaseClockFreq(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float baseClockFreq = 0;	// the processor base clock frequency in kHz

					// get the processor base clock frequency
					// method throws an exception if an error occurs
					bool success = GetClockFrequency(	_physicalHandlers[physHandlerNum],		
														NVAPI_GPU_PUBLIC_CLOCK_PROCESSOR, 
														NV_GPU_CLOCK_FREQUENCIES_BASE_CLOCK,	
														&baseClockFreq
													);

					// check if the processor base clock frequency was successfully obtained
					if (success)
					{
						return baseClockFreq;
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting processor base clock frequency
			String^ errMsg = "Could not get processor base clock frequency. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU processor current clock frequency in kHz
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU processor current clock frequency in kHz as a float</returns>
	float NvidiaGraphicsCard::GetProcessorCurrentClockFreq(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float currentClockFreq = 0;	// the current clock frequency in kHz

					// get the current processor clock speed
					// method will throw an exception if any errors occur
					bool success = GetClockFrequency(	_physicalHandlers[physHandlerNum], 
														NVAPI_GPU_PUBLIC_CLOCK_PROCESSOR, 
														NV_GPU_CLOCK_FREQUENCIES_CURRENT_FREQ, 
														&currentClockFreq
													);

					// check if the API successfully obtained the current processor clock frequency
					if (success)
					{
						return currentClockFreq;
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting processor current clock frequency
			String^ errMsg = "Could not get processor current clock frequency. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the GPU processor boost clock frequency in kHz
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The GPU processor boost clock frequency in kHz as a float</returns>
	float NvidiaGraphicsCard::GetProcessorBoostClockFreq(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid or not
				if (IsHandlerIndexValid(physHandlerNum))
				{
					float boostClockFreq = 0;	// the processor boost clock frequency in kHz

					// get the processor boost clock frequency
					// method throws an exception if an error occurs
					bool success = GetClockFrequency(	_physicalHandlers[physHandlerNum], 
														NVAPI_GPU_PUBLIC_CLOCK_PROCESSOR, 
														NV_GPU_CLOCK_FREQUENCIES_BOOST_CLOCK, 
														&boostClockFreq
													);

					// check if the API successfully obtained the boost clock frequency
					if (success)
					{
						return boostClockFreq;
					}
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting processor boost clock frequency
			String^ errMsg = "Could not get processor boost clock frequency. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	/// <summary>
	/// Gets the current performance state setting of the GPU
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <returns>The current GPU performance state as a System::String</returns>
	String^ NvidiaGraphicsCard::GetCurrentPerformanceState(ULONG physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (IsHandlerIndexValid(physHandlerNum))
				{
					// get the current GPU performance state ID
					// method throws an exception if any errors occur
					NV_GPU_PERF_PSTATE_ID perfState = GetPerformanceStateId(_physicalHandlers[physHandlerNum]);

					// convert and return the current GPU performance state as a System::String
					return GetPerformanceState(perfState);
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occurred getting the current GPU performance state
			String^ errMsg = "Could not get current GPU performance state. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

	// WARNING: VISUAL STUDIO/RESHAPER C++ CAUSES COMPILER WARNING C6835
	// IN WHICH IT CANNOT UNDERSTAND THE RELATIONSHIP BETWEEN pStateBaseVoltage AND CURRENT pstate[i].baseVoltages
	// THIS IS A FALSE ALERT FROM THE ANALYZER SO ONLY IGNORING THE WARNING WITH VISUAL STUDIO
#pragma warning (push)
#pragma warning (disable : 6385)

	/// <summary>
	/// Gets the base voltage value in uV for the selected base voltage of the GPU based on the current
	/// performance state of the GPU.
	/// </summary>
	/// <param name="physHandlerNum">The physical handler index in memory</param>
	/// <param name="baseVoltageNum">The base voltage number for the GPU</param>
	/// <returns>The base voltage in uV as a float</returns>
	float NvidiaGraphicsCard::GetBaseVoltage(ULONG physHandlerNum, UINT baseVoltageNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler is initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				// also check if the base voltage number is valid as well
				if (IsHandlerIndexValid(physHandlerNum) && baseVoltageNum <= NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES)
				{
					// get the current GPU performance state ID
					// method throws an exception if any errors occur
					NV_GPU_PERF_PSTATE_ID perfState = GetPerformanceStateId(_physicalHandlers[physHandlerNum]);

					// pointer to the performance state information
					NV_GPU_PERF_PSTATES20_INFO_V2* ptrPerfStateInfo = new NV_GPU_PERF_PSTATES20_INFO_V2();

					// get the GPU performance state information
					_apiStatus = NvAPI_GPU_GetPstates20(_physicalHandlers[physHandlerNum], ptrPerfStateInfo);

					// check if the API successfully obtained the GPU performance information
					if (_apiStatus == NVAPI_OK)
					{
						float	baseVoltage		= 0;		// the GPU base voltage value
						bool	perfStateFound	= false;	// determines if the current GPU performance state is found
						
						// iterate through each performance state to find the current GPU performance state
						for (int i = 0; i < NVAPI_MAX_GPU_PSTATE20_PSTATES; i++)
						{
							// check if performance state info matches the current performance state
							if (ptrPerfStateInfo->pstates[i].pstateId == perfState)
							{
								// the current performance state ID is found
								// get the base voltage settings for the current performance state
								NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1 pStateBaseVoltage = ptrPerfStateInfo->pstates[i].baseVoltages[baseVoltageNum];

								// get the base voltage value and break from the loop
								baseVoltage = static_cast<float>(pStateBaseVoltage.volt_uV);
								perfStateFound = true;
								break;
							}
						}

						// delete the performance state information to free up the memory
						delete ptrPerfStateInfo;
						ptrPerfStateInfo = NULL;

						// check if the current performance state was not found
						if (!perfStateFound)
						{
							// let the user know that the GPU base voltage for the current performance
							// state could not be found
							throw gcnew Exception("Performance state " + GetPerformanceState(perfState) + " does not provide base voltage value.");
						}
						else
						{
							// return the base voltage value
							return baseVoltage;
						}
					}
					else
					{
						// delete the performance state information to free up the memory
						delete ptrPerfStateInfo;
						ptrPerfStateInfo = NULL;

						// let the user know an API error occurred
						throw gcnew Exception(GetApiErrMsg(_apiStatus));
					}
				}
				else
				{
					// the IsHandlerIndexValid method throws an exception if the handler index
					// is invalid. Executing this chunk means the base voltage number is invalid
					// throw an exception to let the user know
					String^ maxBaseVoltages = gcnew String(std::to_string(NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES).c_str());
					throw gcnew Exception("Base voltage number must range between 1 and " + maxBaseVoltages);
				}
			}
			else
			{
				// let the user know there is an issue with the API or handler
				throw gcnew Exception(GetDefaultErrMsg());
			}
		}
		catch (Exception^ ex)
		{
			// let the user know an error occrred getting the base voltage
			String^ baseNum = gcnew String(std::to_string(baseVoltageNum).c_str());
			String^ errMsg	= "Could not get base voltage for base voltage " + baseNum + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}

#pragma warning (pop)	// end #pragma warning (disable : 6385)
}
