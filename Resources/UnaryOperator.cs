
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
	
		public interface IUnaryOperator
		{
			double perform(double value);
		}

		public class Sqrt : IUnaryOperator
		{

			public double perform(double value){

				return Math.Sqrt(value);


			}

		}

		public class Reciprocal : IUnaryOperator 
		{ 
			public double perform(double value)
			{
				if (value == 0.0)
				{
					throw new ArithmeticException("Result Undefined");

				}
				return 1 / value;
			}
		}

		public class Negate : IUnaryOperator 
		{
			public double perform(double value)
			{
				if (value == 0)
					return 0;
				else 
					return (value * -1);           
			}
		}


}

