using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Calculator;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Calculator
{ 
	
	[Activity (Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity 
	{  CalculatorUtils cu = new CalculatorUtils ();

		//bool digitEntered = false;
		//bool operatorClicked = false;
		//bool Eqpressed = false;
		//bool UopClicked = false;
		string digit;

		//Ilist il;
		//IList<string> iList = new List<string>();

		//IBinaryOperator po2;

		IBinaryOperator subOperator = new SubtractionOperator();
		IBinaryOperator mulOperator = new MultiplicationOperator();
		IBinaryOperator divOperator = new DivisionOperator();
		IBinaryOperator addOperator = new AdditionOperator();

		IUnaryOperator sqrtOperator = new Sqrt ();
		IUnaryOperator negateOperator = new Negate();
		IUnaryOperator reciprocalOperator = new Reciprocal();
		public bool Eqpressed = false;
		String memory_save_number ="";
		List<string> history = new List<string> ();


	
		public void numberButtonClick(object sender, EventArgs e)
		{
			List<string> values = new List<string>();
			TextView textView = FindViewById<TextView> (Resource.Id.textView);
			cu.digitEntered = true;
			//cu.Eqpressed = true;
			cu.Num_Pressed = true;

			if ((textView.Text == "0") || (cu.operatorClicked) || (cu.Eqpressed)||(cu.UopClicked))
				textView.Text = null;
			cu.operatorClicked = false;
			cu.UopClicked = false;
			cu.Eqpressed = false;
			if (sender.ToString() == ".")
			{
				if (!textView.Text.Contains (".")) {
					textView.Text += sender.ToString ();
					history.Add (sender.ToString ());
				}
				else
					return;
			}
			else
			{ 
				digit = sender.ToString ();
				textView.Text += digit;	
				history.Add (sender.ToString ());

			}

			if ((sender.ToString()=="(")||(textView.Text == "(")){
				do{
					values.Add (sender.ToString());
				}while(sender.ToString() == ")");
			}


		}

		protected override void OnCreate (Bundle bundle) 
		{

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);




			List<string> history = new List<string> ();

			int[] buttons = {Resource.Id.Number_Click0, Resource.Id.Number_Click1, Resource.Id.Number_Click2, Resource.Id.Number_Click3, Resource.Id.Number_Click4,
							Resource.Id.Number_Click5, Resource.Id.Number_Click6, Resource.Id.Number_Click7, Resource.Id.Number_Click8, Resource.Id.Number_Click9,	};
			for (int i = 0; i < 10 ; i++) {
				
				Button buttonNum = (Button) FindViewById<Button>(buttons[i]);
				buttonNum.Click+=(object sender, EventArgs e) => {
				String num = buttonNum.Text;
				numberButtonClick(num ,  e);

				};
			}
		

			Button ButtonDot = FindViewById<Button>(Resource.Id.Number_ClickDot);
			ButtonDot.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String num = ButtonDot.Text;
				numberButtonClick(num ,  e);
			};

			Button Binary_Operator_Add = FindViewById<Button>(Resource.Id.BinaryOperator_ClickAdd);
			Binary_Operator_Add.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String num = Binary_Operator_Add.Text;

				cu.binaryOperatorClick(num ,textView,e,addOperator);

			};

		Button Binary_Operator_Sub = FindViewById<Button>(Resource.Id.BinaryOperator_ClickSub);
			Binary_Operator_Sub.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String op = Binary_Operator_Sub.Text;

				cu.binaryOperatorClick(op, textView ,e,subOperator);
			};

		Button Binary_Operator_Mul = FindViewById<Button>(Resource.Id.BinaryOperator_ClickMul);
			Binary_Operator_Mul.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String op = Binary_Operator_Mul.Text;
				cu.binaryOperatorClick(op,textView , e,mulOperator);
			};

		Button Binary_Operator_Div = FindViewById<Button>(Resource.Id.BinaryOperator_ClickDiv);
			Binary_Operator_Div.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String op = Binary_Operator_Div.Text;

				cu.binaryOperatorClick(op,textView , e,divOperator);
			};

			Button Unary_Operator_Negate = FindViewById<Button>(Resource.Id.UnaryOperator_Negate);
			Unary_Operator_Negate.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String num = Unary_Operator_Negate.Text;
				String negate = "Negate ";
				cu.UnaryOperatorCLick(num,textView , e, negateOperator, negate);
			};

			Button Unary_Operator_Square = FindViewById<Button>(Resource.Id.UnaryOperator_Sqrt);
			Unary_Operator_Square.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String num = Unary_Operator_Square.Text;
				String Sqrt = "Sqrt ";
				cu.UnaryOperatorCLick(num, textView , e , sqrtOperator, Sqrt);
			};

			Button Unary_Operator_Reciprocal = FindViewById<Button>(Resource.Id.UnaryOperator_Reci);
			Unary_Operator_Reciprocal.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String num = Unary_Operator_Reciprocal.Text;
				String Reci = "Reciprocal ";
				cu.UnaryOperatorCLick(num,textView , e , reciprocalOperator, Reci);
			};

		Button EqualsPressed = FindViewById<Button>(Resource.Id.Equal_Click);
			EqualsPressed.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				cu.Eq_calc (textView);
			};

			Button save_history = FindViewById<Button> (Resource.Id.S_Hist);
			save_history.Click += (object sender, EventArgs e) => {
				
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
				var fileName = Path.Combine(path, "write.txt");
				File.WriteAllText(fileName, string.Join("", cu.History_list));
				cloud.saveFile();
			};





			Button History_button = FindViewById<Button>(Resource.Id.ButtonHistory);
			EditText textViewHistory0 = FindViewById<EditText> (Resource.Id.textViewHis0);
			EditText textViewHistory1 = FindViewById<EditText> (Resource.Id.textViewHis1);
			EditText textViewHistory2 = FindViewById<EditText> (Resource.Id.textViewHis2);
			EditText textViewHistory3 = FindViewById<EditText> (Resource.Id.textViewHis3);
			EditText textViewHistory4 = FindViewById<EditText> (Resource.Id.textViewHis4);
			EditText textViewHistory5 = FindViewById<EditText> (Resource.Id.textViewHis5);
			EditText textViewHistory6 = FindViewById<EditText> (Resource.Id.textViewHis6);

			Button Clear_History = FindViewById<Button> (Resource.Id.Clear_history);
			Clear_History.Click += (object sender , EventArgs e) => {

				textViewHistory0.Text = null;
				textViewHistory1.Text = null;
				textViewHistory2.Text = null;
				textViewHistory3.Text = null;
				textViewHistory4.Text = null;
				textViewHistory5.Text = null;
				textViewHistory6.Text = null;

			};

			History_button.Click += (object sender, EventArgs e) => {
				string[] new_array = cu.getHistor();

				if(new_array[0].Length==0)
					return;
				else{
					textViewHistory0.Text = new_array[0];}
				if(new_array[1].Length==0)
					return;
					else{
					textViewHistory1.Text = new_array[1];}
				if(new_array[2].Length == 0)
					return;
				else{
					textViewHistory2.Text = new_array[2];}
				if(new_array[3].Length == 0)
					return;
				else{
					textViewHistory3.Text = new_array[3];}
				if(new_array[4].Length == 0)
					return;
				else{
					textViewHistory4.Text = new_array[4];}
				if(new_array[5].Length == 0)
					return;
				else{
					textViewHistory5.Text = new_array[5];}
				if(new_array[6].Length == 0)
					return;
				else{
					textViewHistory6.Text = new_array[6];}
					
				};

			Button memory_Save = FindViewById<Button> (Resource.Id.memory_save);
			memory_Save.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				 memory_save_number = textView.Text;

			};

			Button memory_Recall = FindViewById<Button> (Resource.Id.memory_recall);
			memory_Recall.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				textView.Text = memory_save_number;
			};

			Button memory_Clear = FindViewById<Button> (Resource.Id.memory_clear);
			memory_Clear.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				memory_save_number = "";
			};
			Button memory_Plus = FindViewById<Button> (Resource.Id.Memory_plus);
			memory_Plus.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				memory_save_number = textView.Text;
			};
			Button memory_Minus = FindViewById<Button> (Resource.Id.Memory_minus);
			memory_Minus.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				memory_save_number = "";
			};


			textViewHistory0.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);

				String res = HistoryEquationParser.eval_Equation(textViewHistory0.Text.ToCharArray());
					textView.Text= res;
			};

			textViewHistory1.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String res = HistoryEquationParser.eval_Equation(textViewHistory1.Text.ToCharArray());
				textView.Text= res;
			};



			textViewHistory2.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				String res = HistoryEquationParser.eval_Equation(textViewHistory2.Text.ToCharArray());
				textView.Text= res;
			};
			textViewHistory3.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);

				String res = HistoryEquationParser.eval_Equation(textViewHistory3.Text.ToCharArray());
				textView.Text= res;
			};
			textViewHistory4.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);

				String res = HistoryEquationParser.eval_Equation(textViewHistory4.Text.ToCharArray());
				textView.Text= res;
			};
			textViewHistory5.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);

				String res = HistoryEquationParser.eval_Equation(textViewHistory5.Text.ToCharArray());
				textView.Text= res;
			};
			textViewHistory6.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);

				String res = HistoryEquationParser.eval_Equation(textViewHistory6.Text.ToCharArray());
				textView.Text= res;
			};


			Button ClearEntry_button = FindViewById<Button>(Resource.Id.Clear_Entry);
		
			ClearEntry_button.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				if (!cu.operatorClicked)
				{

					int clearVal = Convert.ToInt16(textView.Text);
					clearVal /= 10;
					textView.Text = Convert.ToString(clearVal);       
				}

			};


			Button Clear_button = FindViewById<Button>(Resource.Id.Clear);

			Clear_button.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				textView.Text = null;
			};

			Button Scientific_calc = FindViewById<Button> (Resource.Id.S_calc);
			Scientific_calc.Click += (object sender, EventArgs e) => {
				
				StartActivity(typeof(ActivityTwo));		
			};



		}
	}

}


