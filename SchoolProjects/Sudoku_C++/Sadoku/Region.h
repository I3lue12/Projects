#pragma once
#include <iostream>
#include <string>
#include "Tile.h"
#include "Row.h"


using namespace std;

class Region : public Row
{
	//dont need tile array because of inheritance
protected:
	
public:
	Region();//contructor
	void Show() override;
};
