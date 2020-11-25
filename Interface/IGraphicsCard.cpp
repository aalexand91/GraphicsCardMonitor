/*************************************************************************************************************
* File: IGraphicsCard.cpp
*
* Original Author: Anthony Alexander
*
* Summary: Interface source file for applications and programs to interface with graphics card drivers
* that inherit this class. This file is only used to build a .dll file for other applications built under 
* .NET to use. Any updates to the interface should be done to IGraphicsCard.h and not this file.
* This interface abstracts the type of graphics card being used by the application
* or program so that various types of drivers (that inherit this interface as the base class) can be used
* by the application or program without the need of changing the application or program source files.
*
* Date:			Author:					Description:
* 7/16/2020		Anthony Alexander		Initial creation
**************************************************************************************************************/

#include "IGraphicsCard_pch.h"	// pre-compiled header file
#include "IGraphicsCard.h"		// header file contanining interface definitions


