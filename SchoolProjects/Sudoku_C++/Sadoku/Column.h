#pragma once
#include <string>
#include <iostream>
#include "Row.h"
using namespace std;

class Column : public Row
{
//dont need tile array because of inheritance
public:
	Column();//contructor
	void Show() override;
};
