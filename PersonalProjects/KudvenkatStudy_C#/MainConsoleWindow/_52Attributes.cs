using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsoleWindow
{
	class _52Attributes
	{
	}
	/*
		 [Obsolete]
		 this is an attribute

		a few pre-defined attributes within the .net framework

		obsolete - Marks types and type members outdated
		WebMethods - To expose a method as an XML Web service method
		Serializable - Indicates that a class can be serialized

		inherits from System.Attribute base class 


		 */
	public class Calculator
	{
		[Obsolete]
		//Attribute that tells add it is obsolete method.
		public static int Add(int fn, int sn)  //lets say the want to add three number we need an overloaded add funtion
		{
			return fn + sn;
		}
		[Obsolete("use the Add(List) Method")]
		public static int Add(int fn, int sn, int tn) //if someone wants to add three, what about 5 numbers.
		{
			return fn + sn + tn;
		}
		//lets say it just keeps going on like this.
		//what we will do is

		public static int Add(List<int> numbers) //this can add any number of numbers.
		{
			int sum = 0;
			foreach (int n in numbers)
			{
				sum = sum + n;
			}
			return sum;  //I want the users to use this method without the others.
		}


	}
}
