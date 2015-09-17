using System;
using System.Collections.Generic;
using Android.Widget;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;

using Android.OS;
using Calculator;

namespace Calculator
{
	public class CalculatorUtils
	{
		public CalculatorUtils ()
		{
		}
		//MainActivity mn = new MainActivity();
		enum digit_Pressed{digit_entered, digit_not_entered}
		IHistoryList il;
		public IList<string> History_list = new List<string>();
		IBinaryOperator po;
		string pendingOperator = "";
		Double pendingValue;
		public bool digitEntered = false;
		public bool operatorClicked = false;
		string pendingResult = "";
		public bool Eqpressed = false;
		int opCount = 0;
		string result = "";
		string digit;
		IUnaryOperator puO;
		double UnaryResult;
		CalculatorLogic calculator = new CalculatorLogic();
		public bool UopClicked = false;
		bool eqCalc = false;
		public bool Num_Pressed = false;
		public bool op_Pressed = false;
		public enum digit_entered{
			digit_is_entered, 
			digit_not_entered};



		public void binaryOperatorClick(object sender, TextView textView, EventArgs e, IBinaryOperator operator_passed)
		{
			
			if (!operatorClicked) { History_list.Add(textView.Text); }
			//else { History_list.Add(Convert.ToString(0)); }
			pendingOperator = sender.ToString ();
			opCount++;
			if (!digitEntered) {
				
				int size = History_list.Count;
				History_list.RemoveAt(size-1);

			}
			History_list.Add (pendingOperator);
			//History_list.Add (pendingOperator);
			pendingValue = Convert.ToDouble(textView.Text);

			operatorClicked = true;
			op_Pressed = true;
			//pendingValue = Convert.ToDouble(digit);
			if(digitEntered)
			{
				pendingResult =  calculator.AcceptNumber(Convert.ToDouble(textView.Text), operator_passed);

				digitEntered = false;

				textView.Text = Convert.ToString(pendingResult);

			}
			else
				calculator.AcceptOperator(operator_passed);
			
		}

		public void UnaryOperatorCLick(object sender, TextView textView, EventArgs e , IUnaryOperator unary_operator_passed, string operator_display)
		{

			History_list.Add (operator_display);
			History_list.Add (textView.Text);
			History_list.Add("\r\n");
			string pendingUnaryOperator = sender.ToString();
			UopClicked = true;
			UnaryResult = unary_operator_passed.perform(Convert.ToDouble(textView.Text));
			textView.Text = Convert.ToString(UnaryResult);
		}

		public void Eq_calc (TextView textView)
		{//get a bool value n check if eq is pressed once or twice
				History_list.Add (textView.Text);
			History_list.Add ("\r\n");
			// Environment.NewLine;
			Eqpressed = true;
			if (((opCount >= 1) && (Num_Pressed))|| (op_Pressed)) {
				
				calculator.AcceptNumber (Convert.ToDouble (textView.Text), null);
				Num_Pressed = false;
				op_Pressed = false;
			}
			pendingValue = Convert.ToDouble (textView.Text);
			result = calculator.Equals ();
			textView.Text = result;
		}

		public void viewHistoryMethod (TextView textViewHistory)
		{
			bool vh = false;
			if (vh) {
				History_list.Clear ();
				il = new View_History ();
				textViewHistory.Text = il.perform_history (History_list);
			}
			else {
				vh = true;
				il = new View_History ();
				textViewHistory.Text = il.perform_history (History_list);
			}
		}



		public string[] getHistor(){
			string hist_string = "";
			foreach(string x in History_list)
				 hist_string += x;
			char c = '\n';
			string[] history_array = hist_string.Split (c);
			return history_array;

		}


		public void saveHistory(){
			System.IO.File.WriteAllLines(@"C:\NewFolder\HistoryList.txt", History_list);
		}


	}
}

