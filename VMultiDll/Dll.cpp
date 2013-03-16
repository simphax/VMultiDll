#include "stdafx.h"
#include <stdio.h> 

extern "C" 
 {
   #include "vmulticlient.h"
 }

extern "C"
{
__declspec(dllexport) void HelloWorld()
 {
	 printf ("Hello World !\n");
 }

}