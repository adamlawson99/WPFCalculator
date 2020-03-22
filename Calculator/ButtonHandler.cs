using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Calculator
{
    
    class ButtonHandler
    {
        private readonly string[] operators = {"+","-","/","*"};
        private readonly string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };
        public ArrayList Button_Number_Click(object sender, RoutedEventArgs e, ArrayList userInput)
        {
            var myValue = ((Button)sender).Tag.ToString();
            userInput.Add(myValue);
            return userInput;

        }

        //user should only be able to enter one operator, then have to enter a number
        public ArrayList Button_Operator_Click(object sender, RoutedEventArgs e, ArrayList userInput)
        {
            try
            {
                int precedingElem = userInput.Count - 1;
                if (userInput[precedingElem].Equals("."))
                {
                    userInput[precedingElem] = ((Button)sender).Tag;
                    return userInput;
                }
                if (operators.Contains(userInput[precedingElem]))
                {
                    return userInput;
                }
                if (numbers.Contains(userInput[precedingElem]))
                {
                    userInput.Add(((Button)sender).Tag);
                    return userInput;
                }
                else
                {
                    return userInput;
                }
            }catch(ArgumentOutOfRangeException err)
            {
                Console.WriteLine(err);
                return userInput;
            }
        }

        //period button must be disabled after user clicks, until an operator is clicked
        public ArrayList Button_Period_Click(object sender, RoutedEventArgs e, ArrayList userInput)
        {

            int precedingElem = userInput.Count - 1;
            //check if the array is null
            if(userInput.Count == 0)
            {
                userInput.Add("0");
                userInput.Add(".");
                return userInput;
            }
            //check if user enters a period after an operator
            if(operators.Contains(userInput[precedingElem]))
            {
                userInput.Add("0");
                userInput.Add(".");
                return userInput;
            }
            //check if user enters a period after a number
            if (numbers.Contains(userInput[precedingElem]))
            {
                userInput.Add(".");
                return userInput;
            }
            //if the user entered a period then tries to enter another period ignore it
            else
            {
                return userInput;
            }
        }

        public void Button_Delete_Click(object sender, RoutedEventArgs e, ArrayList userInput)
        {
            if(userInput.Count > 1)
            {

            }
        }

        public string Button_Click_Equals(object sender, RoutedEventArgs e, ArrayList userInput)
        {
           string result  = ExpressionEvaluator.EvaluateExpression(userInput);
           return result;
        }
    }
}
