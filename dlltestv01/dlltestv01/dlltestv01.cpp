/*********************************************************************************
File name: DLLCode.cpp

The header file, DLLCode.h, prototypes all of the DLL interface objects
**********************************************************************************/
#include "Stdafx.h"
#include "dlltestv01.h"
#include "LogitechSteeringWheelLib.h"
#include "staticlibsample.h"
#include <iostream>
#define FAIL_SKY 0XFA
#define SUCCESS_SKY 0XCC
using namespace std;

int DLLfunwrit(int a)
{
	DLLArg = a;
	return DLLArg;
	//cout << a << endl;
};
int DLLfunread(int a)
{
	return DLLArg;
	//cout << a << endl;
};
int DLLfun2(int a) { return a << 1; };

int DLLArg = 100;
char arry[256] = {};
#define BUF_SIZE 256
TCHAR szName[] = TEXT("Global\\MyFileMappingObject");
TCHAR szMsg[] = TEXT("Message from first process.");
HANDLE hMapFile;
LPCTSTR pBuf;
int writememory(void*p) {
	CopyMemory((PVOID)arry, p, 10);
	return 0;
}
int readmemeory(void*p) {
	CopyMemory((PVOID)p, arry, 10);
	return 0;
}
int opensharedmemory() {
	hMapFile = OpenFileMapping(
		FILE_MAP_ALL_ACCESS,   // read/write access
		FALSE,                 // do not inherit the name
		szName);               // name of mapping object

	if (hMapFile == NULL)
	{
		hMapFile = CreateFileMapping(
			INVALID_HANDLE_VALUE,    // use paging file
			NULL,                    // default security
			PAGE_READWRITE,          // read/write access
			0,                       // maximum object size (high-order DWORD)
			BUF_SIZE,                // maximum object size (low-order DWORD)
			szName);                 // name of mapping object
		if (hMapFile == NULL)
		{

			return FAIL_SKY;
		}
	}
	pBuf = (LPTSTR)MapViewOfFile(hMapFile,   // handle to map object
		FILE_MAP_ALL_ACCESS, // read/write permission
		0,
		0,
		BUF_SIZE);
	if (pBuf == NULL)
	{
		CloseHandle(hMapFile);
		return FAIL_SKY;
	}
	return SUCCESS_SKY;
}
int writesharedmemory(void* p) {
	if (pBuf == NULL)
	{
		//CloseHandle(hMapFile);
		return FAIL_SKY;
	}
	CopyMemory((PVOID)pBuf,p, 36);	
	return SUCCESS_SKY;
}
int readsharedmemory(void* p) {
	if (pBuf == NULL)
	{
		//CloseHandle(hMapFile);
		return FAIL_SKY;
	}
	CopyMemory(p, (PVOID)pBuf, 36);
	return SUCCESS_SKY;
}
int closesharedmemory() {
	UnmapViewOfFile(pBuf);
	CloseHandle(hMapFile);
	return SUCCESS_SKY;
}
bool LogiSteeringInitialize_kat(bool b) {
	return LogiSteeringInitialize(b);
}
bool LogiIsConnected_kat(const int index) {
	return LogiIsConnected(index);
}
bool LogiUpdate_kat() {
	return LogiUpdate();
}
int getsteeringdata_copyvalue_kat(const int index, void *p) {
	void * temp;
	DIJOYSTATE2 didata;
	didata.lY = 123;
	temp = &didata;
	if (LogiIsConnected(index)) {
		if (!LogiUpdate())return 0;
		temp = LogiGetState(index);
		CopyMemory(p, temp, sizeof(DIJOYSTATE2));
		return 1;
	}
	//CopyMemory(p, temp,10);
	return 0;
}

 int addlib_add(int a, int b) {
	 return  Test(a,b);
 }





 Dllclass::Dllclass() { Arg = 0; };

Dllclass::~Dllclass() {};

int Dllclass::Add(int a, int b)
{
	Arg += a + b;
	return Arg;
};

int Dllclass::Sub(int a, int b)
{

	return a - b;
};

int importdllclass()
{
	Dllclass* cp;
	cp = new Dllclass();
	return (int)cp;
};
int dllclassadd(void *p, int a, int b)
{
	return ((Dllclass*)p)->Add(a, b);
};
int releasedllclass(void *p)
{
	delete (Dllclass*)p;
	return 0;
}

