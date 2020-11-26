#pragma once
#include "GraphicsCardPch.h"	// pre-compiled header file
#include "IGraphicsCard.h"		// IGraphicsCard interface

using namespace System;

namespace GraphicsCards 
{
	/// <summary>
	/// Nvidia Graphics Card Class
	/// </summary>
	public ref class Nvidia
	{
		protected:
			/// <summary>
			/// Class: CommonApiWrapper
			/// Description: Common class that provides common Nvidia API functions
			/// </summary>
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

					/// <summary>
					/// Gets all physical GPU handlers in the system
					/// </summary>
					/// <returns>true if API successfully gets all GPU handlers; false otherwise</returns>
					bool GetPhysicalHandlers();

					/// <summary>
					/// Gets the default error message when the user incorrectly uses the driver
					/// </summary>
					/// <returns>An error message as a System::String type</returns>
					String^ GetDefaultErrMsg();

					/// <summary>
					/// Gets all GPU PCI Identifiers
					/// </summary>
					/// <param name="physHandlerNum">the physical hander index in memory</param>
					/// <param name="ptrPciIdentifiers">pointer to the PciIdentifiers member</param>
					void GetPciIds(ULONG physHandlerNum, PciIdentifiers^ pciIdentifiers);
					
					/// <summary>
					/// Checks if the handler index is valid. This prevents the user from using an index
					/// number that is greater than the total number of handlers available in the system
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>true, if the handler index is valid</returns>
					bool IsHandlerIndexValid(ULONG physHandlerNum);

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

					/// <summary>
					/// Initializes the Nvidia graphics card API
					/// </summary>
					/// <returns>
					/// true if the Nvidia graphics card API initialized successfully;
					/// false otherwise
					/// </returns>
					bool InitializeApi() override;
					
					/// <summary>
					/// Initializes all handlers for the GPUs in the system
					/// </summary>
					/// <returns>true if all GPU handlers successfully initialized; false otherwise</returns>
					bool InitializeHandlers() override;

					/// <summary>
					/// Gets the total number of GPU handlers in the system
					/// </summary>
					/// <returns>The total number of GPU handlers in the system as an unsigned long</returns>
					ULONG GetNumHandlers() override;

					/// <summary>
					/// Gets the total number of GPU cores for the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The number of GPU cores for the graphics card as an unsigned long</returns>
					ULONG GetGpuCoreCount(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the full name of the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The graphics card name as a System::String type</returns>
					String^ GetName(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the VBIOS information for the GPU
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The GPU VBIOS information as a System::String</returns>
					String^ GetVBiosInfo(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the virtual RAM size (physical RAM size and any allocated RAM for the GPU)
					/// used by the GPU in KB
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The virtual RAM size used by the GPU in KB as an unsigned int</returns>
					UINT GetVirtualRamSize(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the physical RAM size of the GPU in KB
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The physical RAM of the GPU in KB as an unsigned int</returns>
					UINT GetPhysicalRamSize(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the serial number of the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The graphics card serial number as a System::String</returns>
					String^ GetCardSerialNumber(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI internal device ID
					/// </summary>
					/// <param name="physHandlerNum">the physical handler index number in memory</param>
					/// <returns>the GPU PCI internal device ID as an unsigned int</returns>
					UINT GetGpuPciInternalDeviceId(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI revision ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI revision ID as an unsigned int</returns>
					UINT GetGpuPciRevId(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI subsystem ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI subsystem ID as an unsigned int</returns>
					UINT GetGpuPciSubSystemId(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the GPU PCI external ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index number in memory</param>
					/// <returns>The GPU PCI external ID as an unsigned int</returns>
					UINT GetGpuPciExternalDeviceId(ULONG physHandlerNum) override;

					/// <summary>
					/// Gets the GPU Bus ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index number in memory</param>
					/// <returns>The GPU Bus ID as an unsigned int</returns>
					UINT GetGpuBusId(ULONG physHandlerNum) override;

					float GetGpuCoreTemp(ULONG physHandlerNum) override;
			};
	};

}
