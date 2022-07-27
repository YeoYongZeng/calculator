using System;
namespace Calculator
{
    public class StringChecker
    {
        public bool Checker_IfOneByOne(string input)
        {
            foreach(char chr in input.ToCharArray())
            {
                if (chr == '+') continue;
                if (chr == '-') continue;
                if (chr == '*') continue;
                if (chr == '/') continue;
                if (chr == '^') continue;
                if (chr == '(') continue;
                if (chr == ')') continue;
                if (chr >= '0' && chr <= '9') continue;

                return false;
            }
            return true;
        }

        public bool Checker_Substring(string input)
        {
            for(int i=0; i< input.Length; i++)
            {
                string temp = input.Substring(i, 1);
                if (temp == "+") continue;
                if (temp == "-") continue;
                if (temp == "*") continue;
                if (temp == "/") continue;
                if (temp == "^") continue;
                if (temp == "(") continue;
                if (temp == ")") continue;
                if (temp == "0") continue;
                if (temp == "1") continue;
                if (temp == "2") continue;
                if (temp == "3") continue;
                if (temp == "4") continue;
                if (temp == "5") continue;
                if (temp == "6") continue;
                if (temp == "7") continue;
                if (temp == "8") continue;
                if (temp == "9") continue;
                return false;
            }
            return true;
        }

        public bool Checker_Contains(string input)
        {
            string template = "1234567890/*+-^()";
            foreach (char chr in input.ToCharArray())
            {
                if (template.Contains(chr))
                    continue;
                return false;
            }
            return true;
        }
    }
}

