
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Calculator
{
	[Activity (Label = "GUI")]			
	public class GUI : Activity
	{
		private IHistoryList il;
		private IList<string> iList = new List<string>();
		private IBinaryOperator po;
		string pendingOperator = "";
		Double pendingValue;
		bool digitEntered = false;
		bool operatorClicked = false;
		string pendingResult = "";
		bool Eqpressed = false;
		int opCount = 0;
		string result = "";
		string digit;
		IUnaryOperator puO;
		double UnaryResult;
		CalculatorLogic calculator = new CalculatorLogic();

		private void numberButtonClick(object sender, EventArgs e)
		{
			digitEntered = true;
			TextView textView = FindViewById<TextView> (Resource.Id.textView);

			if ((textView.Text == "0") || (operatorClicked) || (Eqpressed))
				textView.Text = null;

			operatorClicked = false;
			Eqpressed = false;

			if (sender.ToString() == ".")
			{
				if (!textView.Text.Contains ("."))
					textView.Text += sender.ToString ();
				else
					return;
			}
			else
			{ 
				digit = sender.ToString ();
				textView.Text += digit;	
			}
		}


		private void binaryOperatorClick(object sender, EventArgs e)
		{
			TextView textView = FindViewById<TextView> (Resource.Id.textView);

			if (!operatorClicked) { iList.Add(textView.Text); }
			else { iList.Add(Convert.ToString(0)); }
			pendingOperator = sender.ToString ();
			opCount++;
			iList.Add(pendingOperator);
			pendingValue = Convert.ToDouble(textView.Text);
			switch (pendingOperator)
			{
			case "+":
				po = new AdditionOperator();
				break;

			case "-":
				po = new SubtractionOperator();
				break;

			case "*":
				po = new MultiplicationOperator();
				break;

			case "/":

				po = new DivisionOperator();
				break;
			}
			operatorClicked = true;
			//pendingValue = Convert.ToDouble(digit);
			if(digitEntered)
			{
				pendingResult =  calculator.AcceptNumber(Convert.ToDouble(textView.Text), po);
				digitEntered = false;
				textView.Text = Convert.ToString(pendingResult);
			}
			else
			{
				calculator.AcceptOperator(po);
			}
		}
	}
}

