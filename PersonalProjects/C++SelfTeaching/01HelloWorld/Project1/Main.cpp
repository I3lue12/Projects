//include-find file take contents and paste it in current file
//<iostream>- need decloration for cout cin ect.
#include <iostream>	//pre processor statement
//https://www.youtube.com/watch?v=1OsGXuNA5cc&list=PLlrATfBNZ98dudnM48yfGUldqGD0S4FFb&index=3&t=0s

//main is the entry point of application.
int main()
{
	std::cout << "hello world" << std::endl;
	// << is an overloaded function like cout.print()
	//an example is like... 
	std::cout.write("hello",5);



	std::cin.get();
	return 0;
}