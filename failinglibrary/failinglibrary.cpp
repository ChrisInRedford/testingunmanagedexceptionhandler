// failinglibrary.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "failinglibrary.h"
#include <wtypes.h>
#include <unknwn.h>
#include <memory>

// Constructor
CFailingApp::CFailingApp()
{
	return;
}

CFailingApp::~CFailingApp()
{

}

// Creates an invalid reference.
extern "C" __declspec(dllexport) int CreateReference()
{
	IUnknown* pUnk = NULL;
	pUnk->AddRef();
	return 0;
}
extern "C" __declspec(dllexport) int PleaseDoNotFailOnMe()
{
	int* myAddress = new int();
	myAddress = myAddress;
	return *myAddress;
}

int CFailingApp::testingref(int inwardInt)
{
	//Do something awesome here.
	return 0;

}
void* CFailingApp::dosomethingevenmoreawesomehere(int* somethingIn)
{
	failingAppNode* myNode = new failingAppNode();
	myNode->head = myNode;
	return myNode;
}


