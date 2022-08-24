using Calculator;

Console.WriteLine("Hello, World!");
string input = "1+(2.1)+1^0.5+2^2+2";
var checker = new StringChecker();
var isGood = checker.Checker_IfOneByOne(input);

if(isGood)
    Console.WriteLine("The input string contains unhandle chars");