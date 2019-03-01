using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudvenkatStudy
{
	public class Enum_Learning
	{
		int[] Values = (int[])Enum.GetValues(typeof(Gender));
		string[] Names = Enum.GetNames(typeof(Gender));
		
		public Enum_Learning()
		{
			
		}
		public Customer[] CreateCustomer()
		{
			Customer[] customers = new Customer[3];
			customers[0] = new Customer
			{
				Name = "Mark",
				Gender = Gender.Male,
				GenderINT = 1
			};
			customers[1] = new Customer
			{
				Name = "Suzie",
				Gender = Gender.Female,
				GenderINT = 2
			};
			customers[2] = new Customer
			{
				Name = "Sam",
				Gender = Gender.Unknown,
				GenderINT = 0
			};

			return customers;
		}

		public int[] ExecuteIntEnum()
		{
			int[] temp = Values;
			
			int i = 0;
			foreach (int value in Values)
			{
				temp[i] = value;
				i++;
			}

			return temp;
		}
		public string[] ExecuteStringEnum()
		{
			string[] tempname = Names;
			int i = 0;
			foreach (string name in Names)
			{
				tempname[i] = name;
				i++;
			}

			return tempname;
		}
		public string GetGender(int gender)
		{
			switch(gender)
			{
				case 0:
					return "Unknown";
				case 1:
					return "Male";
				case 2:
					return "Female";
				default:
					return "Invalid data";
			}
		}
	}
	public enum Gender //: short //can inherit from short and change type to short not an int.
	{
		Unknown=0, //Unknown=1;
		Male=1,
		Female=2
	}

	public class Customer
	{
		public string Name { get; set; }
		public int GenderINT { get; set; }
		public Gender Gender { get; set; }
	}
}
