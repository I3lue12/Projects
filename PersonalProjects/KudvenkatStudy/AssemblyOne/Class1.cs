using System;


namespace AssemblyOne
{
    public class AssemblyI
    {
		protected internal int _id = 101;
		protected internal int ID = 101;
	}
	public class AssemblyOneClass
	{
		public void SampleMethos()
		{
			AssemblyI A1 = new AssemblyI();
			Console.WriteLine(A1._id);
		}
	}
}
