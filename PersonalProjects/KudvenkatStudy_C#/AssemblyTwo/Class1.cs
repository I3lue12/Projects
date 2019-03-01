using System;
using AssemblyOne;

namespace AssemblyTwo
{
	public class AssemblyTwo : AssemblyI
	{
		AssemblyOneClass A1 = new AssemblyOneClass();
		public void Print()
		{
			A1.SampleMethos();
			base.ID = 10; //from inheritense

			AssemblyTwo A2 = new AssemblyTwo();
			A2.ID = 101; // because of inheritense.

		}

	}
}
