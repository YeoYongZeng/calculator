using Calculator;

try
{
    Console.WriteLine("Hello, World!");
    string input = "1.1+(2.1)+1^0.5+2^2+2.2";
    var checker = new StringChecker();

    var tokenSuite = new TokenizeSuite();
    var tokens = tokenSuite.Tokenize(input);
    if(tokenSuite.ErrorMsg.Count > 0)
    {
        foreach (var errorMsg in tokenSuite.ErrorMsg)
        {
            Console.WriteLine($"{errorMsg}");
        }
    }


    foreach (var token in tokens)
    {
        Console.WriteLine($"{token.Data} {token.Type}");
    }

    Console.WriteLine("end.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
}