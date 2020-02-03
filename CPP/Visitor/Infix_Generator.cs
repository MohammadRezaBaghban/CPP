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
    public class Infix_Generator : IVisitor
    {
        public void Calculate(IMathematicalOperation visitable)
        {
           
            CompositeNode compositeNode = visitable as CompositeNode;
            if (compositeNode is Function)
            {
                Calculate(compositeNode.LeftNode);
                compositeNode.Evaluate(this);
            }
            if(compositeNode is Operation)
            {
                Calculate(compositeNode.RightNode);
                Calculate(compositeNode.LeftNode);
                compositeNode.Evaluate(this);
            }
        }

       
        public void Visit(AddOperator visitable) => visitable.InFixFormula =  visitable.LeftNode.InFixFormula + " + " + visitable.RightNode.InFixFormula;

        public void Visit(SubstractOperator visitable) => visitable.InFixFormula =  visitable.LeftNode.InFixFormula + " - " + visitable.RightNode.InFixFormula;

        public void Visit(MultiplicationOperator visitable) => visitable.InFixFormula = "(" + visitable.LeftNode.InFixFormula + ") * (" + visitable.RightNode.InFixFormula + ")";

        public void Visit(DivisionOperator visitable) => visitable.InFixFormula = "(" + visitable.LeftNode.InFixFormula + ") / (" + visitable.RightNode.InFixFormula + ")";

        public void Visit(PowerOperator visitable) => visitable.InFixFormula = visitable.LeftNode.InFixFormula + " ^ " + visitable.RightNode.InFixFormula;

        public void Visit(FactorialFunc visitable) => visitable.InFixFormula = "(" + visitable.LeftNode.InFixFormula + ")!";

        public void Visit(LogarithmFunc visitable) => visitable.InFixFormula = "Ln(" + visitable.LeftNode.InFixFormula + ")";

        public void Visit(ExponentialFun visitable) => visitable.InFixFormula = "Exp(" + visitable.LeftNode.InFixFormula + ")";

        public void Visit(SinFunc visitable) => visitable.InFixFormula = "Sin(" + visitable.LeftNode.InFixFormula + ")";

        public void Visit(CosFunc visitable) => visitable.InFixFormula = "Cos(" + visitable.LeftNode.InFixFormula + ")";

        public void Visit(TanFunc visitable) => visitable.InFixFormula = "Tan(" + visitable.LeftNode.InFixFormula + ")";

    }
}
