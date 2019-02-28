using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace _54_reflection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string typeName = this.textBox1.Text;
			Type T = Type.GetType(typeName);
			
			
			foreach (Control c in this.Controls)
			{
				if(c is ListBox)
				{
					EraseList((ListBox)c);
				}
			}
			

			if (T != null)
			{
				MethodInfo[] methods = T.GetMethods();

				foreach (MethodInfo method in methods)
				{
					this.listBox1.Items.Add("Return Type: " + method.ReturnType +"  Method:"+ method.Name);
				}
				PropertyInfo[] properties = T.GetProperties();
				foreach (PropertyInfo propertie in properties)
				{
					this.listBox2.Items.Add(propertie.PropertyType.Name);
				}
				ConstructorInfo[] Constructors = T.GetConstructors();
				foreach (ConstructorInfo Constructor in Constructors)
				{
					this.listBox3.Items.Add(Constructor.ToString());
				}
			}
		}
		private void EraseList(ListBox l)
		{
			l.Items.Clear();
		}
	}
}
