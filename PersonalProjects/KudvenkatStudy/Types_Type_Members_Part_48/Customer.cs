using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types_Type_Members_Part_48
{

	/*
	 
		 
		
		CLASSES, STRUCTS, ENUMS, INTERFACES, DELEGATES -> TYPES
						
					types can only have 2 ACCESS MODIFIERS  -public or internal

		FIELDS, PROPERTIES, CONSTRUCTORS, METHODS -> TYPE MEMBERS

					type members can have ALL ACCESS MODIFIERS
		 
		PRIVATE, PROTECTED, INTERNAL, PROTECTED INTERNAL, PUBLIC -> ACCESS MODIFIERS

		 */


	public class Customer
	{
		private int _id;
		private string _firstName;		  //private fields
		private string _lastName;

		public int ID
		{
			get	{ return _id; }
			set { _id = value; }
		}

		public string FirstName
		{
			get	{ return _firstName; }							 //three public properties
			set	{ _firstName = value; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string GetFullName()
		{
			return this._firstName + " " + this._lastName;				//one method
		}
	}
}
