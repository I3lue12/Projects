
#include <iostream>	
//https://www.youtube.com/watch?v=1OsGXuNA5cc&list=PLlrATfBNZ98dudnM48yfGUldqGD0S4FFb&index=3&t=0s
int AddSomthing(int a, int b);

int main()
{

	int som = 10;
	int som2 = 10;
	std::cout << "hello world" << std::endl;
	std::cin.get();
	return 0;
}

/*
Java - class name has to be tied with your file name and your folder hiearchy needs to be tied with your package, java expects these certain files to exist.

in C++ this is not the case, a file is just there to feed the compiler with source code.
I am responsible with telling the compiler what kind of file type this is and how
the compiler should treat that
an example...
If i tell the compiler to treat the file with the extension .cpp it will treat it like a .cpp file
if I tell the compiler to read it as a .h it will treat it like a header,
it I tell the compiler to read it as a .c it will treat it like a c.

C++ - does not care about files, files dont exist in cpp. kinda like saying files have no meaning for cpp


When Compiled we have obj files located in the debug in file directory of project
those file sizes increase the number of #include you include in your project.

after creating the math cpp file we build it
after that we see a 'Math.obj' file
and its 


*/