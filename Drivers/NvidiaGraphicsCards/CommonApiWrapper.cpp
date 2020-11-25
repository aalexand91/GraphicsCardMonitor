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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetApiErrMsg
	// Description: Gets the API status error message
	// Parameters: apiStat - The API status
	// Returns: The API error message as a System::String type
	//*********************************************************************************
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetPhysicalHandlers
	// Description: Gets all physical GPU handlers in the system
	//				and stores them in memory
	// Parameters: N/A
	// Returns: true, if all physical GPU handlers were found
	//			false, if an error occurred getting the phyical GPU handlers
	//*********************************************************************************
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetDefaultErrMsg
	// Description: Gets the default error message when the user incorrectly
	//				uses the driver
	// Parameters: N/A
	// Returns: An error message as a System::String type
	//*********************************************************************************
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
	void Nvidia::CommonApiWrapper::GetPciIds(unsigned long physHandlerNum, PciIdentifiers^ ptrPciIdentifiers)
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

	///********************************************************************************
	/// Public Class Methods
	///********************************************************************************

	//*********************************************************************************
	// Constructor
	// Description: Constructor for CommonApiWrapper object
	// Parameters: N/A
	// Returns: A CommonApiWrapper object
	//*********************************************************************************
	Nvidia::CommonApiWrapper::CommonApiWrapper()
	{
		// default all class members
		_apiStatus			= NVAPI_API_NOT_INITIALIZED;
		_apiInit			= false;
		_handlersInit		= false;
		_physicalHandlers	= nullptr;
		_numPhysHandlers	= 0;
	}

	//*********************************************************************************
	// Destructor
	// Description: Destructor for CommonApiWrapper object
	// Parameters: N/A
	// Returns: N/A
	//*********************************************************************************
	Nvidia::CommonApiWrapper::~CommonApiWrapper()
	{
	}

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::InitializeApi
	// Description: Initializes the Nvidia graphics card API
	// Paramters: N/A
	// Returns: true, if the Nvidia graphics card API initializes successfully
	//			false, if the Nvidia graphics card API fails to initialize
	//*********************************************************************************
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::InitializeHandlers
	// Description: Initializes all handlers for the GPUs in the system
	// Parameters: N/A
	// Returns: true, if all GPU handlers successfully initialized
	//			false, if the GPU handlers failed to initialize
	//*********************************************************************************
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetNumHandlers
	// Description: Get the total number of GPU handlers in the system
	// Parameters: N/A
	// Returns: The total number of GPU handlers in the system as a long
	//*********************************************************************************
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetGpuCoreCount
	// Description: Gets the total number of GPU cores for the graphics card
	// Paramters: physHandlerNum - the index number of the physical handler in memory
	// Returns: The number of GPU cores for the graphics card as a long
	//*********************************************************************************
	unsigned long Nvidia::CommonApiWrapper::GetGpuCoreCount(unsigned long physHandlerNum)
	{
		try
		{
			// check if the API is initialized and ready
			// also check if the GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the physical handler index is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetName
	// Description: Gets the full name of the selected graphics card
	// Paramters: physHandlerNum - The GPU physical handler index number in memory
	// Returns: The graphics card name as a string
	//*********************************************************************************
	String^ Nvidia::CommonApiWrapper::GetName(unsigned long physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if the GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the physical handler index is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					// let the user know the handler index is invalid
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetVBiosInfo
	// Description: Gets the VBIOS information for the selected GPU
	// Parameters: physHandlerNum - The GPU handler index in memory
	// Returns: The selected GPU VBIOS information as a string
	//*********************************************************************************
	String^ Nvidia::CommonApiWrapper::GetVBiosInfo(unsigned long physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if GPU handlers have been initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if the selected handler index is invalid
				if (physHandlerNum > _numPhysHandlers)
				{
					// let the user know the selected handler index is invalid
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetVirtualRamSize
	// Description: Gets the virtual RAM size (physical RAM size and any allocated RAM
	//				for GPU) used by the GPU in KB
	// Parameters: phyHandlerNum - the physical handler index number in memory
	// Returns: The virtual RAM size used by the GPU in KB as an int
	//*********************************************************************************
	unsigned int Nvidia::CommonApiWrapper::GetVirtualRamSize(unsigned long physHandlerNum)
	{
		try
		{
			// check if API is initialized and ok
			// also check if GPU handlers are initialized
			if (_apiInit && _apiStatus == NVAPI_OK && _handlersInit)
			{
				// check if handler index selected is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					// let the user know the handler index is invalid
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetPhysicalRamSize
	// Description: Gets the physical RAM size of the GPU in KB
	// Parameters:
	//		physHandlerNum - the physical handler index number in memory
	// Returns:
	//		The physical RAM of the GPU in KB as an int
	//*********************************************************************************
	unsigned int Nvidia::CommonApiWrapper::GetPhysicalRamSize(unsigned long physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handlers are initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					// let the user know the handler index is invalid
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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

	//*********************************************************************************
	// Function: Nvidia::CommonApiWrapper::GetCardSerialNumber
	// Description: Gets the serial number of the graphics card
	// Parameters:
	//		physHandlerNum - the physical handler index number in memory
	// Returns:
	//		The graphics card serial number as a String type
	//*********************************************************************************
	String^ Nvidia::CommonApiWrapper::GetCardSerialNumber(unsigned long physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler have been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					// let the user know the handler index is invalid
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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
	unsigned int Nvidia::CommonApiWrapper::GetGpuPciInternalDeviceId(unsigned long physHandlerNum)
	{
		try
		{
			// check if the API is okay and initialized
			// also check if the GPU handler have been initialized
			if (_apiStatus == NVAPI_OK && _apiInit && _handlersInit)
			{
				// check if the handler index is valid
				if (physHandlerNum > _numPhysHandlers)
				{
					throw gcnew Exception("Physical handler number greater than total number of handlers.");
				}
				else
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
			// let the user know an error occured getting the GPU PCI
			// internal device ID
			String^ errMsg = "Could not get GPU PCI internal device ID. " + ex->Message;
			throw gcnew Exception(errMsg);
		}
	}
}

