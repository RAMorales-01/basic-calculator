using System;

namespace Calculator
{
    /*
        Making a basic calculator using enums as options for the 4
        basic math operations, addition, subtraction, multiplication and division
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("This program is a test for basic calculator. Press any key to begin.");
            Console.ReadKey();

            /*var logic = new CalculatorLogic();
            bool exitRequested = false;

            while(!exitRequested)
            {
                BasicOperators selectedOperation = SelectOperator("1- Addition \n2- Subtraction \n3- Multiplication \n4- Division \n");
                var numbers = SelectedNumbers("Enter the 2 numbers for the selected operation");

                try
                {
                    var result = Calculate(numbers.num1, numbers.num2, selectedOperation);

                    Console.Clear();
                    Console.WriteLine($"The result of the math operation {selectedOperation} between numbers {numbers.num1} and {numbers.num2} is:");
                    Console.WriteLine($"{result}");
                    Console.WriteLine();
                }
                catch(DividedByZeroException ex)
                {
                    Console.Clear();
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                
                exitRequested = ExitCalculator("Do you requiere another operation?");
            }  

            Console.Clear();
            Console.WriteLine("Calculator closed. Goodbye!");*/  

            //Manual Testing
            var testRunner = new CalculatorTests();
            testRunner.RunAllTests();     
        }

        ///<summary>
        ///prompts user to choose one of the four basic math operations
        ///</summary>
        ///<param name="prompt">presents to the user the four available options to choose</param>
        ///<returns>enum type with the choosen option</returns>   
        public static BasicOperators SelectOperator(string prompt)
        {
            int selectedOperation = 0;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Please choose the type of operation you whish to perform.\n");
                Console.WriteLine(prompt);
                Console.Write("Type: ");
                string userInput = Console.ReadLine();

                if(int.TryParse(userInput, out selectedOperation))
                {
                    if(selectedOperation <= 0 || selectedOperation > 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid: please choose only 1 of the 4 options available.");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadKey();
                    }
                    else
                    {
                        return (BasicOperators)selectedOperation;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error: invalid expected input integer numbers only between 1 and 4.");
                    Console.WriteLine($"You typed: {userInput}");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        ///<summary>
        ///prompts user to enter both numbers for the previously selected math operation 
        ///</summary>
        ///<param name="prompt">ask user for the numbers to be used on the operations(sum, subtraction, multiplication or division)</param>
        ///<returns>tuple with both double variables with the numbers for the math operation</returns>
        public static (double num1, double num2) SelectedNumbers(string prompt)
        {
                (double num1, double num2) numbers;
                
                while(true)
                {
                    Console.Clear();
                    Console.WriteLine(prompt);
                    Console.Write("\nFirst number: ");
                    string inputNum1 = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(prompt);
                    Console.Write("\nSecond number: ");
                    string inputNum2 = Console.ReadLine();

                    if(double.TryParse(inputNum1, out numbers.num1) && double.TryParse(inputNum2, out numbers.num2))
                    {
                        return numbers;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR INVALID INPUT: expected integer or float numbers. Pess any key to try again.");
                        Console.ReadKey();
                    }
                }
        }

        ///<summary>
        ///Ask user if he/she requieres another type of operation
        ///</summary>
        ///<param name="prompt">prompts for input of y or n</param>
        ///<returns>bool false if user wants to keep doing operations, true if wants to exit</returns>
        public static bool ExitCalculator(string prompt)
        {
            while(true)
                {
                    Console.WriteLine(prompt);
                    Console.Write("Y/N: ");
                    string input = Console.ReadLine().ToLower();

                    if(string.Equals(input, "y", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                    else if(string.Equals(input, "n", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "no", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("ERROR INVALID INPUT: expected 'y' for yes or 'n' for no. Press any key to try again.");
                        Console.ReadKey();
                    }
            }
        }
    }
}