#pragma once
class CFailingApp
{
	CFailingApp();
	~CFailingApp();
	int testingref(int);
	void* dosomethingevenmoreawesomehere(int*);
};
struct failingAppNode
{
	failingAppNode* next;
	int retCode;
	failingAppNode* prev;
	failingAppNode* head;
};