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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList userInput;
        private int i = 0;
        private StringBuilder stringBuilder;
        private ButtonHandler buttonHandler;
        public MainWindow()
        {
            InitializeComponent();
            this.buttonHandler = new ButtonHandler();
            userInput = new ArrayList() {};
            this.stringBuilder = new StringBuilder("", 100);
            setContent("0");
        }
        
        public void setContent(ArrayList userInput)
        {
            foreach(string op in userInput)
            {
                stringBuilder.Append(op);
            }
            DisplayArea.Content = stringBuilder.ToString();
            stringBuilder.Clear();
        }

        public void setContent(string ans)
        {
            DisplayArea.Content = ans;
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            buttonHandler.Button_Number_Click(sender, e, userInput);
            setContent(userInput);
        }

        //user should only be able to enter one operator, then have to enter a number
        private void Button_Operator_Click(object sender, RoutedEventArgs e)
        {
            buttonHandler.Button_Operator_Click(sender, e, userInput);
            btn_period.IsEnabled = true;
            setContent(userInput);
        }

        //period button must be disabled after user clicks, until an operator is clicked
        private void Button_Period_Click(object sender, RoutedEventArgs e)
        {
            buttonHandler.Button_Period_Click(sender, e, userInput);
            btn_period.IsEnabled = false;
            setContent(userInput);
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(userInput.Count == 1)
            {
                setContent("0");
                return;
            }
            if(userInput.Count >= 1)
            {
                buttonHandler.Button_Delete_Click(sender, e, userInput);
                setContent(userInput);
            }

        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            buttonHandler.Button_Click_Clear(sender,e,userInput);
            btn_period.IsEnabled = true;
            setContent(userInput);
        }

        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
           string result = buttonHandler.Button_Click_Equals(sender, e, userInput);
           setContent(result);
            
        }

        private void Button_Click_Clear_Entry(object send, RoutedEventArgs e)
        {

        }
    }
}
