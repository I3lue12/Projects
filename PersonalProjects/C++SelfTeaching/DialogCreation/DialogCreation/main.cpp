#include <iostream>
#include <string>
#include <vector>
using namespace std;


class Person{
private:
	string name;
public:
	Person();
	Person(string name)
	{
		this->name = name;
	}
	string GetName()
	{
		return this->name;
	}
	
};



int main()
{
	vector<string> persons;
	






	Person Jeff = Person("Jeff");
	Person Fred = Person("Fred");
	
	
	string userName = "";
	//cout << "What is your name? " << endl;
	//cin >> userName;
	//Person User = Person(userName);

	persons.push_back(Jeff.GetName());
	persons.push_back(Fred.GetName());

	for (int i = 0; i < persons.size(); i++)
	{
		cout << persons[i] << endl;
	}
	//cout << User.GetName() << endl;
	
	
	cout << persons[0] << endl;
	int x;

	cin >> x;

	return 0;
}