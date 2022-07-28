// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string input = "1+(2.1)+1^0.5+2^2+2-*/";
char[] inputStrToArray = input.ToCharArray();

foreach(char tempChar in inputStrToArray)
{
    bool isOk = false;
    //Console.WriteLine($"in foreach {tempChar}");
    if (tempChar == '+')
    {
        isOk = true;
        continue;
    }
    if (tempChar == '-')
    {
        isOk = true;
        continue;
    }

    if (tempChar >= '0' && tempChar <= '9')
    {
        isOk = true;
        continue;
    }
}
Console.WriteLine("Hello, World!");