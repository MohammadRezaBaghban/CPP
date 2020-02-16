using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Tree__Visitable___Composite_Component_.Functions;
using CPP.Visitable.Node;

namespace CPP.Visitor
{
    class Derivative : IVisitor
    {

        BinaryTree binaryTree;
        Calculator calc;
        public int numberOfSeries = 10;

        public Derivative(BinaryTree bt, Calculator cl) => (binaryTree, calc) = (bt, cl);

        public void Calculate(Component visitable)
        {
            SingleNode single = visitable as SingleNode;
            //single = (SingleNode)visitable.Clone();
            if (single != null)
            {
                if (single.IsVariable)
                {

                    single.Derivation = new SingleNode(null, 1);
                }
                else
                {
                    single.Derivation = new SingleNode(null, 0);
                }
            }
            else
            {
                CompositeNode compositeNode = visitable as CompositeNode;
                if (compositeNode is Function)
                {
                    Calculate(compositeNode.LeftNode);
                    compositeNode.Evaluate(this);
                }
                else
                {
                    Calculate(compositeNode.LeftNode);
                    Calculate(compositeNode.RightNode);
                    visitable.Evaluate(this);
                }
            }
        }

        public List<Component> MaclaurinSeries(Component visitable)
        {
            
            Component[] derivations = new Component[numberOfSeries-1];
            Component[] MaclurinDegrees = new Component[numberOfSeries];

            calc.coordinateValue = 0;
            //Degree 0
            calc.Calculate(visitable);
            var degree0 = new SingleNode(null, visitable.Data);
            MaclurinDegrees[0] = degree0;

            //Degree 1
            Calculate(visitable);
            BinaryTree.Simplify(ref visitable.Derivation, ref visitable.Derivation.Parent);
            BinaryTree.Simplify(ref visitable.Derivation, ref visitable.Derivation.Parent);

            calc.Calculate(visitable.Derivation);
            var f1 = visitable.Derivation;
            var _1stDerivation = new SingleNode(null, visitable.Derivation.Data);

            var multiply1 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply1, _1stDerivation);
            binaryTree.InsertNode(multiply1, new SingleNode(multiply1));

            var degree1 = new AddOperator();
            binaryTree.InsertNode(degree1, MaclurinDegrees[0]);
            binaryTree.InsertNode(degree1, multiply1);

            derivations[0] = f1;
            MaclurinDegrees[1] = degree1;

            for (int i = 0; i < numberOfSeries-2; i++)
            {
                var derivation = derivations[i];
                Calculate(derivation);

                var newDerivation = derivation.Derivation;
                BinaryTree.Simplify(ref newDerivation, ref newDerivation.Parent);
                BinaryTree.Simplify(ref newDerivation, ref newDerivation.Parent);

                calc.Calculate(newDerivation);
                var _2ndDerivation = new SingleNode(null, newDerivation.Data);

                var powerOperator = new PowerOperator();
                binaryTree.InsertNode(powerOperator, new SingleNode(powerOperator));
                binaryTree.InsertNode(powerOperator, new SingleNode(powerOperator, 2));

                var multiplyOperator = new MultiplicationOperator();
                binaryTree.InsertNode(multiplyOperator, _2ndDerivation);
                binaryTree.InsertNode(multiplyOperator, powerOperator);

                var factorialOperator = new FactorialFunc();
                binaryTree.InsertNode(factorialOperator, new SingleNode(factorialOperator, 2));

                var divisonOperator = new DivisionOperator();
                binaryTree.InsertNode(divisonOperator, multiplyOperator);
                binaryTree.InsertNode(divisonOperator, factorialOperator);

                var newDegree = new AddOperator();
                binaryTree.InsertNode(newDegree, MaclurinDegrees[i+1]);
                binaryTree.InsertNode(newDegree, divisonOperator);

                derivations[i+1] = newDerivation;
                MaclurinDegrees[i+2] = newDegree;
            }

            var listOfMaclurinDegrees = new List<Component>();

            foreach (var degree in MaclurinDegrees)
            {
                listOfMaclurinDegrees.Add(degree);
            }
            return listOfMaclurinDegrees;
        }
        public void Visit(AddOperator visitable)
        {
            var derivation = new AddOperator();

            Calculate(visitable.LeftNode);
            Calculate(visitable.RightNode);

            binaryTree.InsertNode(derivation, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(derivation, visitable.RightNode.Derivation);

            visitable.Derivation = derivation;
        }

        public void Visit(SubstractOperator visitable)
        {
            CompositeNode derivation = new SubstractOperator();

            Calculate(visitable.LeftNode);
            Calculate(visitable.RightNode);

            binaryTree.InsertNode(derivation, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(derivation, visitable.RightNode.Derivation);

            visitable.Derivation = derivation;
        }

        public void Visit(MultiplicationOperator visitable)
        {

            Calculate(visitable.LeftNode);
            Calculate(visitable.RightNode);

            var multiply1 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply1, visitable.LeftNode);
            binaryTree.InsertNode(multiply1, visitable.RightNode.Derivation);

            var multiply2 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply2, visitable.RightNode);
            binaryTree.InsertNode(multiply2, visitable.LeftNode.Derivation);

            var derivation = new AddOperator();
            binaryTree.InsertNode(derivation, multiply1);
            binaryTree.InsertNode(derivation, multiply2);

            visitable.Derivation = derivation;
        }

