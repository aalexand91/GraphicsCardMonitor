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
			ref class CommonApiWrapper : IGraphicsCard
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

					/// <summary>
					/// Gets the thermal device name based on the NV_THERMAL_TARGET type
					/// </summary>
					/// <param name="deviceType">The NV_THERMAL_TARGET device type</param>
					/// <returns>Name of the thermal device as a System::String</returns>
					String^ GetTempDeviceName(NV_THERMAL_TARGET deviceType);

					/// <summary>
					/// Gets the temperature for a specific thermal sensor device
					/// </summary>
					/// <param name="physHandler">The GPU physical handler</param>
					/// <param name="deviceType">The NV_THERMAL_TARGET device type</param>
					/// <param name="ptrDeviceTemp">Pointer to the data to store the device temperature</param>
					/// <returns>true if the selected device temperature is obtained</returns>
					bool GetDeviceTemperature(NvPhysicalGpuHandle physHandler, NV_THERMAL_TARGET deviceType, float* ptrDeviceTemp);

					/// <summary>
					/// Gets the System::String equivalent of the NV_GPU_PUBLIC_ClOCK_ID variable
					/// </summary>
					/// <param name="clockId">The NV_GPU_PUBLIC_CLOCK_ID enum variable</param>
					/// <returns>The GPU public clock ID as a System::String</returns>
					String^ GetClockIdType(NV_GPU_PUBLIC_CLOCK_ID clockId);

					/// <summary>
					/// Gets the System::String equivalent of the GPU clock frequency type
					/// </summary>
					/// <param name="clockType">The clock frequency type as a NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE enum</param>
					/// <returns>The GPU clock frequency type as a System::String</returns>
					String^ GetClockType(NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType);

					/// <summary>
					/// Gets the clock frequency for a specified clock and clock type on the GPU in kHz
					/// </summary>
					/// <param name="physHandler">The physical GPU handler in memory</param>
					/// <param name="clockId">The ID of the clock to obtain the data for</param>
					/// <param name="clockType">The type of clock frequency to get (i.e. base, current, boost)</param>
					/// <param name="ptrClockSpeed">pointer pointing the data storing the clock frequency</param>
					/// <returns>true if the API successfully gets the clock frequency; false otherwise</returns>
					bool GetClockFrequency(NvPhysicalGpuHandle physHandler, NV_GPU_PUBLIC_CLOCK_ID clockId, NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE clockType, float* ptrClockSpeed);

					/// <summary>
					/// Gets the GPU performance state ID code ranging from P0-P20
					/// </summary>
					/// <param name="physHandler">The physical handler index in memory</param>
					/// <returns>The GPU performance state ID as a NV_GPU_PERF_PSTATE_ID enum</returns>
					NV_GPU_PERF_PSTATE_ID GetPerformanceStateId(NvPhysicalGpuHandle physHandler);

					/// <summary>
					/// Gets the GPU performances state as a System::String
					/// </summary>
					/// <param name="perfState">GPU performances state ID (P0-P20)</param>
					/// <returns>The GPU performance state as a System::String</returns>
					String^ GetPerformanceState(NV_GPU_PERF_PSTATE_ID perfState);

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
					virtual bool InitializeApi();
					
					/// <summary>
					/// Initializes all handlers for the GPUs in the system
					/// </summary>
					/// <returns>true if all GPU handlers successfully initialized; false otherwise</returns>
					virtual bool InitializeHandlers();

					/// <summary>
					/// Gets the total number of GPU handlers in the system
					/// </summary>
					/// <returns>The total number of GPU handlers in the system as an unsigned long</returns>
					virtual ULONG GetNumHandlers();

					/// <summary>
					/// Gets the total number of GPU cores for the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The number of GPU cores for the graphics card as an unsigned long</returns>
					virtual ULONG GetGpuCoreCount(ULONG physHandlerNum);

					/// <summary>
					/// Gets the full name of the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The graphics card name as a System::String type</returns>
					virtual String^ GetName(ULONG physHandlerNum);

					/// <summary>
					/// Gets the VBIOS information for the GPU
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The GPU VBIOS information as a System::String</returns>
					virtual String^ GetVBiosInfo(ULONG physHandlerNum);

					/// <summary>
					/// Gets the virtual RAM size (physical RAM size and any allocated RAM for the GPU)
					/// used by the GPU in KB
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The virtual RAM size used by the GPU in KB as an unsigned int</returns>
					virtual UINT GetVirtualRamSize(ULONG physHandlerNum);

					/// <summary>
					/// Gets the physical RAM size of the GPU in KB
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The physical RAM of the GPU in KB as an unsigned int</returns>
					virtual UINT GetPhysicalRamSize(ULONG physHandlerNum);

					/// <summary>
					/// Gets the serial number of the graphics card
					/// </summary>
					/// <param name="physHandlerNum">The index number of the physical handler in memory</param>
					/// <returns>The graphics card serial number as a System::String</returns>
					virtual String^ GetCardSerialNumber(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU PCI internal device ID
					/// </summary>
					/// <param name="physHandlerNum">the physical handler index number in memory</param>
					/// <returns>the GPU PCI internal device ID as an unsigned int</returns>
					virtual UINT GetGpuPciInternalDeviceId(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU PCI revision ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI revision ID as an unsigned int</returns>
					virtual UINT GetGpuPciRevId(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU PCI subsystem ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU PCI subsystem ID as an unsigned int</returns>
					virtual UINT GetGpuPciSubSystemId(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU PCI external ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index number in memory</param>
					/// <returns>The GPU PCI external ID as an unsigned int</returns>
					virtual UINT GetGpuPciExternalDeviceId(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU Bus ID
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index number in memory</param>
					/// <returns>The GPU Bus ID as an unsigned int</returns>
					virtual UINT GetGpuBusId(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU core temperature in celsius
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU core temperature in celsius as a float</returns>
					virtual float GetGpuCoreTemp(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU memory temperature in celsius
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>GPU memory temperature in celsius as a float</returns>
					virtual float GetMemoryTemp(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU power supply temperature in celsius
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU power supply temperature in celsius as a float</returns>
					virtual float GetPowerSupplyTemp(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU board temperature in celsius
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU board temperature in celsius as a float</returns>
					virtual float GetBoardTemp(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU fanspeed in RPM
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU fanspeed in RPM as an unsigned int</returns>
					virtual UINT GetGpuFanSpeed(ULONG physHandlerNum);

					/// <summary>
					/// Gets the base clock speed of the GPU processor in kHz
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU processor base clock speed in kHz as a float</returns>
					virtual float GetProcessorBaseClockFreq(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU processor current clock frequency in kHz
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU processor current clock frequency in kHz as a float</returns>
					virtual float GetProcessorCurrentClockFreq(ULONG physHandlerNum);

					/// <summary>
					/// Gets the GPU processor boost clock frequency in kHz
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The GPU processor boost clock frequency in kHz as a float</returns>
					virtual float GetProcessorBoostClockFreq(ULONG physHandlerNum);

					/// <summary>
					/// Gets the current performance state setting of the GPU
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <returns>The current GPU performance state as a System::String</returns>
					virtual String^ GetCurrentPerformanceState(ULONG physHandlerNum);

					/// <summary>
					/// Gets the base voltage value in uV for the selected base voltage of the GPU based on the current
					/// performance state of the GPU.
					/// </summary>
					/// <param name="physHandlerNum">The physical handler index in memory</param>
					/// <param name="baseVoltageNum">The base voltage number for the GPU</param>
					/// <returns>The base voltage in uV as a float</returns>
					virtual float GetBaseVoltage(ULONG physHandlerNum, UINT baseVoltageNum);
			};
	};

}
