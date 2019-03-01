using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _55Reflections
{
	class Program
	{
		static void Main(string[] args)
		{
			Customer c1 = new Customer();
			string fullname = c1.GetFullName("P", "Tech");

			Console.WriteLine("Full Name: {0}" ,fullname);
			Console.ReadKey();
		}
	}
	public class Customer
	{
		public string GetFullName(string firstname, string LastName)
		{
			return firstname + " " + LastName;
		}
	}
}
