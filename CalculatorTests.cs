using System;
using Calculator;

public class CalculatorTests
{
    //fields: instance of logic, one var for passed tests and other for failed tests.
    private CalculatorLogic _calculator = new CalculatorLogic();
    private int _passed = 0;
    private int _failed = 0;

    public void RunAllTests()
    {
        Console.WriteLine("\n--- Starting Calculator Unit Tests ---\n");
        TestAddition();
        TestSubtraction();
        TestMultiplication();
        TestDivision();
        TestDivisionByZero();
        Console.WriteLine("\n--- Tests Finished ---\n");
        Console.WriteLine($"Total passed: {_passed} | Total failed: {_failed}\n");
    }    

    //This helper method will make the comparison between the expected output and the actual output
    private void ExpectedResultAndActualOutput(double expected, double actual, string testName)
    {
        if(actual == expected)
        {
            Console.WriteLine($"[PASSED] {testName}");
            _passed++;
        }
        else
        {
            Console.WriteLine($"[FAILED] {testName}: Expected output {expected}, got {actual}");
            _failed++;
        }
    }

    public void TestAddition()
    {
        double result = _calculator.Calculate(5, 5, BasicOperators.Addition);
        ExpectedResultAndActualOutput(10, result, "test 5 + 5");
    } 

    public void TestSubtraction()
    {
        double result = _calculator.Calculate(10, 5, BasicOperators.Subtraction);
        ExpectedResultAndActualOutput(5, result, "test 10 - 5");
    }

    public void TestMultiplication()
    {
        double result =_calculator.Calculate(5, 2, BasicOperators.Multiplication);
        ExpectedResultAndActualOutput(10, result, "test 5 * 2");
    }

    public void TestDivision()
    {
        double result = _calculator.Calculate(10, 2, BasicOperators.Division);
        ExpectedResultAndActualOutput(5, result, "test 10 / 2");
    }

    public void TestDivisionByZero()
    {
        string testName = "Test division by zero (Exception Expected)";

        try
        {
            double result = _calculator.Calculate(10, 0, BasicOperators.Division);
            Console.WriteLine($"[FAILED] {testName}: Expected DivideByZeroException, but no exception was thrown.");
            _failed++;
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine($"[PASSED] {testName}: Caught expected exception.");
            _passed++;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"[FAILED] {testName}: Caught unexpected exception.");
            _failed++;
        }
    }   
}