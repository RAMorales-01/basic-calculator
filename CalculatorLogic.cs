using System;

namespace Calculator
{
    ///<summary>
    ///A representation of the four basic math operators
    ///</summary>
    public enum BasicOperators
    {
        Addition = 1,
        Subtraction,
        Multiplication,
        Division
    }

    ///<summary>
    ///Performs a basic math operation of two numbers
    ///</summary>
    ///<param name="num1">the first number selected by the user for math operation</param>
    ///<param name="num2">the second number selected by the user for math operation</param>
    ///<returns>double with the result of the calculation between num1 and num2</returns>
    ///<exception cref="DivideByZeroException">thrown when user tries to divide by zero</exception>
    ///<exception cref="ArgumentException">thrown for an invalid or unsupported operation</exception>
    public class CalculatorLogic
    {
        public double Calculate(double num1, double num2, BasicOperators selectedOperation)
        {
            switch(selectedOperation)
            {
                case BasicOperators.Addition:
                    return num1 + num2;

                case BasicOperators.Subtraction:
                    return num1 - num2;

                case BasicOperators.Multiplication:
                    return num1 * num2;

                case BasicOperators.Division:
                    if(num2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return num1 / num2;

                default:
                    throw new ArgumentException("Invalid operation selected", nameof(selectedOperation));
            }

        }

    }
}