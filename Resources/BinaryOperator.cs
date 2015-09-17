
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
	
		public interface IBinaryOperator
		{
			double perform(double lhs, double rhs);
		}

		public class AdditionOperator : IBinaryOperator
		{
			public double perform(double lhs, double rhs) { return lhs + rhs; }
		}

		public class SubtractionOperator : IBinaryOperator
		{
			public double perform(double lhs, double rhs) { return lhs - rhs; }
		}

		public class MultiplicationOperator : IBinaryOperator
		{
			public double perform(double lhs, double rhs) { return lhs * rhs; }
		}

		public class DivisionOperator : IBinaryOperator
		{
			public double perform(double lhs, double rhs) {
				if (rhs == 0.0)
				{
				if (lhs == 0.0) {
					throw new ArithmeticException ("Undefined result");
				}
					throw new ArithmeticException("Cannot divide by 0");
					//return 0.0;
			}
				return lhs / rhs; 
			}
	}
	}


