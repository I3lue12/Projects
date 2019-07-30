#include <iostream>
//https://www.youtube.com/watch?v=1OsGXuNA5cc&list=PLlrATfBNZ98dudnM48yfGUldqGD0S4FFb&index=3&t=0s

void Log(const char* message) //a type that can hold a string of text
{
	std::cout << message << std::endl;
}

int main()
{
	std::cout << "hello world" << std::endl;
	//lets not use the cout function lets use somthing else.
	Log("Hello World");

	std::cin.get();
	return 0;
}