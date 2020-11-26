/**************************************************************************************
File: CommonApiWrapper.cpp

Description: Source file that implements interface IGraphicsCard functions
			 and function prototypes for the CommonApiWrapper class.
			 Wrapper class that wraps Nvidia's API functionality into a class
			 that can be inherited by other Nvidia graphics card classes

Author(s): Anthony Alexander

Date:		Author				Description of Change
07/16/2020	Anthony Alexander	Initial Creation
***************************************************************************************/
#pragma once
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
	String^ Nvidia::CommonApiWrapper::GetApiErrMsg(NvAPI_Status apiStat)
	{
		try
		{
			// variable to store the API error message
			NvAPI_ShortString errMsg;

			// get the API status error message
			apiStat = NvAPI_GetErrorMessage(apiStat, errMsg);

			// if the API status is not ok, default the API error message
			if (apiStat != NVAPI_OK)
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
	bool Nvidia::CommonApiWrapper::GetPhysicalHandlers()
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
					_physicalHandlers = nullptr;

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
	String^ Nvidia::CommonApiWrapper::GetDefaultErrMsg()
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
	void Nvidia::CommonApiWrapper::GetPciIds(ULONG physHandlerNum, PciIdentifiers^ ptrPciIdentifiers)
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
	bool Nvidia::CommonApiWrapper::IsHandlerIndexValid(ULONG physHandlerNum)
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

	///********************************************************************************
	/// Public Class Methods
	///********************************************************************************

	/// <summary>
	/// Constructor for CommonApiWrapper object
	/// </summary>
	Nvidia::CommonApiWrapper::CommonApiWrapper()
	{
		// default all class members
		_apiStatus					= NVAPI_API_NOT_INITIALIZED;
		_apiInit					= false;
		_handlersInit				= false;
		_physicalHandlers			= nullptr;
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
	Nvidia::CommonApiWrapper::~CommonApiWrapper()
	{
	}

	/// <summary>
	/// Initializes the Nvidia graphics card API
	/// </summary>
	/// <returns>
	/// true if the Nvidia graphics card API initialized successfully;
	/// false otherwise
	/// </returns>
	bool Nvidia::CommonApiWrapper::InitializeApi()
	{
		try
		{
			// initialize the Nvidia API
			_apiStatus = NvAPI_Initialize();

			// check if the API successfully initialized
			if (_apiStatus == NVAPI_OK)
			{
				// the API successfully initialized, return true
				return _apiInit = true;
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
	bool Nvidia::CommonApiWrapper::InitializeHandlers()
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
	unsigned long Nvidia::CommonApiWrapper::GetNumHandlers()
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
	ULONG Nvidia::CommonApiWrapper::GetGpuCoreCount(ULONG physHandlerNum)
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
	String^ Nvidia::CommonApiWrapper::GetName(ULONG physHandlerNum)
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
	String^ Nvidia::CommonApiWrapper::GetVBiosInfo(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetVirtualRamSize(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetPhysicalRamSize(ULONG physHandlerNum)
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
	String^ Nvidia::CommonApiWrapper::GetCardSerialNumber(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetGpuPciInternalDeviceId(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetGpuPciRevId(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetGpuPciSubSystemId(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetGpuPciExternalDeviceId(ULONG physHandlerNum)
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
	UINT Nvidia::CommonApiWrapper::GetGpuBusId(ULONG physHandlerNum)
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

	float Nvidia::CommonApiWrapper::GetGpuCoreTemp(ULONG physHandlerNum)
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
}

