using System;

namespace Calculator
{
	public class HistoryEquationParser
	{ 
		
		public HistoryEquationParser()
		{
			
		}

		public static string eval_Equation(char[] expr)
		{
			
			return parse_Equation (expr, 0);

		}

		private static void perform_op (double x, char op, CalculatorLogic cl)
		{
			IBinaryOperator subOperator = new SubtractionOperator();
			IBinaryOperator mulOperator = new MultiplicationOperator();
			IBinaryOperator divOperator = new DivisionOperator();
			IBinaryOperator addOperator = new AdditionOperator();

			if (op == '+')
				cl.AcceptNumber (x, addOperator);
			else
				if (op == '-')
					cl.AcceptNumber (x, subOperator);
				else
					if (op == '*')
					cl.AcceptNumber (x,mulOperator);
					else
						if (op == '/')
						cl.AcceptNumber (x, divOperator);

		}

		private static string parse_Equation(char[] expr,   int index)
		{

			CalculatorLogic cl = new CalculatorLogic();

			string num = "";
			if((int)expr[index]==83){
				index += 4;
				if((int)expr[index]==32){
					for(int i = index; i<= expr.Length-2;i++)
					 num += expr [i].ToString();
				}
				double srt_num = double.Parse (num);
				IUnaryOperator sqrt = new Sqrt ();
				return Convert.ToString(sqrt.perform (srt_num));
			}
			if((int)expr[index]==82){
				index += 10;
				if((int)expr[index]==32){
					for(int i = index; i<= expr.Length-2;i++)
						num += expr [i].ToString();
				}
				double srt_num = double.Parse (num);
				IUnaryOperator reci = new Reciprocal ();
				return Convert.ToString(reci.perform (srt_num));
			}
			if((int)expr[index]==78){
				index += 6;
				if((int)expr[index]==32){
					for(int i = index; i<= expr.Length-2;i++)
						num += expr [i].ToString();
				}
				double srt_num = double.Parse (num);
				IUnaryOperator neg = new Negate ();
				return Convert.ToString(neg.perform (srt_num));
			}
			while (index != expr.Length - 1) {
				double x = getDouble (expr, ref index);
				char op = expr [index];

				index++;

				if (op == '\r') {
					cl.AcceptNumber (x, null);
					string result = cl.Equals ();
					return result;
				}
				perform_op (x, op, cl);

			}
			return "";
			//return value;
	}

		private static double getDouble(char[] expr, ref int index)

		{
			string dbl = "";
			while(((int)expr[index]>=48) &&((int)expr[index]<=57)||(expr[index]==46))
			{
				dbl=dbl+ expr[index].ToString();
				index++;
				if(index==expr.Length)
				{index--;
					break;

				}
			}
				

		
			return double.Parse(dbl);


		}
	}
}

