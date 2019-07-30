using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33AbstractVsInterfaces
{

	public abstract class Customer //can inherit from another abstract class or interface
	{
		int ID; // CAN have a field
		public void Talk()
		{
			//this can have body
		}

		public abstract void Speek();//CAN have abstract Speek

		/*
		public abstract void Talk()//CAN NOT have a body if method is abstract 
		{

		}
		  */
	}

	public interface ICustomer //can only inherit from another interface. cannot inherit from an abstract class.
	{
		//Interfaces always implement public functionality.
		void Talk();//Can implement methods

		#region CAN NOT   
		// CAN NOT
		//int ID;//implement fields
		/*
		public void Talk() //have access modifiers such as public, private
		{
		} 
		*/

		/*
		void Talk()	//have a body or implementation.
		{

		} 
		*/
		#endregion 


	}

	public class A
	{

	}
	public class B
	{

	}
	public class D : A// , B //CAN NOT inherite from 2 classes.
	{

	}
	public class C : A, ICustomer, IConvertible	//CAN inherit from class and other interfaces.
	{
		public TypeCode GetTypeCode()
		{
			throw new NotImplementedException();
		}

		public void Talk()
		{
			throw new NotImplementedException();
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public byte ToByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public char ToChar(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public double ToDouble(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public short ToInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public int ToInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public long ToInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public float ToSingle(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public string ToString(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			throw new NotImplementedException();
		}
	}



	class Program : Customer
	{
		static void Main(string[] args)
		{
			TEST t = new TEST();
			t.Talk();
		}
		public override void Speek() //only when the method from customer is abstract.
		{
			throw new NotImplementedException();
		}
	}

	public class TEST : ICustomer
	{
		public TEST()
		{
		}

		public void Talk()
		{
			Console.WriteLine("From Interface");
		}
	}


}
