using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KudvenkatStudy
{
	public partial class Form1 : Form
	{
		int[] values;
		string[] strings;
		RichTextBox rt = new RichTextBox();
		Customer[] customers;

		Type name = Enum.GetUnderlyingType(typeof(Gender));


		public Form1()
		{
			InitializeComponent();
			Enum_Learning el = new Enum_Learning();
			values = el.ExecuteIntEnum();
			strings = el.ExecuteStringEnum();
			customers = el.CreateCustomer();

		}
		private void Form1_Load(object sender,System.EventArgs e)
		{
			
			rt.Left = 50;
			rt.Top = 50;
			rt.Width = 300;
			rt.Height = 300;
			this.Controls.Add(rt);
			rt.Show();

			foreach(string s in strings)
			{
				rt.AppendText(s + Environment.NewLine);
			}
			rt.AppendText(Environment.NewLine);
			foreach (int v in values)
			{
				rt.AppendText(Environment.NewLine + v.ToString()+" ");
			}
			rt.AppendText(Environment.NewLine);
			foreach (Customer c in customers)
			{
				Enum_Learning el = new Enum_Learning();
				rt.AppendText(Environment.NewLine + "Name: " + c.Name + " Gener:" + c.Gender);
			}
			rt.AppendText(Environment.NewLine + name.Name.ToString());
		}
	}
}
