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
            userInput = new ArrayList() {};
            stringBuilder = new StringBuilder("0", 100);
            setContent(userInput);
            stringBuilder.Clear();
            this.buttonHandler = new ButtonHandler(userInput);
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

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            userInput = buttonHandler.Button_Number_Click(sender, e);
            setContent(userInput);
        }

        //user should only be able to enter one operator, then have to enter a number
        private void Button_Operator_Click(object sender, RoutedEventArgs e)
        {
            userInput = buttonHandler.Button_Operator_Click(sender, e);
            btn_period.IsEnabled = true;
            setContent(userInput);
        }

        //period button must be disabled after user clicks, until an operator is clicked
        private void Button_Period_Click(object sender, RoutedEventArgs e)
        {
            userInput = buttonHandler.Button_Period_Click(sender, e);
            btn_period.IsEnabled = false;
            setContent(userInput);
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            this.userInput.Clear();
            this.stringBuilder.Append("0");
            btn_period.IsEnabled = true;
            setContent(userInput);
        }
    }
}
