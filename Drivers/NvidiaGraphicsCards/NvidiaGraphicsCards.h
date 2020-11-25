#pragma once
#include "GraphicsCardPch.h"	// pre-compiled header file
#include "IGraphicsCard.h"		// IGraphicsCard interface

using namespace System;

namespace GraphicsCards 
{
	public ref class Nvidia
	{
		protected:
			ref class CommonApiWrapper : public IGraphicsCard
			{
				//****************************************************************************
				// Private Class Structures
				//****************************************************************************
				private:
					
					/// <summary>
					/// Structure for all PCI identifiers for the GPU
					/// </summary>
					ref struct PciIdentifiers
					{
						bool	hasIdInfo;		// determines if all PCI identifiers have been obtained
						NvU32	internalId;		// the internal PCI device ID for the GPU
						NvU32	subsystemId;	// the internal PCI subsystem ID for the GPU
						NvU32	revId;			// the internal PCI revision ID for the GPU
						NvU32	externalId;		// the external PCI device ID for the GPU
					};

				//****************************************************************************
				// Private Class Members
				//****************************************************************************
				private:
					NvAPI_Status			_apiStatus;			// the API status
					bool					_apiInit;			// the API initialization status
					bool					_handlersInit;		// determines if handlers are initialized
					NvPhysicalGpuHandle*	_physicalHandlers;	// points to location of GPU physical handlers
					NvU32					_numPhysHandlers;	// the number of physical handlers
					PciIdentifiers^			_pciIdentities;		// the PCI IDs for the GPU

				//****************************************************************************
				// Private Class Methods
				//****************************************************************************
				private:

					/// <summary>
					/// Gets the API status error message
					/// </summary>
					/// <param name="apiStat">The API status</param>
					/// <returns>The API error message as a System::String type</returns>
					String^ GetApiErrMsg(NvAPI_Status apiStat);

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetPhysicalHandlers
					// Description: Gets all physical GPU handlers in the system
					//				and stores them in memory
					// Parameters: N/A
					// Returns: true, if all physical GPU handlers were found
					//			false, if an error occurred getting the phyical GPU handlers
					//*********************************************************************************
					bool GetPhysicalHandlers();

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetDefaultErrMsg
					// Description: Gets the default error message when the user incorrectly
					//				uses the driver
					// Parameters: N/A
					// Returns: An error message as a string
					//*********************************************************************************
					String^ GetDefaultErrMsg();

					/// <summary>
					/// Gets all GPU PCI Identifiers
					/// </summary>
					/// <param name="physHandlerNum">the physical hander index in memory</param>
					/// <param name="ptrPciIdentifiers">pointer to the PciIdentifiers member</param>
					void GetPciIds(unsigned long physHandlerNum, PciIdentifiers^ pciIdentifiers);

				///****************************************************************************
				/// Public Class Methods
				///****************************************************************************
				public:

					/// <summary>
					/// Constructor for CommonApiWrapper object
					/// </summary>
					CommonApiWrapper();

					/// <summary>
					/// Destructor for CommonApiWrapper object
					/// </summary>
					~CommonApiWrapper();

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::InitializeApi
					// Description: Initializes the Nvidia graphics card API
					// Paramters: N/A
					// Returns: true, if the Nvidia graphics card API initializes successfully
					//			false, if the Nvidia graphics card API fails to initialize
					//*********************************************************************************
					bool InitializeApi() override;
					
					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::InitializeHandlers
					// Description: Initializes all handlers for the GPUs in the system
					// Parameters: N/A
					// Returns: true, if all GPU handlers successfully initialized
					//			false, if the GPU handlers failed to initialize
					//*********************************************************************************
					bool InitializeHandlers() override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetNumHandlers
					// Description: Get the total number of GPU handlers in the system
					// Parameters: N/A
					// Returns: The total number of GPU handlers in the system as a long
					//*********************************************************************************
					unsigned long GetNumHandlers() override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetGpuCoreCount
					// Description: Gets the total number of GPU cores for the graphics card
					// Paramters: physHandlerNum - the index number of the physical handler in memory
					// Returns: The number of GPU cores for the graphics card as a long
					//*********************************************************************************
					unsigned long GetGpuCoreCount(unsigned long physHandlerNum) override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetName
					// Description: Gets the full name of the selected graphics card
					// Paramters: physHandlerNum - The GPU physical handler index number in memory
					// Returns: The graphics card name as a string
					//*********************************************************************************
					String^ GetName(unsigned long physHandlerNum) override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetVBiosInfo
					// Description: Gets the VBIOS information for the selected GPU
					// Parameters: physHandlerNum - The GPU handler index in memory
					// Returns: The selected GPU VBIOS information as a string
					//*********************************************************************************
					String^ GetVBiosInfo(unsigned long physHandlerNum) override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetVirtualRamSize
					// Description: Gets the virtual RAM size (physical RAM size and any allocated RAM
					//				for GPU) used by the GPU in KB
					// Parameters: phyHandlerNum - the physical handler index number in memory
					// Returns: The virtual RAM size used by the GPU in KB as an int
					//*********************************************************************************
					unsigned int GetVirtualRamSize(unsigned long physHandlerNum) override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetPhysicalRamSize
					// Description: Gets the physical RAM size of the GPU in KB
					// Parameters: physHandlerNum - the physical handler index number in memory
					// Returns: The physical RAM of the GPU in KB as an int
					//*********************************************************************************
					unsigned int GetPhysicalRamSize(unsigned long physHandlerNum) override;

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetCardSerialNumber
					// Description: Gets the serial number of the graphics card
					// Parameters:
					//		physHandlerNum - the physical handler index number in memory
					// Returns:
					//		The graphics card serial number as a String type
					//*********************************************************************************
					String^ GetCardSerialNumber(unsigned long physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI internal device ID
					/// </summary>
					/// <param name="physHandlerNum">the physical handler index number in memory</param>
					/// <returns>the GPU PCI internal device ID as an unsigned int</returns>
					unsigned int GetGpuPciInternalDeviceId(unsigned long physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI revision ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI revision ID as an unsigned int</returns>
					unsigned int GetGpuPciRevId(unsigned long physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI subsystem ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI subsystem ID as an unsigned int</returns>
					unsigned int GetGpuPciSubSystemId(unsigned long physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI external ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index number in memory</param>
					/// <returns>The GPU PCI external ID as an unsigned int</returns>
					unsigned int GetGpuPciExternalDeviceId(unsigned long physHandlerNum) override;
			};
	};

}
