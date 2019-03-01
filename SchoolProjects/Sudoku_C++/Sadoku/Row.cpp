#include "Row.h"

Row::Row()
{
	tiles = new Tile[9]();//create tile array at start
}
void Row::SetTile(int idx,Tile& tile)	//return type then: scope resolution.										
{ //past in a refrense pointing for tile not make a copy of the tile
	tiles[idx] = tile;//place incomming tile into array
}
bool Row::IsConsistant()
{//searching in tiles[] see if there is a dup
	for (int i = 0; i < 8; i++)
	{
		if (tiles[i].Value != 0)
		{	//only check for non zero values, indicates tile is not set yet.
			for (int j = i + 1; j < 9; j++)
			{
				if (tiles[j].Value != 0)
				{ //
					if (tiles[i].Value == tiles[j].Value)
					{
						return false;//found dup get out of function
					}
				}
			}
		}
	}
	return true; //if made here no dupes
}
void Row::Show()
{
	cout << "\ ";
	for (int i = 0; i < 9; i++)
	{
		cout << tiles[i].Face << " | ";
	}
	cout << endl << endl;
}