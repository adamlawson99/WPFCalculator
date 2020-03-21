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
using System.Linq;

namespace Calculator
{
    
    class ButtonHandler
    {
        private readonly string[] operators = {"+","-","/","*"};
        private readonly string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", };
        private ArrayList userInput;
        public ButtonHandler(ArrayList userInput)
        {
            this.userInput = userInput;
        }
        public ArrayList Button_Number_Click(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag.ToString();
            userInput.Add(myValue);
            return userInput;

        }

        //user should only be able to enter one operator, then have to enter a number
        public ArrayList Button_Operator_Click(object sender, RoutedEventArgs e)
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
        }

        //period button must be disabled after user clicks, until an operator is clicked
        public ArrayList Button_Period_Click(object sender, RoutedEventArgs e)
        {
            int precedingElem = userInput.Count - 1;
            if(operators.Contains(userInput[precedingElem]))
            {
                userInput.Add("0");
                userInput.Add(".");
                return userInput;
            }
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

        public void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(userInput.Count > 1)
            {

            }
        }

        //returns true if no other elements have been added to the array
        private bool VerifyPeriod()
        {
            return true;
        }
    }
}
