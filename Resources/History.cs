
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
		
			public interface IHistoryList //: IEnumerator<string> , IEnumerable<string>
			{
				string perform_history(IList<string> s);
				/*
        string Memory_perform();
        void Memory_perform(string val);
        string Memory_perform(string val);*/

			}


	/*public class CalculationHistory{
		IList<string> previousCalcs;
		public void Add(string s) {
			previousCalcs.Add (s);
		}

		public string allPreviousCalcs ()
		{
			string result =
				previousCalcs.Aggregate (new StringBuilder (), (sb, n) => sb.AppendLine (n), sb => sb.ToString ());
		}

	}*/
			public class View_History : IHistoryList
			{

				public string perform_history(IList<string> s)
				{
					string temp = "";
					foreach(string x in s)
					{
						temp += x;
					}

					return temp;
				}
			}


			public class Clear_History : IHistoryList
			{

				public string perform_history(IList<string> s)
				{
					s.Clear();
					return "";
				}
			}


			/*
    class Memory_Clear : Ilist
    {
        private IList<string> iList = new List<string>();
        string Memory_perform()
        {
            iList.Clear();
            return "";   // check the return method.
        }
        
    }


    class Memory_Recall : Ilist
    {
        private IList<string> iList = new List<string>();
        string Memory_perform()
        {
            string variable = iList.ElementAt(0);
            return variable;
        }

    }

    class Memory_Store : Ilist
    {
        private IList<string> iList = new List<string>();

        void Memory_perform(string val)
        {
             iList.Add(val);
           
        }

    }

    class Memory_Plus : Ilist
    {
        private IList<string> iList = new List<string>();
        
        void Memory_perform(string tempVariable)
        {
            string variable = iList.ElementAt(0);
            string newVariable = variable + tempVariable;
            
            
        }

    }

    */


}

