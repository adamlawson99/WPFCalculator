using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace Calculator
{
    class ExpressionEvaluator
    {
        public static string EvaluateExpression(ArrayList userInput)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in userInput)
            {
                sb.Append(s);
            }
            DataTable dt = new DataTable();
            var result = dt.Compute(sb.ToString(),"");
            string result_string = result.ToString();
            userInput.Clear();
            return result_string;
        }
    }
}
