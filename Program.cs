// DONE: Level 0
// DONE: Level 1
// DONE: Level 2


System.Console.Write("Enter a formula: ");
string formula = Console.ReadLine()!;
// We ask the user for the formula and let the user enter a formula
System.Console.WriteLine($"the result is {CalculateFormula(formula)}");
// In our example "-20 + 30" the output must be "the result is 10"

int indexOfOperator = 0;
int CalculateFormula(string formula)
{
    int result = 0;
    // first operator is set + because the first number is expected to be positive
    char op = '+';
    formula = formula.Replace(" ", "");
    // replaces empty spaces with nothing
    if (formula == "")
    {
        return 0;
        // returns 0 if random key is clicked
    }
    if (formula[0] == '-' || formula[0] == '+')
    {
        op = formula[0];
        formula = formula.Substring(1);
        // checks if if the first operator is minus or plus (if first number negative or positive)
        // if it is the operator is set to that first operator and the formula is shortened without the first operator
        // example: "-20 + 30"
        // formula now: "20+30"
    }
    do
    {
        indexOfOperator = FindIndexOfNextOperator(formula);
        // after the minus in our example is removed we find the next operator and save it in a  variable
        if (indexOfOperator == -1)
        {
            result = ReturnResult(op, result, formula);
            // if the index of the operator is -1 it means that we reached the end and there are no more operators
            // we save what we returned in a variable
            // this is the final step, so we must use the formula variable because there are no operators in it anyway
        }
        else
        {
            string leftnumber = formula.Substring(0, indexOfOperator);
            // we need the left number of the formula which is always the number that starts at 0 (after we cut the formula) and goes until the index of the next operator
            result = ReturnResult(op, result, leftnumber);
            // exact same function as previously used method, instead of formula we use left number because we arent finished with the steps yet and we still have other operators in our formula that must be removed (done in the step before)
            op = formula[indexOfOperator];
            // Finds the operator of our currently used operators index
            // If our current index of operator is 0 in the example "20+30" (used to be -20+30) the variable op is '+'
            formula = formula.Substring(indexOfOperator + 1);
            // Finally the formula is "cut" at our last used operators index
            // so in the example "20+30", our operator is '+' as said before and will be "cut" at + therefore
            // after its "cut" the new formula is "30"
        }
    }
    while (indexOfOperator != -1);
    // loop goes while the index isnt -1
    // as soon as it turns -1 and the loop is completed one more time, it will stop
    // when indexofoperator is -1 it means that there are no more operators left and therefore there must be an end result

    return result;
    // returns final result
    // Yay!
}

int FindIndexOfNextOperator(string formula)
{
    int plus = formula.IndexOf('+');
    int minus = formula.IndexOf('-');
    // It takes the index of the closest minus and plus operator
    if (plus == -1)
    {
        return minus;
        // If there are no plus operators in the formula at all, it can only return minus operators
    }
    if (minus == -1)
    {
        return plus;
        // If there are no minus operators in the formula at all, it can only return plus operators
    }
    return Math.Min(minus, plus);
    // If both cases arent included, it must mean that minus AND plus has an index in the formula 
    // example: 6 + 7 - 5
    // Therefore the one with the smallest index of the two is returned
}

int ReturnResult(char op, int result, string numberasstring)
{
    int number = int.Parse(numberasstring);
    // we define a new int help variable that turns our input string parameter in an interger so we can add and subtract it from the result later one
    if (op == '+')
    {
        result += number;
        // if the operator is plus we must add the number to the result
    }
    else
    {
        result -= number;
        // else the operator can only be minus and the number must be subtracted from the result
    }

    return result;
    // result is returned
}