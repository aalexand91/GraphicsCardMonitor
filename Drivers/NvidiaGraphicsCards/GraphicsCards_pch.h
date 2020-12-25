/*********************************************************************************************************
* File: GraphicsCardPch.h
* 
* Summary: Precompiled header file for NvidiaGraphicsCards.h and CommonApiWrapper.cpp. Contains the
* Nvidia API files as well as any standard library files that rarely or never change. As described by
* Microsoft: pch.h: This is a precompiled header file.
* Files listed below are compiled only once, improving build performance for future builds.
* This also affects IntelliSense performance, including code completion and many code browsing features.
* However, files listed here are ALL re-compiled if any one of them is updated between builds.
* Do not add files here that you will be updating frequently as this negates the performance advantage.
*
* Original Author: Anthony Alexander
* 
* Date:			Author:					Description:
* 11/24/2020	Anthony Alexander		Initial Creation
**********************************************************************************************************/

#ifndef GRAPHICS_CARD_PCH_H
#define GRAPHICS_CARD_PCH_H

// add headers that you want to pre-compile here
#include <Windows.h>	// Windows library
#include <nvapi.h>		// Nvidia's APIs from the NVAPI SDK
#include <stdexcept>	// exception class
#include <minwindef.h>

#endif //GRAPHICS_CARD_PCH_H