        public void Visit(DivisionOperator visitable)
        {
            Calculate(visitable.LeftNode);
            Calculate(visitable.RightNode);


            var multiply1 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply1, visitable.LeftNode);
            binaryTree.InsertNode(multiply1, visitable.RightNode.Derivation);

            var multiply2 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply2, visitable.RightNode);
            binaryTree.InsertNode(multiply2, visitable.LeftNode.Derivation);

            var numerator = new SubstractOperator();
            binaryTree.InsertNode(numerator, multiply1);
            binaryTree.InsertNode(numerator, multiply2);

            var denominator = new PowerOperator();
            binaryTree.InsertNode(denominator, visitable.RightNode);
            binaryTree.InsertNode(denominator, new SingleNode(denominator, 2));

            var derivation = new DivisionOperator();
            binaryTree.InsertNode(derivation, numerator);
            binaryTree.InsertNode(derivation, denominator);

            visitable.Derivation = derivation;

        }

        public void Visit(PowerOperator visitable)
        {
            Calculate(visitable.LeftNode);
            Calculate(visitable.RightNode);


            var substraction = new SubstractOperator();
            binaryTree.InsertNode(substraction, visitable.RightNode);
            binaryTree.InsertNode(substraction, new SingleNode(substraction, 1));


            var power = new PowerOperator();
            binaryTree.InsertNode(power, visitable.LeftNode);
            binaryTree.InsertNode(power, substraction);

            var multiply1 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply1, visitable.RightNode);
            binaryTree.InsertNode(multiply1, power);

            var multiply2 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply2, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(multiply2, multiply1);

            visitable.Derivation = multiply2;
        }

        public void Visit(FactorialFunc visitable)
        {
            visitable.Derivation = new SingleNode(null, 0);
        }

        public void Visit(ExponentialFun visitable)
        {
            Calculate(visitable.LeftNode);

            var multiply1 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply1, visitable);
            binaryTree.InsertNode(multiply1, visitable.LeftNode.Derivation);

            visitable.Derivation = multiply1;
        }

        public void Visit(LogarithmFunc visitable)
        {
            Calculate(visitable.LeftNode);

            var division = new DivisionOperator();
            binaryTree.InsertNode(division, new SingleNode(division, 1));
            binaryTree.InsertNode(division, visitable.LeftNode);

            var multiple = new MultiplicationOperator();
            binaryTree.InsertNode(multiple, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(multiple, division);

            visitable.Derivation = multiple;
        }

        public void Visit(SinFunc visitable)
        {
            CompositeNode derivation = new MultiplicationOperator();

            CompositeNode cos = new CosFunc();
            binaryTree.InsertNode(cos, visitable.LeftNode);
            binaryTree.InsertNode(derivation, cos);

            Calculate(visitable.LeftNode);
            binaryTree.InsertNode(derivation, visitable.LeftNode.Derivation);

            visitable.Derivation = derivation;

        }

        public void Visit(CosFunc visitable)
        {
            Calculate(visitable.LeftNode);

            CompositeNode sin = new SinFunc();
            binaryTree.InsertNode(sin, visitable.LeftNode);

            CompositeNode multiplicationNode2 = new MultiplicationOperator();
            binaryTree.InsertNode(multiplicationNode2, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(multiplicationNode2, new SingleNode(multiplicationNode2, -1));

            CompositeNode derivation = new MultiplicationOperator();
            binaryTree.InsertNode(derivation, sin);
            binaryTree.InsertNode(derivation, multiplicationNode2);

            visitable.Derivation = derivation;
        }

        public void Visit(TanFunc visitable)
        {
            Calculate(visitable.LeftNode);

            var cos = new CosFunc();
            binaryTree.InsertNode(cos, visitable.LeftNode);

            var power = new PowerOperator();
            binaryTree.InsertNode(power, cos);
            binaryTree.InsertNode(power, new SingleNode(null, 2));

            var division = new DivisionOperator();
            binaryTree.InsertNode(division, new SingleNode(division, 1));
            binaryTree.InsertNode(division, power);

            var multiple = new MultiplicationOperator();
            binaryTree.InsertNode(multiple, visitable.LeftNode.Derivation);
            binaryTree.InsertNode(multiple, division);


            visitable.Derivation = multiple;
        }

    }
}
