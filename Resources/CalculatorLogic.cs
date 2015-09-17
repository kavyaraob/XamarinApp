
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
	//enum LHSNumber {AVAILABLE, NOT_AVAILABLE};
		public class CalculatorLogic
		{
			public int acceptNumberCount = 0;
		//public bool isLHSNumberAvailable = false;
		//public LHSNumber lhsNumberAvailability = LHSNumber.NOT_AVAILABLE;
			public int equalsCount = 0;
			public int acceptOperatorCount = 0;
			public int ct =0;
			bool an = false;
			bool ao = false;


	

			private IBinaryOperator pendingOperation = null;
			// To be decided in Class

			double firstNumber ;   //used to store the pedning values.
			double secondNumber ;

			void acceptNumber_LHS_perform (double d, IBinaryOperator operation)
			{
			double res = pendingOperation.perform (firstNumber, d);
			firstNumber = res;
			pendingOperation = operation;

			}

			void accept_number_save_LHS (double d, IBinaryOperator operation)
			{
			pendingOperation = operation;
			firstNumber = d;

			}




			//public Tuple<double,string> AcceptNumber(double d, IBinaryOperator operation)
		public string AcceptNumber(double d, IBinaryOperator operation)
			{
				acceptNumberCount++;
				if (operation == null)
				{
					an = false;
					ct++;
					secondNumber =  d;
					return Convert.ToString(secondNumber);
				}  
				else
				{
				//if ( lhsNumberAvailability==LHSNumber.AVAILABLE)
				//if (isLHSNumberAvailable)
					if (acceptNumberCount == 1 && acceptOperatorCount >= 1)    //when AN is called after multiple operators
					{

						firstNumber = pendingOperation.perform(0, d);
						pendingOperation = operation;
						return Convert.ToString(firstNumber);
					//return new Tuple<double, string> (firstNumber, null);
					}

					else if ((acceptNumberCount > 1 && equalsCount == 0))  //An is called and needs to saves result and perofrms operation
					{

						acceptNumber_LHS_perform (d, operation);
						return Convert.ToString (firstNumber);
					}
					else if ((an) && acceptNumberCount > 1 && equalsCount >= 1)
					{
						acceptNumber_LHS_perform (d, operation);
						return Convert.ToString (firstNumber);
						
					}

					else if (acceptNumberCount > 1 && equalsCount >= 1)  //when AN is called after an equals is called
					{
						an = true;
						accept_number_save_LHS (d, operation);
						return Convert.ToString (firstNumber);
					}
					else if (acceptNumberCount > 1 && equalsCount >= 1 && acceptOperatorCount >= 1)  //when AN is called after an equals is called
					{
						acceptNumber_LHS_perform (d, operation);
						return Convert.ToString(firstNumber);
					}
				else
						// An is called in normal cases
						accept_number_save_LHS (d, operation);
						return Convert.ToString (firstNumber);
				}               
			}


			public string AcceptOperator(IBinaryOperator operation)
			{
				ao = true;
				acceptOperatorCount++;
				if (equalsCount >= 1 || acceptOperatorCount >= 1)
				{
					secondNumber = firstNumber;

				}

				pendingOperation = operation;
				return Convert.ToString(firstNumber);

			}

			public string Equals()
			{

				ao = false;
				equalsCount++;
				try {
					if (pendingOperation == null)
					{
						if ( secondNumber != 0 || firstNumber!=0)
							return Convert.ToString(secondNumber);
						else
							return Convert.ToString(0);
					}

					else if (equalsCount > 1)
					{
						double y = pendingOperation.perform(firstNumber, secondNumber);
						firstNumber = y;
						return Convert.ToString(firstNumber);
					}

					else if (ct == 0)
					{
						secondNumber = firstNumber;
						double result = pendingOperation.perform(firstNumber, secondNumber);
						firstNumber = result;
						return Convert.ToString(firstNumber);
					}
					else
					{
						double result = pendingOperation.perform(firstNumber, secondNumber);       
						firstNumber = result;
						return Convert.ToString(firstNumber);
					}
				}
				catch (ArithmeticException e)
				{

					return e.Message;

				}
			}
		}

}

