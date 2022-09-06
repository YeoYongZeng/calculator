using System;
using System.Runtime.ConstrainedExecution;

namespace Calculator
{
    public struct Token
    {
        public string ErrorMsg { get; set; }
        public double DataF { get; set; } 
        public string Data { get; set; }
        public TokenType Type { get; set; }

        public Token(string data, TokenType type)
        {
            this.ErrorMsg = string.Empty;
            this.DataF = 0;
            this.Data = data;
            this.Type = type;
        }

        public Token(string errorMsg)
        {
            this.ErrorMsg = errorMsg;
            this.Type = TokenType.error;
            this.DataF = 0;
            this.Data = string.Empty;
        }

        public Token(string data, double dataF)
        {
            this.ErrorMsg = string.Empty;
            this.DataF = dataF;
            this.Data = data;
            this.Type = TokenType.num;
        }

        public bool IsOperand()
        {
            if (Type == TokenType.num)
                return true;
            return false;
        }

        public bool IsOperator()
        {
            if (Type != TokenType.num && Type != TokenType.eos && Type != TokenType.error)
                return true;
            return false;
        }
    }

    public class TokenizeSuite
    {
        public List<string> ErrorMsg { get; set; } = new List<string>();

        private Token OperatorTokenize(char chr)
            => chr switch
            {
                '+' => new Token("+", TokenType.add),
                '-' => new Token("-", TokenType.sub),
                '*' => new Token("*", TokenType.mul),
                '/' => new Token("/", TokenType.div),
                '^' => new Token("^", TokenType.pow),
                '(' => new Token("(", TokenType.leftParam),
                ')' => new Token(")", TokenType.rightParam),
                _ => new Token($"Unknown char: {chr}"),
            };
            
        private bool CheckIsValidNum(string input)
        {
            bool hasDot = false;
            foreach (char chr in input.ToCharArray())
            {
                if (chr == '.' && hasDot == false)
                {
                    hasDot = true;
                    continue;
                }
                if (chr >= '0' && chr <= '9') continue;

                return false;
            }
            return true;
        }

        private Token OperandTokenize(string input)
        {
            if (CheckIsValidNum(input) == false)
            {
                this.ErrorMsg.Add($"Invalid number {input}");
                return new Token($"Invalid number {input}");
            }

            if (double.TryParse(input, out var val) == false)
            {
                this.ErrorMsg.Add($"Unable convert to double {input}");
                return new Token($"Unable convert to double {input}");
            }
            return new Token(input, val);
        }

        private List<Token> RetrieveAllToken(string inputStr)
        { 
            List<Token> tokens = new List<Token>();

            string num = string.Empty;
            foreach (char chr in inputStr.ToCharArray())
            {
                var operatorToken = OperatorTokenize(chr);
                if (operatorToken.IsOperator() == false)
                {
                    num = num + chr;
                    continue;
                }

                if(string.IsNullOrWhiteSpace(num))
                {
                    tokens.Add(operatorToken);
                    num = string.Empty;
                    continue;
                }

                var operandToken = OperandTokenize(num);
                if (operandToken.IsOperand() == false)
                    return new List<Token>();

                tokens.Add(operandToken);
                tokens.Add(operatorToken);
                num = string.Empty;
            }

            if (string.IsNullOrEmpty(num))
                return tokens;

            var lastOperandToken = OperandTokenize(num);
            if (lastOperandToken.IsOperand() == false)
                return new List<Token>();

            tokens.Add(lastOperandToken);
            return tokens;
        }

        public List<Token> Tokenize(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return new List<Token>();

            var tokens = RetrieveAllToken(inputStr);
            if (tokens.Count < 1)
                return new List<Token>();

            tokens.Add(new Token(string.Empty, TokenType.eos));
            return tokens;
        }
    }
}

