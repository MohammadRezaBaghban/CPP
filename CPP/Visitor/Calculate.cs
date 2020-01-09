using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitor
{
    class Calculate : IVisitor
    {

        public double TraverseForCalculate(IMathematicalOperation visitable)
        {
            if (visitable is SingleNode)
            {
                SingleNode single = visitable as SingleNode;

                if (single.IsVariable)
                {
                    return single.Data = 10;
                }
                else
                {
                    return single.Data;
                }

            }
            else
            {
                CompositeNode compositeNode = visitable as CompositeNode;
                if (compositeNode is Function)
                {
                    TraverseForCalculate(compositeNode.LeftNode);
                    return compositeNode.evaluate(this);
                }
                else
                {

                    TraverseForCalculate(compositeNode.LeftNode);
                    TraverseForCalculate(compositeNode.RightNode);
                    return visitable.evaluate(this);
                }
            }
        }

        public double Visit(AddOperator visitable)
        {
            visitable.Data = visitable.LeftNode.Data + visitable.RightNode.Data;
            return visitable.Data;
        }

        public double Visit(SubstracOperator visitable)
        {
            visitable.Data = visitable.LeftNode.Data - visitable.RightNode.Data;
            return visitable.Data;

        }

        public double Visit(MultipicationOperator visitable)
        {
            visitable.Data = visitable.LeftNode.Data * visitable.RightNode.Data;
            return visitable.Data;

        }

        public double Visit(DivisionOperator visitable)
        {
            visitable.Data = visitable.RightNode.Data / visitable.LeftNode.Data;
            return visitable.Data;

        }

        public double Visit(PowerOperator visitable)
        {
            visitable.Data = Math.Pow(visitable.LeftNode.Data, visitable.RightNode.Data);
            return visitable.Data;

        }
        public double Visit(FactorialFunc visitable)
        {
            int factorial = 1;
            for (int i = 1; i <= visitable.LeftNode.Data; i++)
            {
                factorial *= i;
            }
            visitable.Data = factorial;
            return visitable.Data;

        }
        public double Visit(ExponentialFun visitable)
        {
            visitable.Data = Math.Exp(visitable.LeftNode.Data);
            return visitable.Data;

        }

        public double Visit(SinFunc visitable)
        {
            visitable.Data = Math.Sin(visitable.LeftNode.Data);
            return visitable.Data;

        }

        public double Visit(CosFunc visitable)
        {
            visitable.Data = Math.Cos(visitable.LeftNode.Data);
            return visitable.Data;

        }

        public double Visit(TanFunc visitable)
        {
            visitable.Data = Math.Tan(visitable.LeftNode.Data);
            return visitable.Data;

        }
    }
}
