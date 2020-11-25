/*************************************************************************************************************
* File: IGraphicsCard.h
* 
* Original Author: Anthony Alexander
* 
* Summary: Interface header file for applications and programs to interface with graphics card drivers
* that inherit this class. This interface abstracts the type of graphics card being used by the application
* or program so that various types of drivers (that inherit this interface as the base class) can be used
* by the application or program without the need of changing the application or program source files.
* 
* Date:			Author:					Description:
* 7/16/2020		Anthony Alexander		Initial creation
**************************************************************************************************************/

#pragma once
#include "IGraphicsCard_pch.h"
using namespace System;

namespace GraphicsCards 
{
	public interface class IGraphicsCard
	{
		///*************************************************************************
		///Public Interface Methods
		///*************************************************************************
		public:

			//*************************************************************************
			// Function: IGraphicsCard::InitializeApi
			// Description: Initializes the graphics card API
			// Parameters: N/A
			// Returns: true, if the API initializes successfully
			//			false, if the API does not successfully initialize
			//*************************************************************************
			virtual bool InitializeApi() = 0;

			//*************************************************************************
			// Function: IGraphicsCard::InitializeHandlers
			// Description: Initializes all graphics card handlers
			// Parameters: N/A
			// Returns: true, if the graphics card handlers successfully initialize
			//			false, if the graphics cards handlers fail to initialize
			//*************************************************************************
			virtual bool InitializeHandlers() = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetNumHandlers
			// Description: Gets the total number of GPU handlers
			// Parameters: N/A
			// Returns: The total number of GPU handlers
			//*************************************************************************
			virtual unsigned long GetNumHandlers() = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetGpuCoreCount
			// Description: Gets the number of GPU cores for the selected graphics card
			// Parameters: physHandlerNum - The index of the GPU handler in memory
			// Returns: The number of GPU cores as an unsigned long
			//*************************************************************************
			virtual unsigned long GetGpuCoreCount(unsigned long physHandlerNum) = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetName
			// Description: Gets the name of the selected graphics card
			// Parameters: physHandlerNum - The index of the GPU handler in memory
			// Returns: The name of the graphics card as a System::String
			//*************************************************************************
			virtual String^ GetName(unsigned long physHandlerNum) = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetVBiosInfo
			// Description: Gets the VBIOS info for the selected graphics card
			// Parameters: physHandlerNum - The index of the GPU handler in memory
			// Returns: The VBIOS info of the graphics card as a System::String
			//*************************************************************************
			virtual String^ GetVBiosInfo(unsigned long physHandlerNum) = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetVirtualRamSize
			// Description: Gets the virtual RAM size (physical RAM and allocated RAM
			//				for GPU) of the GPU in KB
			// Parameters: physHandlerNum - The index of the GPU handler in memory
			// Returns: The virtual RAM size in KB of the GPU as a unsigned int
			//*************************************************************************
			virtual unsigned int GetVirtualRamSize(unsigned long physHandlerNum) = 0;

			//*************************************************************************
			// Function: IGraphicsCard::GetPhysicalRamSize
			// Description: Gets the physical RAM size of the GPU in KB
			// Parameters: physHandlerNum - The index of the GPU handler in memory
			// Returns: The physical RAM size in KB of the GPU as an unsigned int
			//*************************************************************************
			virtual unsigned int GetPhysicalRamSize(unsigned long physHandlerNum) = 0;

			virtual String^ GetCardSerialNumber(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetGpuPciInternalDeviceId(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetGpuPciRevId(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetGpuPciSubSystemId(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetGpuPciExternalDeviceId(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetGpuBusId(unsigned long physHandlerNum) = 0;

			virtual float GetGpuCoreTemp(unsigned long physHandlerNum) = 0;

			virtual float GetMemoryTemp(unsigned long physHandlerNum) = 0;

			virtual float GetPowerSupplyTemp(unsigned long physHandlerNum) = 0;

			virtual float GetBoardTemp(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetMax3dPerformanceState(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetBalanced3dPerformanceState(unsigned long physHandlerNum) = 0;

			virtual unsigned int GetHighDefVideoPlaybackState(unsigned long physHandlerNum) = 0;

			virtual float GetBaseVoltage(unsigned long physHandlerNum) = 0;
	};
}
