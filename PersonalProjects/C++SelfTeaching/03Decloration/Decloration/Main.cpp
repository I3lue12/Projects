#include <iostream>
//https://www.youtube.com/watch?v=1OsGXuNA5cc&list=PLlrATfBNZ98dudnM48yfGUldqGD0S4FFb&index=3&t=0s

//I need to tell compiler that log exists
//compiler will believe us no matter what

//declorations- statement of this function exists


//definition- this is what this function is, the body of the function

void Log(const char* message);
//you can say:
//void Log(const char*);//
//but we could just write what the variable called is.

//question- how does the compiler know that we have a log function in
//another file if we are just compiling this one file.

//question - how does it actually run the right code that is where a "linker"
//comes into play


int main()
{
	
	Log("Hello World");

	std::cin.get();
	return 0;
}