using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Tree__Visitable___Composite_Component_.Functions;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitor
{
    class Calculate : IVisitor
    {

        public void TraverseForCalculate(IMathematicalOperation visitable)
        {
            if (visitable is SingleNode)
            {
                SingleNode single = visitable as SingleNode;

                if (single.IsVariable)
                {
                    single.Data = 10;
                }

            }
            else
            {
                CompositeNode compositeNode = visitable as CompositeNode;
                if (compositeNode is Function)
                {
                    TraverseForCalculate(compositeNode.LeftNode);
                    compositeNode.Evaluate(this);
                }
                else
                {

                    TraverseForCalculate(compositeNode.LeftNode);
                    TraverseForCalculate(compositeNode.RightNode);
                    visitable.Evaluate(this);
                }
            }
        }

        public void Visit(AddOperator visitable) => visitable.Data = visitable.LeftNode.Data + visitable.RightNode.Data;

        public void Visit(SubstracOperator visitable) => visitable.Data = visitable.LeftNode.Data - visitable.RightNode.Data;

        public void Visit(MultipicationOperator visitable) => visitable.Data = visitable.LeftNode.Data * visitable.RightNode.Data;

        public void Visit(DivisionOperator visitable) => visitable.Data = visitable.RightNode.Data / visitable.LeftNode.Data;

        public void Visit(PowerOperator visitable) => visitable.Data = Math.Pow(visitable.LeftNode.Data, visitable.RightNode.Data);

        public void Visit(ExponentialFun visitable) => visitable.Data = Math.Exp(visitable.LeftNode.Data);

        public void Visit(LogarithmFunc visitable) => visitable.Data = Math.Log(visitable.LeftNode.Data);


        public void Visit(SinFunc visitable) => visitable.Data = Math.Sin(visitable.LeftNode.Data * Math.PI/180);

        public void Visit(CosFunc visitable) => visitable.Data = Math.Cos(visitable.LeftNode.Data * Math.PI/180);

        public void Visit(TanFunc visitable) => visitable.Data = Math.Tan(visitable.LeftNode.Data * Math.PI/180);

        public void Visit(FactorialFunc visitable)
        {
            int factorial = 1;
            for (int i = 1; i <= visitable.LeftNode.Data; i++)
            {
                factorial *= i;
            }
            visitable.Data = factorial;


        }

    }
}
