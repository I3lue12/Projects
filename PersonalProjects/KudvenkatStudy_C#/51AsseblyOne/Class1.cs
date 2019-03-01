using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51AsseblyOne
{
    public class AssemblyOneClass	 //internal makes it so that it is only in the a
    {
		public void Print()
		{
			Console.WriteLine("Hello");
		}
    }

	internal class AssemblyOnePublic
	{
		public void Print()
		{
			Console.WriteLine("Hello");
		}
	}
}
