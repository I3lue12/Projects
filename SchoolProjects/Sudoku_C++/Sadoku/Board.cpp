#include "Board.h"

Board::Board()
{
	//seed the random num generator..
	//srand((unsigned int)time(NULL));
}

void Board::Shuffle()
{
	for (int y = 0; y < 9; y++)
	{
		for (int x = 0; x < 9; x++)
		{
			bool consistant = false;
			int rolls = 0;
			while (consistant == false)
			{
				int r = (rand() % 9) + 1;
				Tile t(r);
				rolls++;
				if (rolls > 30)
				{
					x = 0;//reset at beginning of this row
					if (y > 4)
					{
						int numRows = 2;
						ResetRow(y, numRows);
						y = y - numRows + 1;
					}
					else
					{
						ResetRow(y, 1); //clear all tiles in this row
					}
					
					rolls = 0;
				}

				grid[x][y] = t;//place new tile into grid
				//now is the time to write somthing in rows columb region
				rows[y].SetTile(x, t);//place refrense to tile in row
				cols[x].SetTile(y, t);//place refrense in column
				int rgn = WhichRegion(x, y);
				int tileRgn = WhichTileWithinRegion(x, y);
				rgns[rgn].SetTile(tileRgn, t);
				consistant = true;

				//consistant = rows[0].IsConsistant();
				for (int i=0; i < 9; i++)
				{
					if (!rows[i].IsConsistant())
					{
						consistant = false;
						break;
					}
					if (!cols[i].IsConsistant())
					{
						consistant = false;
						break;
					}
					if (!rgns[i].IsConsistant())
					{
						consistant = false;
						break;
					}
				}
				
				//consistant = IsConsistant();
			}

		}
	}
}

int Board::WhichRegion(int x, int y)
{
	if (x < 3)
	{
		if (y < 3)
		{
			return 0;
		}
		else if (y < 6)
		{
			return 3;
		}
		else
		{
			return 6;
		}
	}
	else if (x < 6)
	{
		if (y < 3)
		{
			return 1;
		}
		else if (y < 6)
		{
			return 4;
		}
		else
		{
			return 7;
		}
	}
	else
	{
		if (y < 3)
		{
			return 2;
		}
		else if (y < 6)
		{
			return 5;
		}
		else
		{
			return 8;
		}
	}
}

int Board::WhichTileWithinRegion(int x, int y)
{
	int rX = x % 3;
	int rY = y % 3;
	if (rX == 0)
	{
		if (rY == 0)
		{//uppserleft
			return 0;
		}
		else if (rY == 1)
		{//middle row, left col
			return 3;
		}
		else
		{//lower row left column
			return 6;
		}
	}
	else if (rX == 1)
	{
		if (rY == 0)
		{
			return 1;
		}
		else if (rY == 1)
		{
			return 4;
		}
		else
		{
			return 7;
		}
	}
	else//(rX==2)
	{
		if (rY == 0)
		{
			return 2;
		}
		else if (rY == 1)
		{
			return 5;
		}
		else
		{
			return 8;
		}
	}
}

bool Board::IsConsistant()
{
	for (int i = 0; i < 9; i++)
	{
		 if (!rgns[i].IsConsistant())
		 {
			 return false;	
		 }
		 if (!rows[i].IsConsistant())
		 {	
			return false;
		 }
		 if (!cols[i].IsConsistant())
		 {
			return false;
		 }
	}
	return true;
}

void Board::Show()
{
	for (int i = 0; i < 9; i++)
	{
		rows[i].Show();
		//col[i].Show();  redundent tiles not needed
		//rgns[i].Show();
    }
}

void Board::ResetRow(int rowStart, int numRows)
{
	for (int y = rowStart - numRows + 1; y <= rowStart; y++)
	{
		for (int x = 0; x < 9; x++)
		{
			Tile t; //create a 0 tile
			grid[x][y] = t;
			rows[y].SetTile(x, t);
			cols[x].SetTile(y, t);
			int rgn = WhichRegion(x, y);
			int tileRgn = WhichTileWithinRegion(x, y);
			rgns[rgn].SetTile(tileRgn, t);
		}
	}
}