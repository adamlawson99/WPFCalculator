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
        private StringBuilder stringBuilder;
        public MainWindow()
        {
            InitializeComponent();
            userInput = new ArrayList();
            stringBuilder = new StringBuilder("", 100);
        }
        
        public void setContent(String userInputAsString)
        {
            DisplayArea.Content = userInputAsString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag.ToString();
            userInput.Add(myValue);
            setContent(ConstructString(userInput));
            
        }

        private string ConstructString(ArrayList userInput) { 
            //append the last item the user entered to the string after verifying the string is not empty
            if(userInput.Count > 0)
            {
                stringBuilder.Append(userInput[userInput.Count-1]);
                return stringBuilder.ToString();
            }
            return "";
        }
    }
}
