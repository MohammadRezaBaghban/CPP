﻿using System;
using System.Collections.Generic;
using CPP.Functions;
using CPP.Operations;
using CPP.Tree__Visitable___Composite_Component_.Functions;
using CPP.Visitable.Node;

namespace CPP
{
    class FormulaParse
    {
        private List<string> inputs;
        BinaryTree bt;

        public FormulaParse()
        {
            inputs = new List<string>();
            bt = new BinaryTree();
        }

        public BinaryTree BinaryTree
        {
            get => default;
            set
            {
            }
        }

        public List<string> GetParsedList() => inputs;
        static bool InputIsOperand(char character)
        {
            // If the ASCII code of the character wihtin a digit range, then it would be an an operand 
            return ((character >= 48 && character <= 57) ||
                    character == 'p' || character == 'x'
                    || character == 'P' || character == 'X');
        }
        public void EraseParsedList()
        {
            inputs.Clear();
            bt._root = null;
        }
        public string ParseInputRecursively(ref string expression)
        {
            if (expression == null || expression == "")
            {
                return null;
            }
            else
            {
                if (expression[0] == ' ' || expression[0] == ',' || expression[0] == ')')
                {
                    EatMethod(ref expression);
                    return ParseInputRecursively(ref expression);
                }

                if (InputIsOperand(expression[0]))
                {
                    inputs.Add(expression[0].ToString());
                    EatMethod(ref expression);
                    return ParseInputRecursively(ref expression);
                }
                else
                {
                    switch (expression[0])
                    {

                        case 'r':
                        case 'n':

                            inputs.Add(expression[0].ToString());
                            expression = EatMethod(ref expression);
                            expression = EatMethod(ref expression);
                            string value = expression.Substring(0, expression.IndexOf(')'));
                            inputs.Add(value);
                            expression = expression.Remove(0, value.Length + 1);
                            return ParseInputRecursively(ref expression);
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '^':
                            inputs.Add(expression[0].ToString());
                            expression = EatMethod(ref expression);
                            expression = EatMethod(ref expression);
                            string a1 = EatMethod(expression, ')');
                            expression = expression.Remove(0, a1.Length);
                            ParseInputRecursively(ref a1);
                            string a2 = EatMethod(expression, ')');
                            expression = expression.Remove(0, a2.Length);
                            ParseInputRecursively(ref a2);
                            return ParseInputRecursively(ref expression);
                        case 's':
                        case 't':
                        case 'c':
                        case 'l':
                        case '!':
                        case 'e':
                            inputs.Add(expression[0].ToString());
                            expression = EatMethod(ref expression);
                            expression = EatMethod(ref expression);
                            return ParseInputRecursively(ref expression);
                        default:
                            return null;
                    }
                }
            }
        }

        public double status(string input)
        {
            switch (input)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                    return 2;
                case "s":
                case "t":
                case "c":
                case "l":
                case "e":
                case "!":
                    return 1;
                default:
                    return 0;
            }
        }

        private string EatMethod(ref string input)
        {
            if (input != null)
            {
                input = input.Remove(0, 1);
                return input;

            }
            else
            {
                return null;
            }
        }

        private string EatMethod(string input, char till)
        {
            if (input.Length != null)
            {

                return input.Substring(0, input.IndexOf(till) + 1);
            }
            else
            {
                return null;
            }
        }

        public CompositeNode Convert_ParsedList_To_BinaryTree(List<string> input)
        {
            CompositeNode root = bt._root;
            for (int i = 0; i <= input.Count - 1; i++)
            {
                switch (input[i])
                {
                   

                    //Operators
                    case "+":
                        root = bt.InsertCompositeNode(root, new AddOperator());
                        break;
                    case "-":
                        root = bt.InsertCompositeNode(root, new SubstracOperator());
                        break;
                    case "*":
                        root = bt.InsertCompositeNode(root, new MultipicationOperator());
                        break;
                    case "/":
                        root = bt.InsertCompositeNode(root, new DivisionOperator());
                        break;
                    case "^":
                        root = bt.InsertCompositeNode(root, new PowerOperator());
                        break;
                        

                    //Functions
                    case "s":
                    case "S":
                        root = bt.InsertCompositeNode(root, new SinFunc());
                        break;
                    case "c":
                    case "C":
                        root = bt.InsertCompositeNode(root, new CosFunc());
                        break;
                    case "e":
                    case "E":
                        root = bt.InsertCompositeNode(root, new ExponentialFun());
                        break;
                    case "L":
                    case "l":
                        root = bt.InsertCompositeNode(root, new LogarithmFunc());
                        break;
                    case "!":
                        root = bt.InsertCompositeNode(root, new FactorialFunc());
                        break;
                    
                    //Variables                    
                    case "X":
                    case "x":
                        bt.InsertSingleNode(root, new SingleNode(root));
                        break;

                    // Values
                    case "p":
                    case "P":
                        bt.InsertSingleNode(root, new SingleNode(root, 3.14));
                        break;

                    //Real and Natural Numbers
                    case "r":
                    case "n":
                        root = bt.InsertSingleNode(root, new SingleNode(root, Convert.ToDouble(input[++i])));
                        break;

                    default:
                        bt.InsertSingleNode(root, new SingleNode(root, Convert.ToDouble(input[i])));
                        break;
                }

            }
            return bt._root;

        }



    }
}
