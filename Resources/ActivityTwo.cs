
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
	[Activity (Label = "ActivityTwo")]			
	public class ActivityTwo : Activity

	{
		Boolean Scientific_equals_pressed = false;

		void numberButtonClick(object sender, EventArgs e){
			TextView textView = FindViewById<TextView> (Resource.Id.textView);
			if ((textView.Text == "0")||(Scientific_equals_pressed))
				textView.Text = null;
			Scientific_equals_pressed = false;
			if (sender.ToString() == ".")
			{
				if (!textView.Text.Contains ("."))
					textView.Text += sender.ToString ();
				else
					return;
			}
			else
			{ 
				textView.Text += sender.ToString ();
			}

		}


		protected override void OnCreate (Bundle bundle)
		{ 
			
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.S);

			int[] buttons = {
				Resource.Id.Number_Click0,
				Resource.Id.Number_Click1,
				Resource.Id.Number_Click2,
				Resource.Id.Number_Click3,
				Resource.Id.Number_Click4,
				Resource.Id.Number_Click5,
				Resource.Id.Number_Click6,
				Resource.Id.Number_Click7,
				Resource.Id.Number_Click8,
				Resource.Id.Number_Click9,
			};
			for (int i = 0; i < 10; i++) {

				Button buttonNum = (Button)FindViewById<Button> (buttons [i]);
				buttonNum.Click += (object sender, EventArgs e) => {
					String num = buttonNum.Text;
					numberButtonClick (num, e);
				};
			}

			Button ButtonDot = FindViewById<Button> (Resource.Id.Number_ClickDot);
			ButtonDot.Click += (object sender, EventArgs e) => {
				
				String num = ButtonDot.Text;
				numberButtonClick (num, e);
			};

			Button Paranthesis_Begin = FindViewById<Button> (Resource.Id.Parantehesis_Click_Open);
			Paranthesis_Begin.Click += (sender, e) => {
				String num = Paranthesis_Begin.Text;
				numberButtonClick (num, e);
				
			};
			Button Paranthesis_End = FindViewById<Button> (Resource.Id.Parantehesis_Click_Close);
			Paranthesis_End.Click += (sender, e) => {
				String num = Paranthesis_End.Text;
				numberButtonClick (num, e);

			};

			Button Binary_Operator_Add = FindViewById<Button> (Resource.Id.BinaryOperator_ClickAdd);
			Binary_Operator_Add.Click += (object sender, EventArgs e) => {
				
				String num = Binary_Operator_Add.Text;

				numberButtonClick (num, e);

			};

			Button Binary_Operator_Sub = FindViewById<Button> (Resource.Id.BinaryOperator_ClickSub);
			Binary_Operator_Sub.Click += (object sender, EventArgs e) => {
				
				String num = Binary_Operator_Sub.Text;

				numberButtonClick (num, e);
			};

			Button Binary_Operator_Mul = FindViewById<Button> (Resource.Id.BinaryOperator_ClickMul);
			Binary_Operator_Mul.Click += (object sender, EventArgs e) => {
				
				String num = Binary_Operator_Mul.Text;
				numberButtonClick (num, e);
			};

			Button Binary_Operator_Div = FindViewById<Button> (Resource.Id.BinaryOperator_ClickDiv);
			Binary_Operator_Div.Click += (object sender, EventArgs e) => {
				
				String num = Binary_Operator_Div.Text;

				numberButtonClick (num, e);
			};

			Button EqualsPressed = FindViewById<Button> (Resource.Id.Equal_Click);
			EqualsPressed.Click += (object sender, EventArgs e) => {
				

				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				//cu.History_list.Add(textView.Text);
				//cu.History_list.Add("\r\n");
				Scientific_equals_pressed = true;
				Double res = MathParser.eval_Expression(textView.Text.ToCharArray());
				textView.Text= res.ToString();




			};


			Button Clear_button = FindViewById<Button> (Resource.Id.Clear);

			Clear_button.Click += (object sender, EventArgs e) => {
				TextView textView = FindViewById<TextView> (Resource.Id.textView);
				textView.Text = null;
			};




		}

		
	}
}

