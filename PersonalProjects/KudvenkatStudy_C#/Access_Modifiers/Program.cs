using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Modifiers
{
	class Program
	{
		// PRIVATE, PROTECTED, INTERNAL, PROTECTED INTERNAL, PUBLIC
		static void Main(string[] args)
		{
			//Private and protected
			Customer c1 = new Customer();
			c1.ID = 15;   
			Console.WriteLine(c1.ID);

			CoorporateCustomer cc = new CoorporateCustomer();
			cc.PrintID();
			//End private and protected





		}
	}
	
	public	class Customer
	{
		private int OnlyCustomerID=0;
		protected int _id; //only available in containing type

		public int ID //available anywhere Customer is created
		{
			get
			{
				return OnlyCustomerID;

			}
			set
			{
				OnlyCustomerID = value;
			}
		}
	}

	public class CoorporateCustomer	: Customer
	{
		public void PrintID()
		{
			CoorporateCustomer CC = new CoorporateCustomer();


			CC._id = 101;
			base._id = 101;
			this._id = 101;


			Console.WriteLine(CC._id);
		}
	}


}
