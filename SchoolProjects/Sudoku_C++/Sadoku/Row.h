#pragma once
#include <iostream>
#include <string>
#include "Tile.h"
using namespace std;

class Row
{
protected:
	Tile* tiles;
public:
	Row();
	void SetTile(int idx, Tile& tile);
	bool IsConsistant();
	virtual void Show();

};