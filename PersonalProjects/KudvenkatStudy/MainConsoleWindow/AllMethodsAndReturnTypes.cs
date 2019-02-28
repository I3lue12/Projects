using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MainConsoleWindow
{
	class AllMethodsAndReturnTypes
	{
		protected static List<string> Namespaces = new List<string>();
		protected static string OneMethodInfoString;
		
		public static string OneNameMethods
		{
			get; set;
		}

		protected static void AddNameSpaces()
		{
			Namespaces.Add("System");
			Namespaces.Add("System.AccessViolationException");

			Namespaces.Add("System.Reflection.MethodInfo");
			Namespaces.Add("System.String");
			Namespaces.Add("System.Boolean");
			
		}
		
		public static void ShowAllMethodsAndReturnTypes()
		{
			bool WantOne = true;
			OneMethodInfoString = OneNameMethods;

			if (WantOne)
			{
				Namespaces.Add(OneMethodInfoString);
			}
			else
			{
				AddNameSpaces();
			}
			
			foreach (string namespce in Namespaces)
			{
				Type T = Type.GetType(namespce);
				Console.WriteLine("==================" + namespce + "===================");
				Console.WriteLine();
				if (T != null)
				{
					MethodInfo[] methods = T.GetMethods();
					foreach (MethodInfo m in methods)
					{
						Console.WriteLine("Name of Method: " + m.Name );
						Console.WriteLine("\t" + " Method Return Type: " + m.ReturnType.Name);
						Console.WriteLine();
					}
				}
			}
			Console.ReadKey();
		}
	}
}
