using CPP.Operations;
using CPP.Functions;
using CPP.Visitable.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Visitor
{
    class Polynomial_Calculator
    {
        BinaryTree binaryTree;
        Calculator calc;
        public Polynomial_Calculator(BinaryTree bt, Calculator ct) => (binaryTree,calc) = (bt,ct);

        public Dictionary<Decimal, Decimal> ParseSelectedCoordiantes(string input)
        {
            Dictionary<Decimal, Decimal> selectedCoordinates = new Dictionary<Decimal, Decimal>();
            var coordinates = input.Split(';');
            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                var xy = coordinates[i].Split(',');
                selectedCoordinates.Add(Convert.ToDecimal(xy[0]), Convert.ToDecimal(xy[1]));
            }
            return selectedCoordinates;
        }

        public Decimal[,] GenerateAugmentedMatrix(Dictionary<Decimal, Decimal> selectedCoordinates)
        {
            Decimal[,] augmentedMatrix = new Decimal[selectedCoordinates.Count, selectedCoordinates.Count + 1];
            var Xs = selectedCoordinates.Keys.ToArray();
            var Ys = selectedCoordinates.Values.ToArray();
            for (int i = 0; i < augmentedMatrix.GetLength(0); i++)
            {
                var degreeOfTerm = augmentedMatrix.GetLength(1) - 2;
                for (int j = 0; j < augmentedMatrix.GetLength(1); j++)
                {
                    augmentedMatrix[i, j] = Convert.ToDecimal(Math.Pow(Convert.ToDouble(Xs[i]), degreeOfTerm--));
                }
                augmentedMatrix[i, selectedCoordinates.Count] = Ys[i];
            }
            return augmentedMatrix;
        }

        public List<Decimal> GaussianElimination(Decimal[,] augmentedMatrix, int orderofMatrix)
        {
            int counter_i, counter_j;
            int k = 0, c;

            // Performing elementary operations - For each Row of Augmented Matrix
            for (counter_i = 0; counter_i < orderofMatrix; counter_i++)
            {
                if (augmentedMatrix[counter_i, counter_i] == 0)
                {
                    c = 1;
                    while (augmentedMatrix[counter_i + c, counter_i] == 0 && (counter_i + c) < orderofMatrix)
                        c++;
                    if ((counter_i + c) == orderofMatrix)
                    {
                        break;
                    }
                    for (counter_j = counter_i, k = 0; k <= orderofMatrix; k++)
                    {
                        Decimal temp = augmentedMatrix[counter_j, k];
                        augmentedMatrix[counter_j, k] = augmentedMatrix[counter_j + c, k];
                        augmentedMatrix[counter_j + c, k] = temp;
                    }
                }

                for (counter_j = 0; counter_j < orderofMatrix; counter_j++)
                {

                    // Excluding all i == j 
                    if (counter_i != counter_j)
                    {

                        // Converting Matrix to reduced row 
                        // echelon form(diagonal matrix) 
                        Decimal p = augmentedMatrix[counter_j, counter_i] / augmentedMatrix[counter_i, counter_i];

                        for (k = 0; k <= orderofMatrix; k++)
                            augmentedMatrix[counter_j, k] = augmentedMatrix[counter_j, k] - (augmentedMatrix[counter_i, k]) * p;
                    }
                }
            }

            var solutionList = new List<Decimal>();
            for (int y = 0; y < augmentedMatrix.GetLength(0); y++)
            {
                augmentedMatrix[y, augmentedMatrix.GetLength(1) - 1] /= augmentedMatrix[y, y];
                solutionList.Add(augmentedMatrix[y, augmentedMatrix.GetLength(1) - 1]);
            }

            return solutionList;
        }

        public List<CompositeNode> GeneratePolynomialFunction(List<decimal> coefficients)
        {
            coefficients.Reverse();
            var polynomialTerms = new List<CompositeNode>();
            for(int i =0;i< coefficients.Count; i++)
            {
                var power = new PowerOperator();
                binaryTree.InsertNode(power, new SingleNode(power));
                binaryTree.InsertNode(power, new SingleNode(power, i));

                var multiplication = new MultiplicationOperator();
                binaryTree.InsertNode(multiplication, new SingleNode(multiplication, coefficients[i]));
                binaryTree.InsertNode(multiplication, power);

                polynomialTerms.Add(multiplication);
            }

            polynomialTerms.Reverse();
            return polynomialTerms;
        }

        public Dictionary<decimal, decimal> CalculatePolynomialfunction(List<CompositeNode> terms)
        {
            List<Dictionary<decimal, decimal>> value = new List<Dictionary<decimal, decimal>>();
            foreach(var t in terms)
            {
                value.Add(calc.Calculate(t, 1100));
            }

            Dictionary<decimal, decimal> finalValue = new Dictionary<decimal, decimal>();
            foreach(var x in value[0].Keys.ToArray())
            {
                decimal d = 0;
                for (int i=0;i< value.Count; i++)
                {
                    d += value[i][x];
                }
                finalValue.Add(x, d);
            }
            return finalValue;
        }

        public string StandardPolynomialFormula(List<decimal> terms)
        {
            string formula = "";
            var degree = terms.Count-1;
            for(int i=0;i< terms.Count; i++)
            {
                if (i!= terms.Count-1)
                {
                    formula += $"{terms[i]}X{SuperscriptNumbers(degree--)} + ";

                }
                else
                {
                    formula += $"{terms[i]}";
                }
            }
            return formula;
        }

        private string SuperscriptNumbers(int input)
        {
            switch (input)
            {
                case 0:
                    return @"º";
                case 1:
                    return @"¹";
                case 2:
                    return @"²";
                case 3:
                    return @"³";
                case 4:
                    return @"⁴";
                case 5:
                    return @"⁵";
                case 6:
                    return @"⁶";
                case 7:
                    return @"⁷";
                case 8:
                    return @"⁸";
                case 9:
                    return @"⁹";
                default:
                    return $"^{input.ToString()}";
            }
        }
    }
}
