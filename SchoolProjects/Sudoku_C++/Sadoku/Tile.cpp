#include "Tile.h"

Tile::Tile(int val)
{
	this->Value = val;
	this->Face = "";
	char* pBuf = new char[10]();
	_itoa_s(val, pBuf, 10, 10);
	Face = *pBuf;
}
Tile::Tile()
{
	Value = 0;
	Face = "0";
}