#include "Region.h"

Region::Region()
{		 //look at intelisense of tiles
	tiles = new Tile[9]();
}
void Region::Show()
{
	cout << endl;
	/*for (int i = 0; i < 3; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}
	for (int i = 3; i < 6; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}
	for (int i = 6; i < 9; i++)
	{
		cout << "| " << tiles[i].Face << " | ";
	}*/
	
	for (int i = 0; i < 9; i++)	 //this would work
	{
		cout << tiles[i].Face << " |";
		if ((i + 1) % 3 == 0)
		{  //endl after every third tile..
			cout << endl;
		}
	}
	
	cout << endl;
}


