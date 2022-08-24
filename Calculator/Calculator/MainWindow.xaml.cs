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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            //Event Handlers
            acBtn.Click += AcBtn_Click;
            plusMinusBtn.Click += PlusMinusBtn_Click;
            percentBtn.Click += PercentBtn_Click;
            equalsBtn.Click += EqualsBtn_Click;
        }


        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            //evaluate the selected operator
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                //if parsed evaluate switch statement
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Diviison(lastNumber, newNumber);
                        break;

                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            //Try and parse the string content into a number
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //Assign it negative 
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            //Try and parse the string content into a number
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //Assign it negative 
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            //Try and parse the string content into a number
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if(sender == multiplyBtn)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if(sender == divideBtn)
            {
                selectedOperator = SelectedOperator.Division;
            }
            if (sender == plusBtn)
            {
                selectedOperator = SelectedOperator.Addition;

            }
            if (sender == minusBtn)
            {
                selectedOperator = SelectedOperator.Subtraction;

            }

        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            //Gets selected value and parses it gets the content as to string 
            int selectedValue = int.Parse((sender as Button).Content.ToString());



            //Logic for number values
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}"; 
            }
            else
            {
                //This adds the 7 and the other 7s to trail after
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        public void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if contains a string "." if it does then do nothing
            if (resultLabel.Content.ToString().Contains("."))
            {
                //Do nothing
            }
            else
            {
                //Add Decimal Point
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        //Create out own operators
        public enum SelectedOperator
        {
            Addition, 
            Subtraction,
            Multiplication,
            Division
        }

    }
}
