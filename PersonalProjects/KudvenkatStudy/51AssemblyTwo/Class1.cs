using System;
using _51AsseblyOne;

namespace _51AssemblyTwo
{
    public class AssemblyTwoClass
    {
		public void Test()
		{
			_51AsseblyOne.AssemblyOneClass A1 = new _51AsseblyOne.AssemblyOneClass();
			//or
			AssemblyOneClass A2 = new AssemblyOneClass();
		}
    }
}
