using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calc
{
	public partial class MainPage : ContentPage
	{
        protected List<string> formual = new List<string>();
        protected double memory;
        List<double> numList = new List<double>();
        //double numParse;
       // bool moreThenOneNum = false;
        string userSee;
        //int userInputCounter;
        public MainPage()
		{
			InitializeComponent();
		}

        private void btnNum_Clicked(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
             userSee = b.Text;
            
            if(lblDisplay.Text[0] == '0' && lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = "";
            }

           
            lblDisplay.Text += userSee;


            #region Cal on my own
            //userInputCounter++;
            //if (userInputCounter > 1)
            //{
                
            //    lblDisplay.Text = UserNumInput(numList, userSee).ToString();
            //}
            //else
            //{
                
            //    lblDisplay.Text = UserNumInput(numList, userSee).ToString();
            //}
            #endregion

        }
        private void btnMEM_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string surf = b.Text;
            if(surf[1] == 'C')
            {
                memory = 0;//clear out memory
            }
            else if(surf[1] == 'R')
            {
                lblDisplay.Text = memory.ToString();
                formual.Clear();
            }
            else if(surf[1] == '+')
            {//add current subTot to memory
                lblDisplay.Text = lblDisplay.Text + memory.ToString();
            }
            else
            {//subtract current subTot from memory
                double temp = memory - memory;
                lblDisplay.Text = Convert.ToString(temp);
                
            }

        }
        #region Cal on my own
        //private double UserNumInput(List<double> lst, string a)
        //{


        //    double test = 1.0;
        //    numParse = Int64.Parse(a);//convertion            

        //    if (userInputCounter > 1)
        //    {
        //        lst.Add(numParse);
        //        test = 2.0;//see if the string gets bigger for each click.
        //        if (userInputCounter > 2)
        //        {
        //            lst.Add(numParse);
        //        }
        //    }
        //    else
        //    {
        //        lst.Add(numParse);
        //    }
        //    return test;

        //}
        #endregion
        private void btnDot_Clicked(object sender, EventArgs e)
        {
           if(CheckIfLastWasOperator())
            { //since last was operator, just prepend "0." to start building a num biginning with decimal
                lblDisplay.Text += "0.";
            }
            else
            {
                int cnt = lblDisplay.Text.Length;
                char lastChar = lblDisplay.Text[cnt - 1];

                if(lastChar == '.')
                {
                    //nothing no two decimal points in a row.
                }
                else
                {
                    //check too see if decimal exists
                    if(CheckIfDecimalPointExistsIn())
                    {
                        //do nothing  they already have a decimal in there
                    }
                    else
                    {
                        //its ok to append decimal
                        lblDisplay.Text += ".";
                    }
                }
            }

        }
        protected bool CheckIfLastWasOperator()
        {            
            int cnt = lblDisplay.Text.Length;
            if (cnt > 0)
            {
                char lastItem = lblDisplay.Text[cnt - 1];
                if (lastItem == '+' || lastItem == '-' || lastItem == 'X' || lastItem == '/')
                {
                    return true;
                }               
            }
            return false;
        }

        protected bool CheckIfDecimalPointExistsIn()
        {
            if (formual.Count > 0)
            {
                string lastOper = formual[formual.Count - 1];
                int indxLastOp = lblDisplay.Text.LastIndexOf(lastOper);
                int indxDot = lblDisplay.Text.LastIndexOf(".");
                //useing lblDisplay because formual list is not checking the current numbers typed.
                if (indxDot > indxLastOp)
                {     //a decimal IS behind the last operater.
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return lblDisplay.Text.Contains(".");
            }
            
        }

        private void btnOp_Clicked(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)   //need to put number 
            {
                if (CheckIfLastWasOperator())
                {
                    //replace last character with new operator
                    int cnt = lblDisplay.Text.Length - 1;
                    lblDisplay.Text = lblDisplay.Text.Substring(0, cnt);
                    formual.RemoveAt(formual.Count - 1);
                    Button b = (Button)sender;
                    string newOp = b.Text;
                    lblDisplay.Text += newOp;
                    formual.Add(newOp);
                }
                else
                {
                    int indxLastDec = lblDisplay.Text.LastIndexOf(".");
                    string newNum;
                    if (indxLastDec == lblDisplay.Text.Length - 1)
                    {                //finnishing a num with decimal at end. add 0
                        lblDisplay.Text += "0";
                        //determine the new operator and append it and add to formula.                    
                    }   
                    if (formual.Count > 0)
                    {
                        string lastOper = formual[formual.Count - 1];
                        int indxLastOp = lblDisplay.Text.LastIndexOf(lastOper);
                        int idxStartNewNum = indxLastOp + 1;
                        newNum = lblDisplay.Text.Substring(idxStartNewNum);
                    }
                    else
                    {
                        newNum = lblDisplay.Text;
                    }
                    
                    formual.Add(newNum);
                    Button b = (Button)sender;
                    //b.Text += lblDisplay.Text;
                    lblDisplay.Text += b.Text;
                    string newOp;
                    newOp = b.Text;
                    formual.Add(newOp);

                }
            }
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            formual.Clear();
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
            {
                if (CheckIfLastWasOperator())
                {
                    formual.RemoveAt(formual.Count - 1);
                    formual.RemoveAt(formual.Count - 1);                  
                }
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
                if(lblDisplay.Text.Length == 0)
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void btnIsNegative_Clicked(object sender, EventArgs e)
        {
            if(formual.Count == 0)
            {
                double tempNum = Convert.ToDouble(lblDisplay.Text);
                tempNum = tempNum - 1;
                lblDisplay.Text = tempNum.ToString();

                
                   if(lblDisplay.Text[0] == '-')
                   {
                       lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
                   } 
                   else
                    {
                        if (lblDisplay.Text[0] == 1)
                        {//only 1 char typed, so make sure it's nonZero before prepending the -
                            if (lblDisplay.Text[0] != '0')
                            {
                                lblDisplay.Text = "-" + lblDisplay.Text;
                            }
                        }
                    else if (lblDisplay.Text.Length > 1)
                    {//multiple chars typed, so search for a nonZero before deciding...
                        bool nonZeroFound = false;
                        foreach(char c in lblDisplay.Text)
                        {
                            //found a number that is nonZero
                            if(c != '.' && c!='0')
                            {
                                nonZeroFound = true;
                                break;//get out of loop when found we found it no need for further findings.
                            }
                        }
                        if(nonZeroFound)
                        {   //if we make it here and nonzerofound is still false, then no prepend.
                            lblDisplay.Text = "-" + lblDisplay.Text;
                        }
                    }

                }
                
            }
            else
            {
                string lastOp = formual[formual.Count - 1];//get the last operator entered in formula
                int idxLastOper = lblDisplay.Text.LastIndexOf(lastOp);//find loc of this operator in display

                if (idxLastOper + 1 < lblDisplay.Text.Length)
                {
                    if (lblDisplay.Text[idxLastOper - 1] == lblDisplay.Text[idxLastOper])
                    {
                        idxLastOper--;//2 minus signs in a row, adjusted indx slightly.
                    }
                    string lastOperand = lblDisplay.Text.Substring(idxLastOper + 1);//get last num being assembled
                    double lastOperandAsDouble = Convert.ToDouble(lastOperand);//convert to double
                    lastOperandAsDouble = lastOperandAsDouble * -1;//change sign on the num

                    lastOperand = lastOperandAsDouble.ToString();
                    string sub = lblDisplay.Text.Substring(0, idxLastOper + 1);    //get first part of formula
                    lblDisplay.Text = sub + lastOperand;//recompose new display from the 2 parts
                }
            }
        }

        private void btnEqual_Clicked(object sender, EventArgs e)
        {
                if (formual.Count % 2 == 0)
                {//formula has odd count, so proceed to calculate.
                    if (formual.Count > 1)
                    {
                        string lastOp = formual[formual.Count - 1];//get the last operator entered in formula
                        int idxLastOper = lblDisplay.Text.LastIndexOf(lastOp);//find loc of this operator in display

                        if (idxLastOper + 1 < lblDisplay.Text.Length) //make sure user has typed somthing after the last oper
                        {
                            if (lblDisplay.Text[idxLastOper - 1] == lblDisplay.Text[idxLastOper])
                            {
                                idxLastOper--;//2 minus signs in a row, adjusted indx slightly.
                            }
                            string lastOperand = lblDisplay.Text.Substring(idxLastOper + 1);//get last num being assembled
                            formual.Add(lastOperand);
                        }
                        
                    }
                }  
                //formula has an even count find last num theyre building and add it to formula.
                while (formual.Count > 1)//keep going until all operations are complete.
                {
                    double operand1 = Convert.ToDouble(formual[0]);
                    string oper = formual[1];
                    double operand2 = Convert.ToDouble(formual[2]);
                    double subTotal;
                    if (oper == "+")
                    {
                        subTotal = operand1 + operand2;
                    }
                    else if (oper == "-")
                    {
                        subTotal = operand1 - operand2;
                    }
                    else if (oper == "X")
                    {
                        subTotal = operand1 * operand2;
                    }
                    else//when adding an else if(oper=="/") Visual studio wont know what will happen to subtotal. 
                    {
                        subTotal = operand1 / operand2;
                    }
                    formual.RemoveAt(0);//remove these 2 nums and operator from formula.
                    formual.RemoveAt(0);
                    formual.RemoveAt(0);
                    formual.Insert(0, subTotal.ToString());

                }

                lblDisplay.Text = formual[0];

                if (lblDisplay.Text.Contains("")&& formual.Count == 0)
                {
                    lblDisplay.Text = lblDisplay.Text;
                }
                
                formual.Clear();
    
        }
    }
}
