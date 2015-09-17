using System;

namespace Calculator
{
	public class MathParser
	{
		public static double eval_Expression(char[] expr)
		{
			
			return parseSummands (expr, 0);
		
		}


		private static double parseSummands(char[] expr,   int index)
		{
			double x = parseFactors (expr, ref index);
			while (true) {
				char op = expr [index];


				if(op != '+' && op != '-' )
					

					return x;
				index++;
				double y = parseFactors(expr, ref index);
				if(op== '+')
					x+=y;
				else
					x-=y;


			}
		}

		private static double parseFactors(char[] expr, ref int index)
		{
			double x =   getDouble (expr, ref index);

			
			while (true) {
				char op = expr [index];


				if(op != '/' && op != '*' )
					return x;
				index++;
				double y =   getDouble (expr, ref index);
				if(op== '/')

					x/=y;
				else
					x*=y;

			}
		}


		private static double parseBraces(char[] expr, ref int index)
		{
			
				
			double x = parseFactors (expr, ref index);
				
			while (index != expr.Length - 1) {
				char op = expr [index];
				index++;
				if (op == ')')
					return  x;
				double y = parseFactors (expr, ref index);
				if (op == '+')
					x += y;
				else if (op == '-')
					x -= y;
				else if (op == '*')
					x *= y;
				else if (op == '/')
					x /= y;
				
				//index++;
			}
			return x;
			//return x;
		}

		private static double getDouble(char[] expr, ref int index)
		{string dbl = "";
			while(((int)expr[index]>=48) &&((int)expr[index]<=57)||(expr[index]==46))
			{
				dbl=dbl+ expr[index].ToString();
				index++;
				if(index==expr.Length)
				{index--;
					break;

				}
			}

			while ((int)expr [index] == 40) {

				index++;
				//return parseBraces (expr, ref index);
			return parseBraces (expr, ref index);
			}

			return double.Parse(dbl);
			
			
		}
	}
}

