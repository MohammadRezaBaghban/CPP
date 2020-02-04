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
        public Derivative(BinaryTree bt, Calculator cl)
        {
            binaryTree = bt;
            calc = cl;
        }

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
            calc.coordinateValue = 0;
            //Degree 0
            calc.Calculate(visitable);
            var degree0 = new SingleNode(null, visitable.Data);

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
            binaryTree.InsertNode(degree1, degree0);
            binaryTree.InsertNode(degree1, multiply1);

            //Degree 2
            Calculate(f1);
            var f2 = f1.Derivation;
            BinaryTree.Simplify(ref f2, ref f2.Parent);
            BinaryTree.Simplify(ref f2, ref f2.Parent);

            calc.Calculate(f2);
            var _2ndDerivation = new SingleNode(null, f2.Data);

            var power2 = new PowerOperator();
            binaryTree.InsertNode(power2, new SingleNode(power2));
            binaryTree.InsertNode(power2, new SingleNode(power2,2));

            var multiply2 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply2, _2ndDerivation);
            binaryTree.InsertNode(multiply2, power2);

            var factorial2 = new FactorialFunc();
            binaryTree.InsertNode(factorial2, new SingleNode(factorial2,2));


            var divison2 = new DivisionOperator();
            binaryTree.InsertNode(divison2, multiply2);
            binaryTree.InsertNode(divison2, factorial2);

            var degree2 = new AddOperator();
            binaryTree.InsertNode(degree2, degree1);
            binaryTree.InsertNode(degree2, divison2);

            //Degree 3
            Calculate(f2);
            var f3 = f2.Derivation;

            BinaryTree.Simplify(ref f3, ref f3.Parent);
            BinaryTree.Simplify(ref f3, ref f3.Parent);
            
            calc.Calculate(f3);
            var _3rdDerivation = new SingleNode(null, f3.Data);

            var power3 = new PowerOperator();
            binaryTree.InsertNode(power3, new SingleNode(power3));
            binaryTree.InsertNode(power3, new SingleNode(power3, 3));

            var multiply3 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply3, _3rdDerivation);
            binaryTree.InsertNode(multiply3, power3);

            var factorial3 = new FactorialFunc();
            binaryTree.InsertNode(factorial3, new SingleNode(factorial3,3));

            var divison3 = new DivisionOperator();
            binaryTree.InsertNode(divison3, multiply3);
            binaryTree.InsertNode(divison3, factorial3);

            var degree3 = new AddOperator();
            binaryTree.InsertNode(degree3, degree2);
            binaryTree.InsertNode(degree3, divison3);

            //Degree 4
            Calculate(f3); 
            var f4 = f3.Derivation;

            BinaryTree.Simplify(ref f4, ref f4.Parent);
            BinaryTree.Simplify(ref f4, ref f4.Parent);

            calc.Calculate(f4);
            var _4thDerivation = new SingleNode(null, f4.Data);

            var power4 = new PowerOperator();
            binaryTree.InsertNode(power4, new SingleNode(power4));
            binaryTree.InsertNode(power4, new SingleNode(power4, 4));

            var multiply4 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply4, _4thDerivation);
            binaryTree.InsertNode(multiply4, power4);

            var factorial4= new FactorialFunc();
            binaryTree.InsertNode(factorial4, new SingleNode(factorial4, 4));

            var divison4 = new DivisionOperator();
            binaryTree.InsertNode(divison4, multiply4);
            binaryTree.InsertNode(divison4, factorial4);

            var degree4 = new AddOperator();
            binaryTree.InsertNode(degree4, degree3);
            binaryTree.InsertNode(degree4, divison4);

            //Degree 5
            Calculate(f4);
            var f5 = f4.Derivation;

            BinaryTree.Simplify(ref f5, ref f5.Parent);
            BinaryTree.Simplify(ref f5, ref f5.Parent);

            calc.Calculate(f5);
            var _5thDerivation = new SingleNode(null, f5.Data);

            var power5 = new PowerOperator();
            binaryTree.InsertNode(power5, new SingleNode(power5));
            binaryTree.InsertNode(power5, new SingleNode(power5, 5));

            var multiply5 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply5, _5thDerivation);
            binaryTree.InsertNode(multiply5, power5);

            var factorial5 = new FactorialFunc();
            binaryTree.InsertNode(factorial5, new SingleNode(factorial5, 5));

            var divison5 = new DivisionOperator();
            binaryTree.InsertNode(divison5, multiply5);
            binaryTree.InsertNode(divison5, factorial5);

            var degree5 = new AddOperator();
            binaryTree.InsertNode(degree5, degree4);
            binaryTree.InsertNode(degree5, divison5);

            //Degree 6
            Calculate(f5);
            var f6 = f5.Derivation;

            BinaryTree.Simplify(ref f6, ref f6.Parent);
            BinaryTree.Simplify(ref f6, ref f6.Parent);

            calc.Calculate(f6);
            var _6thDerivation = new SingleNode(null, f6.Data);

            var power6 = new PowerOperator();
            binaryTree.InsertNode(power6, new SingleNode(power6));
            binaryTree.InsertNode(power6, new SingleNode(power6, 6));

            var multiply6 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply6, _6thDerivation);
            binaryTree.InsertNode(multiply6, power6);

            var factorial6 = new FactorialFunc();
            binaryTree.InsertNode(factorial6, new SingleNode(factorial6, 6));

            var divison6 = new DivisionOperator();
            binaryTree.InsertNode(divison6, multiply6);
            binaryTree.InsertNode(divison6, factorial6);

            var degree6 = new AddOperator();
            binaryTree.InsertNode(degree6, degree5);
            binaryTree.InsertNode(degree6, divison6);

            //Degree 7
            Calculate(f6);
            var f7 = f6.Derivation;

            BinaryTree.Simplify(ref f7, ref f7.Parent);
            BinaryTree.Simplify(ref f7, ref f7.Parent);

            calc.Calculate(f7);
            var _7thDerivation = new SingleNode(null, f7.Data);

            var power7 = new PowerOperator();
            binaryTree.InsertNode(power7, new SingleNode(power7));
            binaryTree.InsertNode(power7, new SingleNode(power7, 7));

            var multiply7 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply7, _7thDerivation);
            binaryTree.InsertNode(multiply7, power7);

            var factorial7 = new FactorialFunc();
            binaryTree.InsertNode(factorial7, new SingleNode(factorial7, 7));

            var divison7 = new DivisionOperator();
            binaryTree.InsertNode(divison7, multiply7);
            binaryTree.InsertNode(divison7, factorial7);

            var degree7 = new AddOperator();
            binaryTree.InsertNode(degree7, degree6);
            binaryTree.InsertNode(degree7, divison7);

            //Degree 8
            Calculate(f7);
            var f8 = f7.Derivation;

            BinaryTree.Simplify(ref f8, ref f8.Parent);
            BinaryTree.Simplify(ref f8, ref f8.Parent);

            calc.Calculate(f8);
            var _8thDerivation = new SingleNode(null, f8.Data);

            var power8 = new PowerOperator();
            binaryTree.InsertNode(power8, new SingleNode(power8));
            binaryTree.InsertNode(power8, new SingleNode(power8, 8));

            var multiply8 = new MultiplicationOperator();
            binaryTree.InsertNode(multiply8, _8thDerivation);
            binaryTree.InsertNode(multiply8, power8);

            var factorial8 = new FactorialFunc();
            binaryTree.InsertNode(factorial8, new SingleNode(factorial8, 7));

            var divison8 = new DivisionOperator();
            binaryTree.InsertNode(divison8, multiply8);
            binaryTree.InsertNode(divison8, factorial8);

            var degree8 = new AddOperator();
            binaryTree.InsertNode(degree8, degree7);
            binaryTree.InsertNode(degree8, divison8);

            return new List<Component>() { degree0,degree1,degree2,degree3,degree4,degree5,degree6,degree7,degree8};
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
