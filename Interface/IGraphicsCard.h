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
	/// <summary>
	/// Interface to abstract the type of graphics card being used by the application or program
	/// </summary>
	public interface class IGraphicsCard
	{
		/// <summary>
		/// Public Interface Methods
		/// </summary>
		public:

			/// <summary>
			/// Initializes the graphics card API. This must be called before any other method can perform.
			/// </summary>
			/// <returns>true if the API initializes successfully; false otherwise</returns>
			virtual bool InitializeApi() = 0;

			/// <summary>
			/// Initializes all graphics card handlers
			/// </summary>
			/// <returns>true if the graphics card handlers successfully initialize; false otherwise</returns>
			virtual bool InitializeHandlers() = 0;

			/// <summary>
			/// Gets the total number of GPU handlers
			/// </summary>
			/// <returns>The total number of GPU handlers</returns>
			virtual unsigned long GetNumHandlers() = 0;

			/// <summary>
			/// Gets the number of GPU cores for the graphics card
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The number of GPU cores as an unsigned long</returns>
			virtual unsigned long GetGpuCoreCount(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the name of the graphics card
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The name of the graphics card as a System::String</returns>
			virtual String^ GetName(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the VBIOS info for the selected graphics card
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The VBIOS info of the graphics card as a System::String</returns>
			virtual String^ GetVBiosInfo(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the virtual RAM size (physical RAM and allocated RAM for GPU)
			/// of the GPU in KB
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The virtual RAM size in KB of the GPU as a unsigned int</returns>
			virtual unsigned int GetVirtualRamSize(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the physical RAM size of the GPU in KB
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The physical RAM size in KB of the GPU as an unsigned int</returns>
			virtual unsigned int GetPhysicalRamSize(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the graphics card serial number
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The graphics card serial number as a System::String</returns>
			virtual String^ GetCardSerialNumber(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the internal PCI ID of the GPU
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The internal PCI ID of the GPU as an unsigned int</returns>
			virtual unsigned int GetGpuPciInternalDeviceId(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the PCI revision ID of the GPU
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The PCI revision ID of the GPU as an unsigned int</returns>
			virtual unsigned int GetGpuPciRevId(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU PCI subsystem ID
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU PCI subsystem ID as an unsigned int</returns>
			virtual unsigned int GetGpuPciSubSystemId(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU PCI external ID
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU PCI external ID as an unsigned int</returns>
			virtual unsigned int GetGpuPciExternalDeviceId(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU Bus ID
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU Bus ID as an unsigned int </returns>
			virtual unsigned int GetGpuBusId(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU Core temperature in celsius
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU core temperature in celsius as a float</returns>
			virtual float GetGpuCoreTemp(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU memory temperature in celsius
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU memory temperature in celsius as a float</returns>
			virtual float GetMemoryTemp(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU power supply temperature in celsius
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU memory temperature in celsius as a float</returns>
			virtual float GetPowerSupplyTemp(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU board temperature in celsius
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU board temperature in celsius as a float</returns>
			virtual float GetBoardTemp(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the GPU fanspeed in RPM
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU fan speed in RPM as an unsigned int</returns>
			virtual unsigned int GetGpuFanSpeed(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the base clock speed of the GPU processor in kHz
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU processor base clock speed in kHz as a float</returns>
			virtual float GetProcessorBaseClockFreq(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the current clock speed of the GPU processor in kHz
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU processor current clock speend in kHz as a float</returns>
			virtual float GetProcessorCurrentClockFreq(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the boost clock speed of the GPU processor in kHz
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU processor boost clock speed in kHz as a float</returns>
			virtual float GetProcessorBoostClockFreq(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the current GPU performance state
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <returns>The GPU performance state as a System::String</returns>
			virtual String^ GetCurrentPerformanceState(unsigned long physHandlerNum) = 0;

			/// <summary>
			/// Gets the base voltage of the selected base voltage value in uV
			/// based on the current GPU performance state
			/// </summary>
			/// <param name="physHandlerNum">The index of the GPU handler in memory</param>
			/// <param name="baseVoltageNum">The selected base voltage value to read</param>
			/// <returns>The selected GPU based voltage in uV as a float</returns>
			virtual float GetBaseVoltage(unsigned long physHandlerNum, unsigned int baseVoltageNum) = 0;
	};
}
