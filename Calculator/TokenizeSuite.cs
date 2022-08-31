using System;
using System.Runtime.ConstrainedExecution;

namespace Calculator
{
    public struct Token
    {
        public string Data { get; set; }
        public TokenType Type { get; set; }

        public Token(string data, TokenType type)
        {
            this.Data = data;
            this.Type = type;
        }

        public bool IsOperand()
        {
            if (Type == TokenType.num)
                return true;
            return false;
        }

        public bool IsOperator()
        {
            if (Type != TokenType.num && Type != TokenType.eos)
                return true;
            return false;
        }
    }

    public class TokenizeSuite
    {
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
                _ => new Token(string.Empty, TokenType.error),
            };

            
        public bool CheckIsValidNum(string input)
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
                return new Token(string.Empty, TokenType.error);

            return new Token(input, TokenType.num);
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

                tokens.Add(operatorToken);

                var operandToken = OperandTokenize(num);
                if (operandToken.IsOperand() == false)
                    return new List<Token>();

                num = string.Empty;
            }

            if (string.IsNullOrEmpty(num) == false)
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

