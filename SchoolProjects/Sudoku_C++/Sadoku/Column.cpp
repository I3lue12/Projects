#include "Column.h"

Column::Column()
{		 //look at intelisense of tiles
	tiles = new Tile[9]();
}
void Column::Show() 
{
	cout << endl;
	for (int i = 0; i < 9; i++) 
	{
		cout << "| " << tiles[i].Value << "|" << endl;
	}
	cout << endl;
}
