using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace MainConsoleWindow
{
	class _53REflection
	{
	}
	public class MainClass53
	{
		/*
		 	 When you drag and drop a button on a win form or an asp.net application. The peroperties window uses
			 reflection to show all the properties of the Button class. So, reflection is extrensively used by
			 IDE or a UI designer.

			Late binding can be achieved by useing reflection. You can use reflection to dynamically create an instance of 
			a type, about which we dont have any information at compile time. So, reflection enables you to use code that is 
			not available at compile time.

			Consider an example:
			we have two alternate implementations of an interface. You want to allow the user to pick one or the other using 
			a config file. With reflection, you can simply read the name of the class whose implementation you want to use
			from the config file, and instantiate an instance of that class. This is another example for late binding using 
			reflection.
			 
			 */
		public static void PrintMainClass53()
		{
			Customer c1 = new Customer();// early binding. knowledge of class at that time.

			// late binding is not having knowledge of that class, such as a button on a form. it is there
			// but you dont use all of the code of the button. 

			//EXAMPLE
			Type T = Type.GetType("MainConsoleWindow.Customer");
			Console.WriteLine("Full Name {0}", T.FullName);
			Console.WriteLine("Name {0}", T.Name);
			Console.WriteLine("Namespace {0}", T.Namespace);

			PropertyInfo[] properties = T.GetProperties();
			foreach (PropertyInfo p in properties)
			{
				Console.WriteLine(p.Name + " " + p.PropertyType);
			}

			MethodInfo[] methods = T.GetMethods();
			foreach (MethodInfo m in methods)
			{
				Console.WriteLine(m.ReturnType.Name + " " + m.Name);
			}

			Type TT = Type.GetType("System.String");
			if (TT != null)
			{
				MethodInfo[] prop = TT.GetMethods();
				foreach (MethodInfo p in prop)
				{
					Console.WriteLine("Method: {0}, Name: {1}", p.ReturnType.Name, p.Name);
				}
			}
			Console.ReadKey();
		}
		public void Display(List<Customer> customers)
		{
			foreach (Customer c in customers)
			{
				Console.WriteLine("ID: " + c.Id + ", Name: " + c.Name + Environment.NewLine);
			}
		}
	}
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Customer(int ID, string Name)
		{
			this.Id = ID;
			this.Name = Name;
		}
		public Customer()
		{
			this.Id = -1;
			this.Name = string.Empty;
		}
		public void PrintID()
		{
			Console.WriteLine("ID = {0}", this.Id);
		}
		public void PrintName()
		{
			Console.WriteLine("Name = {0}", this.Name);
		}
	}
}
