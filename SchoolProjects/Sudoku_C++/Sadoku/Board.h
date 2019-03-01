#pragma once
#include<iostream>
#include<string>
#include"Row.h"
#include"Tile.h"
#include"Column.h"
#include"Region.h"
#include <time.h>

using namespace std;

class Board 
{
protected:
	Tile grid[9][9];
	Row rows[9];
	Column cols[9];
	Region rgns[9];
	int WhichRegion(int x, int y);
	int WhichTileWithinRegion(int x, int y);
	void ResetRow(int rowStart, int numRows) ;
public:
	bool IsConsistant();
	void Show();
	void Shuffle();
	Board();
};
