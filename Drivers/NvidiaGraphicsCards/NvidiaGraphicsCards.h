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
				///****************************************************************************
				/// Private Class Members
				///****************************************************************************
				private:
					NvAPI_Status			_apiStatus;			// the API status
					bool					_apiInit;			// the API initialization status
					bool					_handlersInit;		// determines if handlers are initialized
					NvPhysicalGpuHandle*	_physicalHandlers;	// points to location of GPU physical handlers
					NvU32					_numPhysHandlers;	// the number of physical handlers

				///****************************************************************************
				/// Private Class Methods
				///****************************************************************************
				private:

					//*********************************************************************************
					// Function: Nvidia::CommonApiWrapper::GetApiErrMsg
					// Description: Gets the API status error message
					// Parameters: apiStat - The API status
					// Returns: The API error message as a System::String type
					//*********************************************************************************
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

				///****************************************************************************
				/// Public Class Methods
				///****************************************************************************
				public:

					//*********************************************************************************
					// Constructor
					// Description: Constructor for CommonApiWrapper object
					// Parameters: N/A
					// Returns: A CommonApiWrapper object
					//*********************************************************************************
					CommonApiWrapper();

					//*********************************************************************************
					// Destructor
					// Description: Destructor for CommonApiWrapper object
					// Parameters: N/A
					// Returns: N/A
					//*********************************************************************************
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

					String^ GetCardSerialNumber(unsigned long physHandlerNum) override;
			};
	};

}
